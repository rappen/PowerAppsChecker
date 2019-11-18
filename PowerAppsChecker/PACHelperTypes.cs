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

        public Rule Rule;
        public string Message;
        public string Snippet;
        public string Module;
        public string Member;
        public string Type;
        public Uri FilePath;
        public int? StartLine;
        public int? EndLine;

        #endregion Public Fields

        #region Public Properties

        public string Severity { get; set; }
        public string RuleDescription => Rule.ToString();
        public Category Category => Rule.PrimaryCategory;
        public Component Component => Rule.Component;
        public string Location => (Member ?? Module ?? Type ?? FilePath.ToString()) + (StartLine != null && StartLine > 0 ? $" (Line {StartLine})" : "");

        #endregion Public Properties


        #region Public Methods

        public static List<FlattenedSarifResult> GetFlattenedResults(Run run, List<Rule> rules)
        {
            void AddMissingComponent(Rule rule)
            {
                if (rule.ComponentType != 0 ||
                    !(run.Tool.Driver.Rules.FirstOrDefault(r => r.Id == rule.Code) is ReportingDescriptor sarifrule) ||
                    !sarifrule.TryGetProperty("componentType", out string type) ||
                    string.IsNullOrWhiteSpace(type))
                {
                    return;
                }
                rule.ComponentType = (int)Enum.Parse(typeof(Component), type);
            }

            string GetPropertyOrNull(PropertyBagHolder bag, string name)
            {
                return bag.PropertyNames.Contains(name) ? bag.GetProperty(name) : null;
            }

            rules.ForEach(AddMissingComponent);
            return run.Results
                .SelectMany(r => r.Locations, (result, location) => new FlattenedSarifResult
                {
                    Rule = rules.FirstOrDefault(r => r.Code == result.RuleId),
                    Severity = GetPropertyOrNull(result, "severity"),
                    Message = result.Message?.Text,
                    Snippet = location.PhysicalLocation?.Region?.Snippet?.Text,
                    Module = GetPropertyOrNull(location, "module"),
                    Member = GetPropertyOrNull(location, "member"),
                    Type = GetPropertyOrNull(location, "type"),
                    FilePath = location.PhysicalLocation?.ArtifactLocation?.Uri,
                    StartLine = location.PhysicalLocation?.Region?.StartLine,
                    EndLine = location.PhysicalLocation?.Region?.EndLine
                }).ToList();
        }

        #endregion Public Methods
    }

    public class Rule
    {
        #region Public Fields

        public string Code;
        public int ComponentType;
        public Component Component => (Component)ComponentType;
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
