using Store.G04.Domain.Entities;
using Store.G04.Repository.Data.Contexts;
using System.Text.Json;

namespace Store.G04.Repository.Data
{
    public static class StoreDbContextSeed
    {
        public async static Task SeedAsync(StoreDbContext _context)
        {

            if (_context.Brands.Count() == 0)
            {
                //Brand
                //1.Read Data from Json File

                var brandsData = File.ReadAllText(@"..\Store.G04.Repository\Data\DataSeed\brands.json ");
                //2.Convert json string to List<T>

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                //3.Seed Data to Database

                if (brands is not null && brands.Count() > 0)
                {
                    await _context.Brands.AddRangeAsync(brands);
                }

            }
            if (_context.Types.Count() == 0)
            {
                //Types 
                //Read the data from json file
                var typesData = await File.ReadAllTextAsync(@"..\Store.G04.Repository\Data\DataSeed\types.json");

                //2.Convert from json to List<T>
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                //Add(Seed) Data to Db
                if (types is not null && types.Count() > 0)
                {
                    await _context.Types.AddRangeAsync(types);
                }

            }
            if (_context.Products.Count() == 0)
            {
                var productData = await File.ReadAllTextAsync(@"..\Store.G04.Repository\Data\DataSeed\products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productData);

                if (products is not null && products .Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                }

            }
            await _context.SaveChangesAsync();


        }
    }
}
