using Microsoft.CodeAnalysis.Sarif;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rappen.XTB.PAC.Helpers
{
    public enum Category
    {
        Unknown = 0,
        Performance = 1,
        UpgradeReadiness = 2,
        Usage = 3,
        Security = 4,
        Design = 5,
        OnlineMigration = 6,
        Maintainability = 7,
        Supportability = 8,
        Accessibility = 9
    }

    public enum Component
    {
        Unknown = 0,
        WebResource = 1,
        ManagedCode = 2,
        Configuration = 3
    }

    public enum Severity
    {
        Informational = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        Critical = 5
    }

    public class AnalysisArgs
    {
        #region Public Fields

        public Guid CorrId = Guid.NewGuid();
        public List<string> FileExclusions = new List<string>();
        public List<Rule> Rules = new List<Rule>();
        public List<RuleSet> RuleSets = new List<RuleSet>();
        public List<Solution> Solutions = new List<Solution>();

        public string SolutionNames => string.Join(", ", Solutions.Select(s => s.ToString()));

        #endregion Public Fields
    }

    public class AnalysisStatus
    {
        #region Public Fields

        public StatusSummary IssueSummary;
        public int Progress;
        public string[] ResultFileUris;
        public Guid RunCorrelationId;
        public string Status;

        #endregion Public Fields

        #region Public Constructors

        public AnalysisStatus() { }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            return $"{Status} / {Progress}";
        }

        #endregion Public Methods
    }

    public class Artifact
    {
        public string File { get; set; }
        public int Size { get; set; }

        public Artifact(Microsoft.CodeAnalysis.Sarif.Artifact artifact)
        {
            File = artifact.Location.Uri.ToString();
            Size = artifact.Length;
        }
    }

    public class Fix
    {
        #region Public Fields

        public string Summary;

        #endregion Public Fields

        #region Public Constructors

        public Fix() { }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            return Summary;
        }

        #endregion Public Methods
    }

    public class FlattenedSarifResult
    {
        #region Public Fields

        public int? EndLine;
        public string Message;
        public string Snippet;
        public Rule Rule;

        #endregion Public Fields

        #region Public Properties

        public string Severity { get; set; }
        public string RuleDescription => Rule.ToString();
        public Category Category => Rule.PrimaryCategory;
        public string Module { get; set; }
        public Uri FilePath { get; set; }
        public int? StartLine { get; set; }

        #endregion Public Properties


        #region Public Methods

        public static List<FlattenedSarifResult> GetFlattenedResults(Run run, List<Rule> rules)
        {
            return run.Results
                .SelectMany(r => r.Locations, (result, location) => new FlattenedSarifResult
                {
                    Rule = rules.FirstOrDefault(r => r.Code == result.RuleId),
                    Message = result.Message?.Text,
                    FilePath = location.PhysicalLocation?.ArtifactLocation?.Uri,
                    StartLine = location.PhysicalLocation?.Region?.StartLine,
                    Snippet = location.PhysicalLocation?.Region?.Snippet?.Text,
                    EndLine = location.PhysicalLocation?.Region?.EndLine,
                    Module = location.PropertyNames.Contains("module") ? location.GetProperty("module") : null,
                    Severity = result.PropertyNames.Contains("severity") ? result.GetProperty("severity") : null
                }).ToList();
        }

        #endregion Public Methods
    }

    public class Rule
    {
        #region Public Fields

        public string Code;
        public int ComponentType;
        public string Description;
        public string GuidanceUrl;
        public Fix HowToFix;
        public bool Include;
        public Category PrimaryCategory;
        public Severity Severity;
        public string Summary;

        #endregion Public Fields

        #region Public Constructors

        public Rule() { }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Description) ? Code : Description;
        }

        #endregion Public Methods
    }

    public class RuleSet
    {
        #region Public Fields

        public Guid Id;
        public string Name;

        #endregion Public Fields

        #region Public Constructors

        public RuleSet() { }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion Public Methods
    }

    public class Solution
    {
        #region Public Properties

        public string LocalFileName => Path.GetFileName(LocalFilePath);
        public string LocalFilePath { get; internal set; }
        public string UniqueName { get; internal set; }
        public string UploadFileName => UploadUrl?.Segments?.LastOrDefault();
        public Version Version { get; internal set; }
        public Uri UploadUrl { get; internal set; }

        public override string ToString()
        {
            return UniqueName ?? LocalFileName;
        }

        #endregion Public Properties
    }

    public class StatusSummary
    {
        #region Public Fields

        public int CriticalIssueCount;
        public int HighIssueCount;
        public int InformationalIssueCount;
        public int LowIssueCount;
        public int MediumIssueCount;

        #endregion Public Fields
    }
}
