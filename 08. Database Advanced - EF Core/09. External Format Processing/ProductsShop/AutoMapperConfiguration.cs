using System.Linq;
using AutoMapper;
using ProductsShop.Models;
using ProductsShop.Models.DTOs;

namespace ProductsShop.App
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserDto, User>();

                cfg.CreateMap<ProductDto, Product>();

                cfg.CreateMap<CategoryProductDto, CategoryProduct>();

                cfg.CreateMap<CategoryDto, Category>();

                cfg.CreateMap<Product, ProductWithSellerFullNameDto>()
                    .ForMember(dest => dest.SellerName,
                        opt => opt.MapFrom(src => src.Seller.FirstName + " " + src.Seller.LastName));

                cfg.CreateMap<Product, ProductWithBuyerFirstAndLastNameDto>()
                    .ForMember(dest => dest.BuyerFirstName,
                        opt => opt.MapFrom(src => src.Buyer.FirstName))
                    .ForMember(dest => dest.BuyerLastName,
                        opt => opt.MapFrom(src => src.Buyer.LastName));

                cfg.CreateMap<User, UserWithSoldProductsAndBuyerInfoDto>();

                cfg.CreateMap<Category, CategoryByProductDto>()
                    .ForMember(dest => dest.ProductsCount,
                        opt => opt.MapFrom(src => src.CategoryProducts.Count))
                    .ForMember(dest => dest.AveragePrice,
                        opt => opt.MapFrom(src => src.CategoryProducts.Average(cp => cp.Product.Price)))
                    .ForMember(dest => dest.TotalRevenue,
                        opt => opt.MapFrom(src => src.CategoryProducts.Sum(cp => cp.Product.Price)));
                
                cfg.CreateMap<User, UserWithSoldProductsCount>();

                cfg.CreateMap<Product, ProductWithBuyerFullName>()
                    .ForMember(dest => dest.BuyerName,
                        opt => opt.MapFrom(src => src.Seller.FirstName + " " + src.Seller.LastName));
            });
        }
    }
}
