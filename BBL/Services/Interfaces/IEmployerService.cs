using BBL.BusinessModels;
using BBL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IEmployerService
    {
        Task<Response<List<CreateProductDTO>>> Create(ProductDTO productDTO);

        Task<Response<List<ProductDTO>>> Delete(ProductDTO productDTO);

        Task<Response<List<ProductDTO>>> Update(ProductDTO productDTO);
    }
}
