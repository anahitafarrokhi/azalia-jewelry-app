﻿namespace AzaliaJwellery.Commands
{
    public class UpdateProductCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
