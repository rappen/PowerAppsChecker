﻿using Microsoft.CodeAnalysis.Sarif;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

    public class PACClientInfo
    {
        public string ServiceUrl = "https://api.advisor.powerapps.com";
        public Guid ClientId;
        public Guid TenantId;
        public string ClientSec;
        public string Token;
        public string Language;
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

    public class FilterItem
    {
        public string Name;
        public int Count;

        public override string ToString()
        {
            return $"{Name} ({Count})";
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
        public string Location => (Module ?? Type ?? FilePath.ToString());

        #endregion Public Properties

        #region Public Methods

        public static List<FlattenedSarifResult> GetFlattenedResults(Run run, List<Rule> rules)
        {
            void AddMissingComponent(Rule rule)
            {
                if (rule.ComponentType == 0 &&
                    (run.Tool?.Driver?.Rules?.FirstOrDefault(r => r.Id == rule.Code) is ReportingDescriptor sarifrule) &&
                    sarifrule.TryGetProperty("componentType", out string type) &&
                    Enum.TryParse(type, true, out Component component))
                {
                    rule.ComponentType = (int)component;
                }
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

        public string GetProperty(string name)
        {
            switch (name)
            {
                case "Severity": return Severity;
                case "Rule": return RuleDescription;
                case "Category": return Category.ToString();
                case "Component": return Component.ToString();
                case "Location": return Location;
                default: throw new ArgumentOutOfRangeException("name", name, "Unknown property");
            }
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
