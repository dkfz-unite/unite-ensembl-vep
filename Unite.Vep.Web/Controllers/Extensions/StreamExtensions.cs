using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Unite.Vep.Web.Controllers.Extensions
{
    public static class StreamExtensions
    {
        public static async Task<string[]> ReadAllLinesAsync(this Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var lines = new List<string>();
                var line = "";

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    lines.Add(line.Trim());
                }

                return lines.ToArray();
            }
        }
    }
}
