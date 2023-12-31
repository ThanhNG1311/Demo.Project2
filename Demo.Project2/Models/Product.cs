﻿namespace Demo.Project2.Models
{
    public class Product : BaseModel
    {
        public Guid CategoryId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public int Price { get; set; }
        public int Stock { get; set;}
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
        public virtual Category? Category { get; set; }
        //public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new HashSet<OrderDetails>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}