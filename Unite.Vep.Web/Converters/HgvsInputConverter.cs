using System;
using System.Text.RegularExpressions;

namespace Unite.Vep.Web.Converters
{
    public static class HgvsInputConverter
    {
        private const string _pattern = @"^([a-zA-Z0-9_\-\.]*):([a-z])\.([0-9]*)([ACGTNacgtn]*)>([ACGTNacgtn]*):?(.*)";

        public static string ToVcf(string hgvs)
        {
            try
            {
                var match = Regex.Match(hgvs, _pattern);

                var chromosome = match.Groups[1].Value.Replace("chr", "");
                var seqquenceType = match.Groups[2].Value;
                var position = match.Groups[3].Value;
                var referenceBase = match.Groups[4].Value;
                var alternateBase = match.Groups[5].Value;

                var vep = $"{chromosome} {position} . {referenceBase} {alternateBase}";

                return vep;
            }
            catch
            {
                throw new ArgumentException($"Input hgvs code '{hgvs}' does not match the pattern '{_pattern}'");
            }
        }
    }
}
