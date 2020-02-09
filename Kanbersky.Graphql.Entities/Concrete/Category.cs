using Kanbersky.Graphql.Core.Entities;
using Kanbersky.Graphql.Entities.Abstract;
using System.Collections.Generic;

namespace Kanbersky.Graphql.Entities.Concrete
{
    public class Category : BaseEntity,IEntity
    {
        public string Name { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
