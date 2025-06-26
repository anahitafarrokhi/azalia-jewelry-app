using MediatR;

namespace AzaliaJwellery.Queries
{
    public class GetProductsByCategoryIdQuery : IRequest<List<ProductDto>>
    {
        public int CategoryId { get; set; }
        public int itemShape { get; set; }
        public int selectedStyle { get; set; }
        public int itemLabOrNat { get; set; }
        public int itemColor { get; set; }
        public int debouncedMinRangeValue { get; set; }
        public int debouncedMaxRangeValue { get; set; }
        public decimal CaratRangeMin { get; set; }
        public decimal CaratRangeMax { get; set; }
        public int BudgetRangeMin { get; set; }
        public int BudgetRangeMax { get; set; }
        public int JewelleryTypeID { get; set; }
        public int SelectedValue { get; set; }
        public string TitleValue { get; set; }
        

    }
}
