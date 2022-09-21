using System;

namespace FinalProject.Data
{
    public class Book
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Color { get; set; }
        public virtual string Brand { get; set; }
        public virtual int Price { get; set; }
        public virtual bool IsOfferable { get; set; }
        public virtual bool IsSold { get; set; }
    }
}