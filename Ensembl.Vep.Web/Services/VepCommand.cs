using System.Diagnostics;
using Ensembl.Vep.Web.Services.Enums;

namespace Ensembl.Vep.Web.Services;

public static class VepCommand
{
    private const string _command = "/opt/vep/src/ensembl-vep/vep";

    public static void Run(string inputFile, string outputFile, Format format, int grch = 37, bool regulatory = false)
    {
        var arguments = VepCommandArguments.Default(inputFile, outputFile, format, grch, regulatory);

        Process.Start(_command, arguments).WaitForExit();
    }
}
