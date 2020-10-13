using API.Interfaces;
using System;

namespace API.Entities
{
    public class Product: IProductExpiration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Expiration { get; set; }
        public int Type { get; set; }
    }
}
