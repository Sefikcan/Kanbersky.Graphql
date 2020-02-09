using GraphQL.Types;
using Kanbersky.Graphql.Data.Concrete.EntityFramework.GenericRepository;
using Kanbersky.Graphql.Entities.Concrete;
using System.Linq;

namespace Kanbersky.Graphql.Business.GraphTypes
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IGenericRepository<Product> productRepository)
        {
            Field(s => s.Id).Description("Category Id.");
            Field(s => s.Name, nullable: true).Description("Category Name.");

            Field<ListGraphType<ProductType>>("products", resolve: ctx => productRepository.GetList(x=>x.CategoryId == ctx.Source.Id).Result.ToList());
        }
    }
}
