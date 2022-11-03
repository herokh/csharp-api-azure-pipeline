﻿using System.ComponentModel.DataAnnotations.Schema;

namespace KhWebApi.WebApi.Models
{
    public class Product : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public Guid ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory? ProductCategory { get; set; }
    }
}