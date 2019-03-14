using System.Collections.ObjectModel;
#pragma warning disable CS0234 // Le nom de type ou d'espace de noms 'Automation' n'existe pas dans l'espace de noms 'System.Management' (vous manque-t-il une référence d'assembly ?)
#pragma warning restore CS0234 // Le nom de type ou d'espace de noms 'Automation' n'existe pas dans l'espace de noms 'System.Management' (vous manque-t-il une référence d'assembly ?)
#pragma warning disable CS0234 // Le nom de type ou d'espace de noms 'Automation' n'existe pas dans l'espace de noms 'System.Management' (vous manque-t-il une référence d'assembly ?)
#pragma warning restore CS0234 // Le nom de type ou d'espace de noms 'Automation' n'existe pas dans l'espace de noms 'System.Management' (vous manque-t-il une référence d'assembly ?)
using System.Text;

namespace UWPHook
{
    /// <summary>
    /// Functions related to Windows powershell
    /// </summary>
    internal static class ScriptManager
    {
        private static readonly object RunspaceFactory;

        public static string RunScript(string scriptText)
        {
            // create Powershell runspace
            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it
            runspace.Open();

            // create a pipeline and feed it the script text
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            // add an extra command to transform the script
            // output objects into nicely formatted strings

            // remove this line to get the actual objects
            // that the script returns. For example, the script

            // "Get-Process" returns a collection
            // of System.Diagnostics.Process instances.
            pipeline.Commands.Add("Out-String");

            // execute the script
            Collection<PSObject> results = pipeline.Invoke();

            // close the runspace
            runspace.Close();

            // convert the script result into a single string
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
