using BBL.BusinessModels;
using BBL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IEmployerService
    {
        Task<Response<List<CreateProductDTO>>> Create(CreateProductDTO createProductDTO);

        Task<Response<List<ProductDTO>>> DeleteByName(string name);

        Task<Response<List<ProductDTO>>> Update(ProductDTO productDTO);
    }
}
