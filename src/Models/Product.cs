using System;

namespace BackendBot.Models
{
    [Serializable]
    public class Product
    {
        //test
        public virtual int ProductId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Disabled { get; set; }
        public virtual string Image { get; set; }
    }
}