using Ensembl.Vep.Web.Services.Enums;

namespace Ensembl.Vep.Web.Services;

public class AnnotationService
{
    public AnnotationService()
    {
    }

    public string Annotate(string input, Format format, int grch = 37, bool regulatory = false)
    {
        using var inputFile = new VepInputFile(format);
        using var outputFile = new VepOutputFile(format);

        inputFile.Write(input);

        VepCommand.Run(inputFile.Path, outputFile.Path, format, grch, regulatory);

        return outputFile.Read();
    }
}
