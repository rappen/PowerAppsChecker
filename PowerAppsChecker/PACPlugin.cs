using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Rappen.XTB.PAC
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Power Apps Checker"),
        ExportMetadata("Description", "Check your Power Apps solutions, Canvas Apps and Power Automate flows before they hit the build pipeline!"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAFXRFWHRDcmVhdGlvbiBUaW1lAAfiBgMSATGIy+9yAAAAB3RJTUUH4wsDCxkKTuHylAAAAAlwSFlzAAAK8AAACvABQqw0mAAAARpQTFRF///G3ufGrca9jKW9e5y9hKW9pb291t7GIVq1AEKtAEq9GFKta5S17/fGAEK1AFLWAFrvAGP/WoS1vc69AFLeAFrnEEqtlK29AErOAGP3lLW9jLVz3u8YY5ycc62M3uch1ucpc5y9SpS1//8Azt4xQoy9nLW95+8YIXPeMYTOCEqtrc5SWpylUpStvdZChLV7Snu15+/GKXvOxta9KWO1a6WUKXvWxt45Wpyc9//G3u8htc5KGHPn9/cI7/cQCGv3nMZjtdZKOYTGxt4xlL1jjK29Soy1IXvWtdZCEGvvrc5KAErGIXvee62EpcZa9/8A7/cIQoy1lL1rzucpMYTGjL1zUoS1CFreSpStY4y1Y6WUQnO1OYy9c5S9oR0B5gAAAAF0Uk5TAEDm2GYAAAJLSURBVHjabVOBUtpAEAWL4AUMLAQ0QkRd0kuAhIoFSyVCoUApAtpS29T2/3+je5ekwujOZDJ7792+vdt3sdhz9K5Ozn3/71GhF3stUn6JqcpisVBZPX/1Ao4/MkXTR12Auz+6tmBPqV08WVKKAKbHuxb3TICcUp9s4/ssCwI/49zhXnNDicb83hauSbw2tyrcccbeA6VF5kf4nsShgw19MF475i2egmSEKpclUZ9iiQ133RnzZifItXrQqa8CRIx1c+Th7yhfPMkDsp/tdtvezIWKA/BL1jfLw+UsxwpEOFdHKMJr0frFj7JBP30lV4zFIxEOsjZem5vpGEm6hsgHAC10N32Hr4r1Q1LIWbiiXf31d7DFRgfm91wIzvo6aewx6EsCVO9hKAg38IDfwjbVSWyihoSBV517eF3Ddd8ILkKcIxNLKERwu5bdwNYp4gf6lg62IkJeECx5CmwMqng76Ht4doc1geq6IJBEl05hTmcwRfwM0EAcfcGWDvOvZSFBTdr4SdYTEICDOLQ48rFHdGrykuXsjzcCF8VFYS6EhpXbmgE6I2u9D0dF00S33e3a19RquKSVyBP70axq+D/ccEnJi2nXpRugjVthQeAIad6MqousTAc1mo7TNFwM70F5J/1wmD4Oegv3iYlUxT9bjweWKgjLXmBwO3IqiKYQeBuZ8oRMWa5UjIhwWj0rE37+bPsjdqzDbmRZYvthFNKqtg0XlVJy92kdZpiazQVoLquwfPzl60wcMKZQMJbOpGKvRnzvTSKxn9xB/wEW5GVwmNM8twAAAABJRU5ErkJggg=="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "#FFFFC0"),
        ExportMetadata("PrimaryFontColor", "#0000C0"),
        ExportMetadata("SecondaryFontColor", "#0000FF")]
    public class PACPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new PAC();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public PACPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}