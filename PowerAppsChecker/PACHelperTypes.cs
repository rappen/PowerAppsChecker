using Microsoft.CodeAnalysis.Sarif;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rappen.XTB.PAC.Helpers
{
    public enum Category
    {
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

        public Guid CorrId;
        public List<string> Exclusions;
        public string FileUrl;
        public List<Rule> Rules;
        public List<RuleSet> RuleSets;

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

    public class FlattenedResult
    {
        #region Public Properties

        public int? EndLine { get; set; }
        public Uri FilePath { get; set; }
        public string Message { get; set; }
        public string Module { get; set; }
        public string RuleId { get; set; }
        public string Severity { get; set; }
        public string Snippet { get; set; }
        public int? StartLine { get; set; }

        #endregion Public Properties

        #region Public Methods

        public static List<FlattenedResult> GetFlattenedResults(Run run)
        {
            var query =
                run.Results
                .SelectMany(r => r.Locations, (result, location) => new FlattenedResult
                {
                    RuleId = result.RuleId,
                    Message = result.Message?.Text,
                    FilePath = location.PhysicalLocation?.ArtifactLocation?.Uri,
                    StartLine = location.PhysicalLocation?.Region?.StartLine,
                    Snippet = location.PhysicalLocation?.Region?.Snippet?.Text,
                    EndLine = location.PhysicalLocation?.Region?.EndLine,
                    Module = location.PropertyNames.Contains("module") ? location.GetProperty("module") : null,
                    Severity = result.PropertyNames.Contains("severity") ? result.GetProperty("severity") : null
                });
            return query.ToList();
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

    public class SolutionItem
    {
        #region Public Fields

        public Entity Solution;

        #endregion Public Fields

        #region Public Constructors

        public SolutionItem(Entity solution)
        {
            Solution = solution;
        }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            return Solution["friendlyname"].ToString();
        }

        #endregion Public Methods
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
