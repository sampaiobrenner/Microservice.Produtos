using Newtonsoft.Json.Linq;

namespace Microservice.Produtos.WebApi.GraphQL.GraphQLQueries
{
    public class GraphQLQuery
    {
        public string NamedQuery { get; set; }
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}