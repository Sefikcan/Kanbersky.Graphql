using GraphQL.Types;
using Kanbersky.Graphql.Data.Concrete.EntityFramework.GenericRepository;
using Kanbersky.Graphql.Entities.Concrete;

namespace Kanbersky.Graphql.Business.GraphTypes
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(IGenericRepository<Category> categoryRepository)
        {
            Field(t => t.Id).Description("Product Id.");
            Field(t => t.Name).Description("Product Name.");
            Field(t => t.Description, nullable: true).Description("Product Description.");
            Field(t => t.Price).Description("Product Price.");

            Field<CategoryType>("category", resolve: ctx => categoryRepository.Get(x=>x.Id == ctx.Source.Id).Result);
        }
    }
}
