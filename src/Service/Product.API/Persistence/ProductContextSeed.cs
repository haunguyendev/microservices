﻿using Product.API.Entities;

namespace Product.API.Persistence
{
    public class ProductContextSeed
    {
        public static async Task SeedProductAsync(ProductContext productContext,Serilog.ILogger logger)
        {
            if (!productContext.Products.Any())
            {
                productContext.AddRange(getCatalogProducts());
                await productContext.SaveChangesAsync();
                logger.Information("Seeded data for product DB associated with context {DbContextName}", nameof(ProductContext));

            }
        }
        private static IEnumerable<CatalogProduct> getCatalogProducts()
        {
            return new List<CatalogProduct>
            {
                new()
                {
                    No="Lotus",
                    Name="Esprit",
                    Summary="Nondisplaced fracture of greater trochanter of right femur",
                    Description="Nondisplaced fracture of greater trochanter of right femur",
                    Price=(decimal)177940.49
                },
                new()
                {

                    No="Cadillac",
                    Name="CTS",
                    Summary="Nondisplaced fracture of greater trochanter of right femur",
                    Description="Nondisplaced fracture of greater trochanter of right femur",
                    Price=(decimal)144940.49
                }
            };
        }
    }
}
