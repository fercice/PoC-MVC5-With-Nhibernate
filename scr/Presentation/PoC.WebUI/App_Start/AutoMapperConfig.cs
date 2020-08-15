namespace PoC.WebUI
{
    using PoC.Domain.Entities;
    using PoC.WebUI.ViewModel;

    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize((config) =>
            {
                config.CreateMap<ClienteViewModel, Cliente>().ReverseMap();
                config.CreateMap<CompraViewModel, Compra>().ReverseMap();
                config.CreateMap<ProdutoViewModel, Produto>().ReverseMap();
            });
        }
    }
}