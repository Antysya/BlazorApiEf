﻿using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Entites;

namespace ServerDb.Controllers
{
    [Route("api/products")]
   // [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepo;
        public ProductController(IProductRepository dbContext) {
            productRepo = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<Product> GetProducts(int id,CancellationToken cancellationToken)
        {
            return await productRepo.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task Add([FromBody]Product product, CancellationToken cancellationToken)
        {
            await productRepo.Add(product, cancellationToken);
            
        }
    }
}
