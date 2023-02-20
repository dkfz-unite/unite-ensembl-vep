using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ensembl.Vep.Web.Controllers.Extensions;
using Ensembl.Vep.Web.Converters;
using Ensembl.Vep.Web.Services;
using Ensembl.Vep.Web.Services.Enums;

namespace Ensembl.Vep.Web.Controllers
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
                var pair = (Hgvs: input, Vcf: HgvsInputConverter.ToVcf(input));

                var vcfOutput = _annotationService.Annotate(pair.Vcf, Format.JSON);

                var hgvsOutput = RestoreHgvsInput(vcfOutput, pair);

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
                var pairs = inputs.Select(input => (Hgvs: input, Vcf: HgvsInputConverter.ToVcf(input)));

                var input = string.Join(Environment.NewLine, pairs.Select(pair => pair.Vcf));

                var vcfOutput = _annotationService.Annotate(input, Format.JSON);

                var hgvsOutput = RestoreHgvsInput(vcfOutput, pairs);

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
            try
            {
                var inputs = await Request.Body.ReadAllLinesAsync();

                var pairs = inputs.Select(input => (Hgvs: input, Vcf: HgvsInputConverter.ToVcf(input)));

                var input = string.Join(Environment.NewLine, pairs.Select(pair => pair.Vcf));

                var vcfOutput = _annotationService.Annotate(input, Format.JSON);

                var hgvsOutput = RestoreHgvsInput(vcfOutput, pairs);

                var json = VepJsonHelper.FixJson(hgvsOutput);

                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        private string RestoreHgvsInput(string outputContent, (string Hgvs, string Vcf) input)
        {
            return outputContent.Replace(input.Vcf, input.Hgvs);
        }

        private string RestoreHgvsInput(string output, IEnumerable<(string Hgvs, string Vcf)> inputs)
        {
            var content = new string(output);

            foreach (var input in inputs)
            {
                if (content.Contains(input.Vcf))
                {
                    content = content.Replace(input.Vcf, input.Hgvs);
                }
            }

            return content;
        }
    }
}
