using BBL.DTO;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IEmployerService
    {
        Task Create(ProductDTO productDTO);

        Task Delete(ProductDTO productDTO);

        Task Update(ProductDTO productDTO);
    }
}
