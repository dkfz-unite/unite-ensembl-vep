using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ensembl.Vep.Web.Services;
using Ensembl.Vep.Web.Services.Enums;

namespace Ensembl.Vep.Web.Controllers
{
    [Route("api/[controller]")]
    public class VepController : Controller
    {
        private readonly AnnotationService _annotationService;

        public VepController()
        {
            _annotationService = new AnnotationService();
        }

        [HttpGet]
        public ActionResult Get(string input)
        {
            try
            {
                var output = _annotationService.Annotate(input, Format.VEP);

                return Content(output, "text/plain");
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
                var input = string.Join(Environment.NewLine, inputs);

                Console.WriteLine($"{string.Join(',' + Environment.NewLine, inputs)}");

                var output = _annotationService.Annotate(input, Format.JSON);

                var json = VepJsonHelper.FixJson(output);

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
                using var reader = new StreamReader(Request.Body);

                var input = await reader.ReadToEndAsync();

                var output = _annotationService.Annotate(input, Format.VEP);

                return Content(output, "text/plain");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
