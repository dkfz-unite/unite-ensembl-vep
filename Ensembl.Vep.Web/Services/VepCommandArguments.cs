﻿using Ensembl.Vep.Web.Services.Enums;

namespace Ensembl.Vep.Web.Services;

public static class VepCommandArguments
{
    public static readonly string Cache = "--cache";
    public static readonly string CacheDir = "--dir_cache /cache";
    public static readonly string Offlie = "--offline";
    public static readonly string Overwrite = "--force_overwrite";
    public static readonly string NoStats = "--no_stats";
    public static readonly string NoIntergenic = "--no_intergenic";
    public static readonly string Canonical = "--canonical";
    //public static readonly string Data = "--symbol --biotype --ccds --protein --regulatory --numbers";

    public static string Assembly(int version = 37)
    {
        return $"--assembly GRCh{version}";
    }

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


    public static string Default(string inputFile, string outputFile, Format format, int grch = 37, bool regulatory = false)
    {
        var cmd = $"{Cache} {CacheDir} {Offlie} {Overwrite} {NoStats} {NoIntergenic} {Canonical} {Input(inputFile)} {Output(outputFile)} {Format(format)} {Assembly(grch)} {Buffer(20000)} {MaximumSvSize(250000000)}";

        if (regulatory)
            cmd += " --regulatory";
            
        return cmd;
    }
}
