using System.IO;
using Unite.Vep.Web.Services.Enums;

namespace Unite.Vep.Web.Services
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
