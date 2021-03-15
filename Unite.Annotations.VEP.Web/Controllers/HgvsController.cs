using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unite.Annotations.VEP.Web.Converters;
using Unite.Annotations.VEP.Web.Services;
using Unite.Annotations.VEP.Web.Services.Enums;

namespace Unite.Annotations.VEP.Web.Controllers
{
    [Route("/api/[controller]")]
    public class HgvsController : Controller
    {
        private readonly AnnotationService _annotationService;

        public HgvsController()
        {
            _annotationService = new AnnotationService();
        }

        [HttpGet]
        public ActionResult Get(string input)
        {
            try
            {
                var pair = (Hgvs: input, Vep: HgvsInputConverter.ToVep(input));

                var vepOutput = _annotationService.Annotate(pair.Vep, Format.JSON);

                var hgvsOutput = RestoreHgvsInput(vepOutput, pair);

                var json = hgvsOutput;

                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        public ActionResult Post([FromBody] string[] inputs)
        {
            try
            {
                var pairs = inputs.Select(input => (Hgvs: input, Vep: HgvsInputConverter.ToVep(input)));

                var input = string.Join(Environment.NewLine, pairs.Select(pair => pair.Vep));

                var vepOutput = _annotationService.Annotate(input, Format.JSON);

                var hgvsOutput = RestoreHgvsInput(vepOutput, pairs);

                var json = VepJsonHelper.FixJson(hgvsOutput);

                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Consumes("text/plain")]
        public async Task<ActionResult> Post()
        {
            return BadRequest("Not implemented");
        }


        private string RestoreHgvsInput(string outputContent, (string Hgvs, string Vep) input)
        {
            return outputContent.Replace(input.Vep, input.Hgvs);
        }

        private string RestoreHgvsInput(string output, IEnumerable<(string Hgvs, string Vep)> inputs)
        {
            var content = new string(output);

            foreach (var input in inputs)
            {
                if (content.Contains(input.Vep))
                {
                    content = content.Replace(input.Vep, input.Hgvs);
                }
            }

            return content;
        }
    }
}
