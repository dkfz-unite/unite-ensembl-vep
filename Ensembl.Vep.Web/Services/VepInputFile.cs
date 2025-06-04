using Ensembl.Vep.Web.Services.Enums;

namespace Ensembl.Vep.Web.Services;

public class VepInputFile : VepFile
{
    private const string _name = "input";

    public VepInputFile(Format format) : base(_name, format) { }

    public void Write(string content)
    {
        File.WriteAllText(Path, content);
    }
}
