using AutoMapper;
using Microservice.Produtos.Entities.Entities;
using Microservice.Produtos.Services.Models;

namespace Microservice.Produtos.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoModel>().ReverseMap();
            CreateMap<CategoriaDoProduto, CategoriaDoProdutoModel>().ReverseMap();
        }
    }
}