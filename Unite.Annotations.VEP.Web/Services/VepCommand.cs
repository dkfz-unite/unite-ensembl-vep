using System.Diagnostics;
using Unite.Annotations.VEP.Web.Services.Enums;

namespace Unite.Annotations.VEP.Web.Services
{
    public static class VepCommand
    {
        private const string _command = "/opt/vep/src/ensembl-vep/vep";

        public static void Run(string inputFile, string outputFile, Format format)
        {
            var arguments = VepCommandArguments.Default(inputFile, outputFile, format);

            Process.Start(_command, arguments).WaitForExit();
        }
    }
}
