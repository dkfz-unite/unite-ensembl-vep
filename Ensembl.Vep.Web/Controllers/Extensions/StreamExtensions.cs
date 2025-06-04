namespace Ensembl.Vep.Web.Controllers.Extensions;

public static class StreamExtensions
{
    public static async Task<string[]> ReadAllLinesAsync(this Stream stream)
    {
        using var reader = new StreamReader(stream);
        var lines = new List<string>();
        var line = string.Empty;

        while ((line = await reader.ReadLineAsync()) != null)
        {
            lines.Add(line.Trim());
        }

        return lines.ToArray();
    }
}
