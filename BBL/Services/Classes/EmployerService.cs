using AutoMapper;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class EmployerService : IEmployerService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public async Task Create(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(ProductDTO productDTO)
        {
            var product = _context.Products.Where(x => x.Id == productDTO.Id).SingleOrDefault();

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task Update(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            _context.Products.Update(product);

            await _context.SaveChangesAsync();
        }
    

        public EmployerService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
