

using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile // AutoMapper kullanırken Profile sınıfından miras alınır.
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>() // Map yapılırken Product sınıfı ile map yapılacak Dto sınıfı bu şekilde CreateMap fonksiyonu ile Maplenir.
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name)) 
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name)) //Bu kod satırı ile mapleme yaparken ilişkili veritabanı verilerinin ismini çekmiş oluyoruz. Normalde Product classında ProductBrand tipinde olan veriyi string olarak maplediğimiz için veri adını alamıyorduk.
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}