using Newtonsoft.Json.Linq;

namespace Microservice.Produtos.WebApi.Queries
{
    public class GraphQLQuery
    {
        public string NamedQuery { get; set; }
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}