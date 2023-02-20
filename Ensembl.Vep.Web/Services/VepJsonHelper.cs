using System;
using System.Text;
using Ensembl.Vep.Web.Services.Extensions;

namespace Ensembl.Vep.Web.Services
{
    public static class VepJsonHelper
    {
        public static string FixJson(string vepJson)
        {
            var lines = vepJson.GetAllLines();

            var json = new StringBuilder();

            json.AppendLine("[");

            json.Append(string.Join($",{Environment.NewLine}", lines));

            json.AppendLine("]");

            return json.ToString();
        }
    }
}
