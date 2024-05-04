using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Driver;
using Shopping.API.Models;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public IMongoCollection<Product> Products { get; }

        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["ProductDatabase:ConnectionString"]);
            var database = client.GetDatabase(configuration["ProductDatabase:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["ProductDatabase:ProductsCollectionName"]);
            SeedData(Products);
        }

        private void SeedData(IMongoCollection<Product> productCollection)
        {
            bool dataExist = productCollection.Find(p => true).Any();

            if (!dataExist)
            {
                productCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>() {
                    new Product()
                        {
                            Name = "IPhone X",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-1.png",
                            Summary= "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            Price = 950.00M,
                            Category = "Smart Phone"
                        },
                        new Product()
                        {
                            Name = "Samsung 10",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-2.png",
                            Price = 840.00M,
                            Summary  = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            Category = "Smart Phone"
                        },
                        new Product()
                        {
                            Name = "Huawei Plus",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                           ImageFile = "product-3.png",
                            Price = 650.00M,
                            Category = "White Appliances"
                        },
                        new Product()
                        {
                            Name = "Xiaomi Mi 9",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-4.png",
                            Price = 470.00M,
                            Category = "White Appliances"
                        },
                        new Product()
                        {
                            Name = "HTC U11+ Plus",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-5.png",
                            Price = 380.00M,
                            Category = "Smart Phone"
                        },
                        new Product()
                        {
                            Name = "LG G7 ThinQ EndofCourse",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-6.png",
                            Price = 240.00M,
                            Category = "Home Kitchen"
                        }

            };
        }



        //public static readonly List<Product> Products = new List<Product>
        //{
        //    new Product()
        //        {
        //            Name = "IPhone X",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-1.png",
        //            Price = 950.00M,
        //            Category = "Smart Phone"
        //        },
        //        new Product()
        //        {
        //            Name = "Samsung 10",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-2.png",
        //            Price = 840.00M,
        //            Category = "Smart Phone"
        //        },
        //        new Product()
        //        {
        //            Name = "Huawei Plus",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-3.png",
        //            Price = 650.00M,
        //            Category = "White Appliances"
        //        },
        //        new Product()
        //        {
        //            Name = "Xiaomi Mi 9",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-4.png",
        //            Price = 470.00M,
        //            Category = "White Appliances"
        //        },
        //        new Product()
        //        {
        //            Name = "HTC U11+ Plus",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-5.png",
        //            Price = 380.00M,
        //            Category = "Smart Phone"
        //        },
        //        new Product()
        //        {
        //            Name = "LG G7 ThinQ EndofCourse",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-6.png",
        //            Price = 240.00M,
        //            Category = "Home Kitchen"
        //        }
        //};
    }
}
