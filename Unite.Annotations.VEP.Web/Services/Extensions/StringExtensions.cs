using System;
using System.Collections.Generic;
using System.IO;

namespace Unite.Annotations.VEP.Web.Services.Extensions
{
    public static class StringExtensions
    {
        public static string[] GetAllLines(this string input)
        {
            var lines = new List<string>();
            var line = string.Empty;

            using var reader = new StringReader(input);

            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line.Trim());
            }

            return lines.ToArray();
        }
    }
}
