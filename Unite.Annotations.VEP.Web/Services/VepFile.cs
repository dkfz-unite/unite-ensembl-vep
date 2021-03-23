using System;
using System.IO;
using Unite.Annotations.VEP.Web.Services.Enums;

namespace Unite.Annotations.VEP.Web.Services
{
    public abstract class VepFile : IDisposable
    {
        private const string _cacheFolder = "/opt/vep/.vep";


        public string Path { get; private set; }


        public VepFile(string name, Format format)
        {
            Path = $"{_cacheFolder}/{name}.{GetExtension(format)}";
        }


        private string GetExtension(Format format)
        {
            return format == Format.JSON ? "json"
                 : format == Format.VCF ? "vcf"
                 : "txt";
        }


        #region IDisposable
        public virtual void Dispose()
        {
            //if (File.Exists(Path))
            //{
            //    File.Delete(Path);
            //}
        }
        #endregion
    }
}