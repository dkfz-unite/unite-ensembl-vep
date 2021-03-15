﻿using System;
using System.Text;
using Unite.Annotations.VEP.Web.Services.Extensions;

namespace Unite.Annotations.VEP.Web.Services
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
