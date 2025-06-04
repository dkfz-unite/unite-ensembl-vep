using Ensembl.Vep.Web.Services.Enums;

namespace Ensembl.Vep.Web.Services;

public abstract class VepFile : IDisposable
{
    // private const string _cacheFolder = "/data";
    private const string _cacheFolder = "/cache";
    // private const string _cacheFolder = "/app/data";


    public string Path { get; private set; }


    public VepFile(string name, Format format)
    {
        Path = $"{_cacheFolder}/{name}.{GetExtension(format)}";
    }


    private static string GetExtension(Format format)
    {
        return format == Format.JSON ? "json"
             : format == Format.VCF ? "vcf"
             : "txt";
    }


    #region IDisposable
    public virtual void Dispose()
    {
        if (File.Exists(Path))
        {
            File.Delete(Path);
        }
    }
    #endregion
}