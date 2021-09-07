using System.IO;
using Unite.Vep.Web.Services.Enums;

namespace Unite.Vep.Web.Services
{
    public class VepInputFile : VepFile
    {
        private const string _name = "input";

        public VepInputFile(Format format) : base(_name, format) { }

        public void Write(string content)
        {
            File.WriteAllText(Path, content);
        }
    }
}
