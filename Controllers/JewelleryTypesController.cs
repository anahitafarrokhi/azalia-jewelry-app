using System.Text.Json.Serialization;
using System.Text.Json;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Handlers;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static NuGet.Packaging.PackagingConstants;

namespace AzaliaJwellery.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JewelleryTypesController : Controller
    {
        private readonly GetAllJewelleryTypesHandler _GetAllJewelleryTypesHandler;
        public JewelleryTypesController(GetAllJewelleryTypesHandler getAllJewelleryTypesHandler)
        {
            _GetAllJewelleryTypesHandler = getAllJewelleryTypesHandler;
        }
      
        [HttpGet("JewelleryTypes/GetAll")]

        public async Task<ActionResult<IEnumerable<JewelleryType>>> GetAll()
        {
            var jewelleryTypes = await _GetAllJewelleryTypesHandler.Handle();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return Ok(JsonSerializer.Serialize(jewelleryTypes, options));
        }

    }
}
