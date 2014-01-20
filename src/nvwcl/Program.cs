using System;
using System.IO;
using System.Reflection;
using NinjaVsWerewolves.CompositionRoot;

namespace NinjaVsWerewolves
{
    static class Program
    {
        // see http://stackoverflow.com/questions/3314140/how-to-read-embedded-resource-text-file
        public static String TextFile(Assembly asm, string resource_name)
        {
            using (Stream stream = asm.GetManifestResourceStream(resource_name))
            {
                if (stream == null)
                    throw new FileNotFoundException("No embedded resource with name '{0}'", resource_name);

                using (var reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            var py = PythonConsoleHost.MakeHost();

            var asm = Assembly.GetAssembly(typeof (Program));
            var init = TextFile(asm, "NinjaVsWerewolves.__init__.py");

            py.Run(new string[] { "-X:ColorfulConsole", "-X:TabCompletion", "-i", "-c", init});
        }
    }
}
