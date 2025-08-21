using System.Text.Json.Serialization;
using System.Text.Json;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Handlers;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzaliaJwellery.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductHandler _createHandler;
        private readonly UpdateProductHandler _updateHandler;
        private readonly DeleteProductHandler _deleteHandler;
        private readonly GetProductByIdHandler _getByIdHandler;
        private readonly GetAllProductsHandler _getAllHandler;
        private readonly GetProductsByCategoryIdEngagementQueryHandler _getProductsByCategoryIdEngagementQueryHandler;


        public ProductsController(
            CreateProductHandler createHandler,
            UpdateProductHandler updateHandler,
            DeleteProductHandler deleteHandler,
            GetProductByIdHandler getByIdHandler,
            GetAllProductsHandler getAllHandler, GetProductsByCategoryIdEngagementQueryHandler getProductsByCategoryIdEngagementQueryHandler)
        {
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _getByIdHandler = getByIdHandler;
            _getAllHandler = getAllHandler;
            _getProductsByCategoryIdEngagementQueryHandler = getProductsByCategoryIdEngagementQueryHandler;
        }
        //  [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command)
        {
            Console.WriteLine("Create method invoked");
            await _createHandler.Handle(command);
            return Ok();
        }
        [HttpGet("Category/{categoryId}/Engagements")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetByCategoryIdAndEngagments([FromRoute] int categoryId)
        {
            var products = await _getProductsByCategoryIdEngagementQueryHandler.Handle(new GetProductsByCategoryIdQuery { CategoryId = categoryId });
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return Ok(JsonSerializer.Serialize(products, options));
        }
        [HttpGet("Category/{categoryId}/Exclusive")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetByCategoryIdAndExclusive([FromRoute] int categoryId)
        {
            var products = await _getProductsByCategoryIdEngagementQueryHandler.Handle(new GetProductsByCategoryIdQuery { CategoryId = categoryId });
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return Ok(JsonSerializer.Serialize(products, options));
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateProductCommand command)
        {
            command.Id = id; // Optional: assign route param to command object
            await _updateHandler.Handle(command);
            return NoContent();
        }
        // [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteHandler.Handle(new DeleteProductCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetById(int id)
        {
            var product = await _getByIdHandler.Handle(new GetProductByIdQuery { Id = id });
           // return product == null ? NotFound() : Ok(product);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return Ok(JsonSerializer.Serialize(product, options));

        }
        [HttpGet("multi/{itemShape}/{itemLabOrNat}/{itemColor}/{caratRangeMin}/{caratRangeMax}/{budgetRangeMin}/{budgetRangeMax}/{JewelleryType}/{Category}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetRecentlyMadeRings(int itemShape, int itemLabOrNat, int itemColor, decimal caratRangeMin,
            decimal caratRangeMax, int budgetRangeMin, int budgetRangeMax,int JewelleryType, int Category)
        {
            var products = await _getProductsByCategoryIdEngagementQueryHandler.Handle(new GetProductsByCategoryIdQuery
            {
                itemShape = itemShape,
                itemLabOrNat = itemLabOrNat,
                itemColor = itemColor,
                CaratRangeMin = caratRangeMin,
                CaratRangeMax = caratRangeMax,
                BudgetRangeMin = budgetRangeMin,
                BudgetRangeMax = budgetRangeMax,
                JewelleryTypeID = JewelleryType,
                CategoryId = Category,
            });
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return Ok(JsonSerializer.Serialize(products, options));
        }
        [HttpGet("multiRingDesign/{selectedShape}/{selectedStyle}/{selectedMetal}/{selectedValue}/{JewelleryType}/{Category}/{LabOrNat}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetDesignedProduct(int selectedShape, int selectedStyle, int selectedMetal, int selectedValue,
            int JewelleryType, int Category,int LabOrNat)
        {
            var products = await _getProductsByCategoryIdEngagementQueryHandler.Handle(new GetProductsByCategoryIdQuery
            {
                itemShape = selectedShape,
                selectedStyle = selectedStyle,
                itemColor = selectedMetal,
                JewelleryTypeID = JewelleryType,
                CategoryId = Category,
                SelectedValue = selectedValue,
                itemLabOrNat= LabOrNat
            });
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return Ok(JsonSerializer.Serialize(products, options));
        }
        

        [HttpGet("multiRingDiamondDesign/{selectedShapeStep2}/{debouncedMinInput}/{debouncedMaxInput}/{debouncedlocalMin}/{debouncedlocalMax}/{debouncedMinRangeValue}/{debouncedMaxRangeValue}/{titleValue}/{JewelleryType}/{Category}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetDiamondDesignedProduct(int selectedShapeStep2, decimal debouncedMinInput, decimal debouncedMaxInput, int debouncedlocalMin, int debouncedlocalMax,
            int debouncedMinRangeValue, int debouncedMaxRangeValue,string titleValue,int JewelleryType, int Category)
        {
            var products = await _getProductsByCategoryIdEngagementQueryHandler.Handle(new GetProductsByCategoryIdQuery
            {
                itemShape = selectedShapeStep2,
                debouncedMinRangeValue = debouncedMinRangeValue,
                debouncedMaxRangeValue = debouncedMaxRangeValue,
                CaratRangeMin = debouncedMinInput,
                CaratRangeMax = debouncedMaxInput,
                BudgetRangeMin = debouncedlocalMin,
                BudgetRangeMax = debouncedlocalMax,
                TitleValue = titleValue,
                JewelleryTypeID = JewelleryType,
                CategoryId = Category,
               

        });
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return Ok(JsonSerializer.Serialize(products, options));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _getAllHandler.Handle();
            return Ok(products);
        }
    }
}
