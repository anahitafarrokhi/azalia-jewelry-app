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
        private readonly GetAllJewelleryTypesByCategoryIdHandler _GetAllJewelleryTypesByCategoryIdHandler;
        public JewelleryTypesController(GetAllJewelleryTypesByCategoryIdHandler getAllJewelleryTypesByCategoryIdHandler)
        {
            getAllJewelleryTypesByCategoryIdHandler = _GetAllJewelleryTypesByCategoryIdHandler;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JewelleryType>>> GetAll(int id)
        {
            var addresses = await _GetAllJewelleryTypesByCategoryIdHandler.Handle(new GetAllJewelleryTypeByCategoryIdQuery { CategoryId = id });
            return Ok(addresses);
        }

    }
}
