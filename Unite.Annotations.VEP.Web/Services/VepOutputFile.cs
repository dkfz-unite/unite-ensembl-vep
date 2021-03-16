using System.IO;
using Unite.Annotations.VEP.Web.Services.Enums;

namespace Unite.Annotations.VEP.Web.Services
{
    public class VepOutputFile : VepFile
    {
        private const string _name = "output";
        private const string _summary = "_summary.html";

        public VepOutputFile(Format format) : base(_name, format) { }

        public string Read()
        {
            return File.Exists(Path) ? File.ReadAllText(Path) : null;
        }

        #region IDisposable
        public override void Dispose()
        {
            base.Dispose();

            var summary = $"{Path}{_summary}";

            if (File.Exists(summary))
            {
                File.Delete(summary);
            }
        }
        #endregion
    }
}
