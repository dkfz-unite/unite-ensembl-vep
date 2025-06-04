using Microsoft.AspNetCore.Mvc;
using Ensembl.Vep.Web.Services;
using Ensembl.Vep.Web.Services.Enums;

namespace Ensembl.Vep.Web.Controllers;

[Route("api/[controller]")]
public class VepController : Controller
{
    private readonly AnnotationService _annotationService;

    public VepController()
    {
        _annotationService = new AnnotationService();
    }

    [HttpGet]
    public ActionResult Get([FromQuery]string input, [FromQuery]int grch = 37, [FromQuery]bool regulatory = false)
    {
        try
        {
            var output = _annotationService.Annotate(input, Format.VEP, grch, regulatory);

            return Content(output, "text/plain");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Consumes("application/json")]
    public ActionResult Post([FromBody]string[] inputs, [FromQuery]int grch = 37, [FromQuery]bool regulatory = false)
    {
        try
        {
            var input = string.Join(Environment.NewLine, inputs);

            var output = _annotationService.Annotate(input, Format.JSON, grch, regulatory);

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
    public async Task<ActionResult> Post([FromQuery]int grch = 37, [FromQuery]bool regulatory = false)
    {
        try
        {
            using var reader = new StreamReader(Request.Body);

            var input = await reader.ReadToEndAsync();

            var output = _annotationService.Annotate(input, Format.VEP, grch, regulatory);

            return Content(output, "text/plain");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
