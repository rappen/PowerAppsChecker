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
        ExportMetadata("Name", "PowerApps Checker"),
        ExportMetadata("Description", "Check your solutions before they hit the build pipeline!"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAFXRFWHRDcmVhdGlvbiBUaW1lAAfiBgMSATGIy+9yAAAAB3RJTUUH4wkbDAkyxgNizgAAAAlwSFlzAAAK8AAACvABQqw0mAAAAPxQTFRF///G3ufGrca9jKW9e5y9hKW9pb291t7GIVq1AEKtAEq9GFKta5S17/fGAEK1AFLWAFrvAGP/WoS1vc69AFLeAFrnEEqtlK29AErOAGP3lLW9jLVz3u8YY5ycc62M3uch1ucpc5y9SpS1//8Azt4xQoy9nLW95+8YIXPeMYTOCEqtrc5SWpylUpStvdZChLV7Snu15+/GKXvOxta9KWO1a6WUKXvWxt459//GGHPn9/cICGP37/cQCGv3OYTGnMZjEGvve62EjK29Soy1lL1j9/8AAErGIXveY6Wc3u8htc5KjL1zrc5KUoS1tdZKGGvWY4y1QnO1AFLOc5S9LzvqkAAAAAF0Uk5TAEDm2GYAAAIMSURBVHjabVPreppAFETrJYsKHkUTQgyYo1URbZNUVBBvidSmTUva93+Xnl3BaHS+jx8ww86c3VlJesfk8boZRf8uqxPpHPJRnSlyGIYKsyuPJ3TqlcmaDgK6FrK3/DGfq8s1OEBZtteHfJap8AEaiyYHvAYnqLEo4dPneK6IXe7rf4MgWE6P6WkAmr1LGilz5Og09qxvzBDH8/BNDMhqLlpbZ2SiE/P6bzQXL+j9YVUSNBXoYp8+f8cW3P00aJ0t/vIB2n0IX0lwocJUCMD0oEVOPoyxG+e0S+RQhqUQ6LNOj2cZgGcmXuSRZkCCoQ9LAxcLLngBtJK0ylpaKzSSmAJbrofjFm6mP7wgFoRFKSPzeFZjO3rybxEdelbPeEtkQEOFFSFwcSj0Js6CqYdWd7Yx2o6FLhdwix6OOf+E+AzQR5y3O+S4WQkLHhJ0nws4BTBAXMDSWY26u5D3NGa8+55I73fIaD8mVetbUoUR4vDBdXtj3O+5VqdOZJX4rYV7DONPcoWftr1rwwMeoBs3QpS3qIiyGoj9hjMYOI0h4pfdAl9FH0qFK56nk/xHU6M4DNVO7SpV5ZW9o61OTsBEbHODz0kpr6mUxs3NvlG3pmUQ33yv/SW70j9UVmWZw4tRLShHza7J9dzx1SoVmaLGe1pWZVZJnd7OzAVjMoGxQjEvnUUq/SmTyeaO2P+a31lc/n/tkgAAAABJRU5ErkJggg=="),
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