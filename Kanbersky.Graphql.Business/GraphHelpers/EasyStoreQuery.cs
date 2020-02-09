using GraphQL.Types;
using Kanbersky.Graphql.Business.GraphTypes;
using Kanbersky.Graphql.Data.Concrete.EntityFramework.GenericRepository;
using Kanbersky.Graphql.Entities.Concrete;

namespace Kanbersky.Graphql.Business.GraphHelpers
{
    public class EasyStoreQuery : ObjectGraphType
    {
        public EasyStoreQuery(IGenericRepository<Category> categoryRepository, IGenericRepository<Product> productRepository)
        {
            Field<CategoryType>("category", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Category Id" }),
                resolve: ctx => categoryRepository.Get(t=>t.Id == ctx.GetArgument("id",0)).Result
                );

            Field<ProductType>("product", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Product Id" }),
                resolve: ctx => productRepository.Get(t => t.Id == ctx.GetArgument("id",0)).Result
                );
        }
    }
}
