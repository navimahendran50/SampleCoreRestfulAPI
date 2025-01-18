using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Mappers
{
    public static class ProductMapper
    {
        public static Product ToProduct(this CreateProductRequestDto createProductRequestDto)
        {
            if(createProductRequestDto == null)
            {
                throw new ArgumentNullException(nameof(createProductRequestDto));
            }
            return new Product()
            {
                Name = createProductRequestDto.Name,
                Price = createProductRequestDto.Price
            };
        }
    }
}