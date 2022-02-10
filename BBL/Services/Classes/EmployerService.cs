using AutoMapper;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using System;
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

        public async Task<Response<List<ProductDTO>>> Create(CreateProductDTO productDTO)
        {
            var response = new Response<List<ProductDTO>>();

            var product = _context.Products.Where(x => x.Name == productDTO.Name).SingleOrDefault();

            if (product != null)
            {
                response.Message = "This product alredy exist";
                response.Success = false;

                return response;
            }

            product = _mapper.Map<Product>(productDTO);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<List<ProductDTO>>(_context.Products.ToList());

            return response;
        }

        public async Task<Response<List<ProductDTO>>> DeleteByName(string name)
        {
            var response = new Response<List<ProductDTO>>();

            var product = _context.Products.Where(x => x.Name == name).SingleOrDefault();

            if (product == null)
            {
                response.Message = "This product does not exist";
                response.Success = false;

                return response;
            }

            await _context.Orders.AddAsync(new Order() { Date = DateTime.Now, Products = new List<Product>() { product } });
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<List<ProductDTO>>(_context.Products.ToList());

            return response;
        }

        public async Task<Response<List<ProductDTO>>> Update(ProductDTO productDTO)
        {
            var response = new Response<List<ProductDTO>>();

            if (!_context.Products.Any(x => x.Id == productDTO.Id))
            {
                response.Message = "This product does not exist";
                response.Success = false;

                return response;
            }

            _context.Products.Update(_mapper.Map<Product>(productDTO));
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<List<ProductDTO>>(_context.Products.ToList());

            return response;
        }
    }
}
