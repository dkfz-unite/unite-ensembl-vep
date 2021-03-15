using System.IO;
using Unite.Annotations.VEP.Web.Services.Enums;

namespace Unite.Annotations.VEP.Web.Services
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
