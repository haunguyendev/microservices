using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using Product.API.Persistence;
using Product.API.Repositories.Interface;

namespace Product.API.Repositories
{
    public class ProductRepositoy : RepositoryBaseAsync<CatalogProduct, long, ProductContext>, IProductRepository
    {
        public ProductRepositoy(ProductContext dbContext, IUnitOfWork<ProductContext> unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public async Task CreateProduct(CatalogProduct product)
        {
            await CreateAsync(product);
        }

        public async Task DeleteProduct(long id)
        {
            var product = await GetProduct(id);
            if (product != null) DeleteAsync(product);
        }

        public async Task<CatalogProduct> GetProduct(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<CatalogProduct> GetProductByNo(string productNo)
        {
            return await FindByCondition(x => x.No.Equals(productNo)).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CatalogProduct>> GetProducts()
        {
            return await FindAll().ToListAsync();
        }

        public async Task UpdateProduct(CatalogProduct product)
        {
            await UpdateAsync(product);
        }
    }
}
