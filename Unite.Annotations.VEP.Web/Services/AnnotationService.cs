using Unite.Annotations.VEP.Web.Services.Enums;

namespace Unite.Annotations.VEP.Web.Services
{
    public class AnnotationService
    {
        public AnnotationService()
        {
        }

        public string Annotate(string input, Format format)
        {
            using var inputFile = new VepInputFile(format);
            using var outputFile = new VepOutputFile(format);

            inputFile.Write(input);

            VepCommand.Run(inputFile.Path, outputFile.Path, format);

            return outputFile.Read();
        }
    }
}
