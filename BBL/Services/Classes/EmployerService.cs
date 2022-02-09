using AutoMapper;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class EmployerService : IEmployerService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public EmployerService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Response<List<CreateProductDTO>>> Create(CreateProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var response = new Response<List<CreateProductDTO>>()
            {
                Data = _mapper.Map<List<CreateProductDTO>>(_context.Products.ToList()),
            };

            return response;
        }

        public async Task<Response<List<ProductDTO>>> DeleteByName(string name)
        {
            var response = new Response<List<ProductDTO>>();

            var product = _context.Products.Where(x => x.Name == name).SingleOrDefault();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            if (product == null)
            {
                response.Message = "This product does not exist";
            }
            response.Data = _mapper.Map<List<ProductDTO>>(_context.Products.ToList());

            return response;
        }

        public async Task<Response<List<ProductDTO>>> Update(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            var response = new Response<List<ProductDTO>>()
            {
                Data = _mapper.Map<List<ProductDTO>>(_context.Products.ToList()),
            };

            return response;
        }
    }
}
