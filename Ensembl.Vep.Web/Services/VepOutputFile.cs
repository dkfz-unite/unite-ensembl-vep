using System.IO;
using Ensembl.Vep.Web.Services.Enums;

namespace Ensembl.Vep.Web.Services
{
    public class VepOutputFile : VepFile
    {
        private const string _name = "output";

        public VepOutputFile(Format format) : base(_name, format) { }

        public string Read()
        {
            return File.Exists(Path) ? File.ReadAllText(Path) : null;
        }
    }
}
