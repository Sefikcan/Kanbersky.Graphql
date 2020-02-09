using GraphQL.Types;
using System;

namespace Kanbersky.Graphql.Business.GraphHelpers
{
    public class EasyStoreSchema : Schema
    {
        public EasyStoreSchema(Func<Type, GraphType> resolveType)
        {
            Query = (EasyStoreQuery)resolveType(typeof(EasyStoreQuery));
        }
    }
}
