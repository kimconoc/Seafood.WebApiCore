using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Seafood.Application.Services.Common;
using Seafood.Data.Dtos;
using Seafood.Data.EF;
using Seafood.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Application.Services.Adresses
{
    public class ProductService : IGenericService<ProductVM ,ProductRequest>
    {
        private readonly IMapper _mapper;
        private readonly SeafoodDbcontext _context;

        public ProductService(IMapper mapper, SeafoodDbcontext context) 
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProductVM> Create(ProductRequest request)
        {
            var product = new Product();
            product =  _mapper.Map<Product>(request);
            product.IsDeleted = false;
            product.DeletedAt = DateTime.Now;
            product.DeletedBy = "admin";
            product.CreatedAt = DateTime.Now;
            product.CreatedBy = "admin";
            product.UpdatedAt = DateTime.Now;
            product.UpdatedBy = "admin";
            _context.Products.Add(product);
            _context.SaveChanges();

            return  new ProductVM()
            {
                CategoryCode = request.CategoryCode,
                ShopCode = request.ShopCode,
                Name = request.Name,
                Description = request.Description,
                ReviewProd = request.ReviewProd,
                Price = request.Price,
                PriceSale = request.PriceSale,
                Amount = request.Amount,
                Note = request.Note,
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (product == null) throw new Exception("Không tìm thấy sản phẩm");

            product.IsDeleted = true;
            _context.SaveChanges();

            return true;

        }

        public async Task<List<ProductVM>> GetAll()
        {
            var query = _context.Products.Where(p => p.IsDeleted == false).Select(prod => new ProductVM
            {
                Id = prod.Id,
                CategoryCode = prod.CategoryCode,
                ShopCode = prod.ShopCode,
                Name = prod.Name,
                Description = prod.Description,
                ReviewProd = prod.ReviewProd,
                Price = prod.Price,
                PriceSale = prod.PriceSale,
                Amount = prod.Amount,
                Note = prod.Note,
            });

            return await query.ToListAsync();
        }

        public async Task<bool> Update(Guid id, ProductRequest request)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (product == null) throw new Exception("Không tìm thấy sản phẩm");

            product.CategoryCode = request.CategoryCode;
            product.ShopCode = request.ShopCode;
            product.Name = request.Name;
            product.Description = request.Description;
            product.ReviewProd = request.ReviewProd;
            product.Price = request.Price;
            product.PriceSale = request.PriceSale;
            product.Amount = request.Amount;
            product.Note = request.Note;

            _context.Products.Update(product);
            _context.SaveChanges();

            return true;
        }
    }
}
