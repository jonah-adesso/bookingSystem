using api.Entities;
using Microsoft.AspNetCore.Identity;

namespace api.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(StoreContext context, UserManager<User> userManager)
        {
            // Create one admin and one user member
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "user",
                    Email = "user@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
            }

            int boardsCategoryId = 0;
            int hatsCategoryId = 0;
            int glovesCategoryId = 0;
            int bootsCategoryId = 0;
            if (!context.Categories.Any())
            {
                AddCategories(context, out boardsCategoryId, out hatsCategoryId, out glovesCategoryId, out bootsCategoryId);
            }

            int burtonBrandId = 0;
            int k2BrandId = 0;
            int arborBrandId = 0;
            int nitroBrandId = 0;
            if (!context.Brands.Any())
            {
                AddBrands(context, out burtonBrandId, out k2BrandId, out arborBrandId, out nitroBrandId);
            }

            if (!context.Products.Any())
            {
                AddProducts(context, boardsCategoryId, hatsCategoryId, glovesCategoryId, bootsCategoryId, burtonBrandId, k2BrandId, arborBrandId, nitroBrandId);
            }

            context.SaveChanges();

        }

        private static void AddProducts(StoreContext context, int boardsCategoryId, int hatsCategoryId, int glovesCategoryId, int bootsCategoryId, int burtonBrandId, int k2BrandId, int arborBrandId, int nitroBrandId)
        {
            var products = new List<Product>{
                new Product
                    {
                        Name = "Burton Speeder Board",
                        CategoryId = boardsCategoryId,
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 20000,
                        PictureUrl = "/images/products/sb-ang1.png",
                        BrandId = burtonBrandId,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "K2 Cool Board",
                        CategoryId = boardsCategoryId,
                        Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                        Price = 15000,
                        PictureUrl = "/images/products/sb-ang2.png",
                        BrandId = k2BrandId,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Arbor snowboard",
                        CategoryId = boardsCategoryId,
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 18000,
                        PictureUrl = "/images/products/sb-core1.png",
                        BrandId = arborBrandId,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Nitro neat snowboard",
                        CategoryId = boardsCategoryId,
                        Description =
                            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 30000,
                        PictureUrl = "/images/products/sb-core2.png",
                        BrandId = nitroBrandId,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "K2 Board Super Whizzy Fast",
                        CategoryId = boardsCategoryId,
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 25000,
                        PictureUrl = "/images/products/sb-react1.png",
                        BrandId = k2BrandId,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Arbor Entry Board",
                        CategoryId = boardsCategoryId,
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 12000,
                        PictureUrl = "/images/products/sb-ts1.png",
                        BrandId = arborBrandId,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Burton Blue Hat",
                        CategoryId = hatsCategoryId,
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 1000,
                        PictureUrl = "/images/products/hat-core1.png",
                        BrandId = burtonBrandId,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Nitro Green React Woolen Hat",
                        CategoryId = hatsCategoryId,
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 8000,
                        PictureUrl = "/images/products/hat-react1.png",
                        BrandId = nitroBrandId,
                        QuantityInStock = 3
                    },
                    new Product
                    {
                        Name = "K2 Purple React Woolen Hat",
                        CategoryId = hatsCategoryId,
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 1500,
                        PictureUrl = "/images/products/hat-react2.png",
                        BrandId = k2BrandId,
                        QuantityInStock = 59
                    },
                    new Product
                    {
                        Name = "Nitro Blue Code Gloves",
                        CategoryId = glovesCategoryId,
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 1800,
                        PictureUrl = "/images/products/glove-code1.png",
                        BrandId = nitroBrandId,
                        QuantityInStock = 89
                    },
                    new Product
                    {
                        Name = "K2 Green Code Gloves",
                        CategoryId = glovesCategoryId,
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 1500,
                        PictureUrl = "/images/products/glove-code2.png",
                        BrandId = k2BrandId,
                        QuantityInStock = 34
                    },
                    new Product
                    {
                        Name = "Nitro Purple React Gloves",
                        CategoryId = glovesCategoryId,
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 1600,
                        PictureUrl = "/images/products/glove-react1.png",
                        BrandId = nitroBrandId,
                        QuantityInStock = 12
                    },
                    new Product
                    {
                        Name = "Arbor Green React Gloves",
                        CategoryId = glovesCategoryId,
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 1400,
                        PictureUrl = "/images/products/glove-react2.png",
                        BrandId = arborBrandId,
                        QuantityInStock = 1
                    },
                    new Product
                    {
                        Name = "Arbor Red Boots",
                        CategoryId = bootsCategoryId,
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 25000,
                        PictureUrl = "/images/products/boot-redis1.png",
                        BrandId = arborBrandId,
                        QuantityInStock = 34
                    },
                    new Product
                    {
                        Name = "Burton Core Red Boots",
                        CategoryId = bootsCategoryId,
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 18999,
                        PictureUrl = "/images/products/boot-core2.png",
                        BrandId = burtonBrandId,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "K2 Core Purple Boots",
                        CategoryId = bootsCategoryId,
                        Description =
                            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 19999,
                        PictureUrl = "/images/products/boot-core1.png",
                        BrandId = k2BrandId,
                        QuantityInStock = 5
                    },
                    new Product
                    {
                        Name = "Arbor Purple Boots",
                        CategoryId = bootsCategoryId,
                        Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                        Price = 15000,
                        PictureUrl = "/images/products/boot-ang2.png",
                        BrandId = arborBrandId,
                        QuantityInStock = 8
                    },
                    new Product
                    {
                        Name = "Nitro Blue Boots",
                        CategoryId = bootsCategoryId,
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 18000,
                        PictureUrl = "/images/products/boot-ang1.png",
                        BrandId = nitroBrandId,
                        QuantityInStock = 4
                    },
                };
            context.Products.AddRange(products);
        }

        private static void AddBrands(StoreContext context, out int burtonBrandId, out int k2BrandId, out int arborBrandId, out int nitroBrandId)
        {
            // Add Burton brand
            var burtonBrand = new Brand
            {
                Name = "Burton",
                Description = "Burton boards"
            };
            context.Brands.Add(burtonBrand);
            context.SaveChanges();
            burtonBrandId = burtonBrand.Id;

            // Add K2 brand
            var k2Brand = new Brand
            {
                Name = "K2",
                Description = "K2 Snowboard stuff"
            };
            context.Brands.Add(k2Brand);
            context.SaveChanges();
            k2BrandId = k2Brand.Id;

            // Add arbor brand
            var arborBrand = new Brand
            {
                Name = "Arbor",
                Description = "Arbor Collective Snowboards"
            };
            context.Brands.Add(arborBrand);
            context.SaveChanges();
            arborBrandId = arborBrand.Id;

            // Add nitro brand
            var nitroBrand = new Brand
            {
                Name = "Nitro",
                Description = "Nitro, welcome to the team"
            };
            context.Brands.Add(nitroBrand);
            context.SaveChanges();
            nitroBrandId = nitroBrand.Id;
        }

        private static void AddCategories(StoreContext context, out int boardsCategoryId, out int hatsCategoryId, out int glovesCategoryId, out int bootsCategoryId)
        {
            // Add boards category
            var boardsCategory = new Category
            {
                Name = "Boards",
                Description = "Boards category description"
            };
            context.Categories.Add(boardsCategory);
            context.SaveChanges();
            boardsCategoryId = boardsCategory.Id;

            // Add hats category
            var hatsCategory = new Category
            {
                Name = "Hats",
                Description = "Hats category description"
            };
            context.Categories.Add(hatsCategory);
            context.SaveChanges();
            hatsCategoryId = hatsCategory.Id;

            // Add gloves category
            var glovesCategory = new Category
            {
                Name = "Gloves",
                Description = "Gloves category description"
            };
            context.Categories.Add(glovesCategory);
            context.SaveChanges();
            glovesCategoryId = glovesCategory.Id;

            // Add boots category
            var bootsCategory = new Category
            {
                Name = "Boots",
                Description = "Boots category description"
            };
            context.Categories.Add(bootsCategory);
            context.SaveChanges();
            bootsCategoryId = bootsCategory.Id;
        }

    }
}