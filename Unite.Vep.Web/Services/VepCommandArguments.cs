using Unite.Vep.Web.Services.Enums;

namespace Unite.Vep.Web.Services
{
    public static class VepCommandArguments
    {
        public static readonly string Cache = "--cache";
        public static readonly string Offlie = "--offline";
        public static readonly string Overwrite = "--force_overwrite";
        public static readonly string NoStats = "--no_stats";
        public static readonly string NoIntergenic = "--no_intergenic";
        //public static readonly string Data = "--symbol --biotype --ccds --protein --regulatory --numbers";
        public static readonly string Data = ""; //"--regulatory";

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

        public static string Buffer(int size = 5000)
        {
            return $"--buffer_size {size}";
        }

        public static string MaximumSvSize(int size = 200000)
        {
            return $"--max_sv_size {size}";
        }


        public static string Default(string inputFile, string outputFile, Format format)
        {
            return $"{Cache} {Offlie} {Overwrite} {NoStats} {NoIntergenic} {Input(inputFile)} {Output(outputFile)} {Format(format)} {Buffer(20000)} {MaximumSvSize(250000000)} {Data}";
        }
    }
}
