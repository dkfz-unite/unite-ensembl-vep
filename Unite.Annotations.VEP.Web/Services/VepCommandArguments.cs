using Unite.Annotations.VEP.Web.Services.Enums;

namespace Unite.Annotations.VEP.Web.Services
{
    public static class VepCommandArguments
    {
        public static readonly string Cache = "--cache";
        public static readonly string Offlie = "--offline";
        public static readonly string Overwrite = "--force_overwrite";
        public static readonly string Data = "--symbol --biotype --regulatory";


        public static string Input(string file)
        {
            return $"-i {file}";
        }

        public static string Output(string file)
        {
            return $"-o {file}";
        }

        public static string Format(Format format)
        {
            return format == Enums.Format.JSON ? "--json" :
                   format == Enums.Format.VCF ? "--vcf" :
                   "";
        }


        public static string Default(string inputFile, string outputFile, Format format)
        {
            return $"{Cache} {Offlie} {Overwrite} {Input(inputFile)} {Output(outputFile)} {Format(format)} {Data}";
        }
    }
}
