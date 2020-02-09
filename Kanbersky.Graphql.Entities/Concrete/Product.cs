using Kanbersky.Graphql.Core.Entities;
using Kanbersky.Graphql.Entities.Abstract;

namespace Kanbersky.Graphql.Entities.Concrete
{
    public class Product : BaseEntity,IEntity
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public Category Category { get; set; }
    }
}
