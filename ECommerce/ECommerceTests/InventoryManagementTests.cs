using ECommerce.Models;
using ECommerce.Models.Interfaces;
using ECommerce.Models.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceTests
{
    public class InventoryManagementTests : DatabaseTests
    {
        private IProducts BuildService()
        {
            return new InventoryManagement(_db);
        }

        [Fact]
        public async Task CanUpdateAProduct()
        {
            var service = BuildService();
            var product = new Products
            {
                Id = 1,
                Name = "Dell Inspiron",
                Price = 179.00M
            };
            await service.Update(product);
            var result = await service.GetProduct(product.Id);
            Assert.NotNull(result);
            Assert.Equal(product.Id, result.Id);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Price, result.Price);
        }

        // based on seeded data
        [Fact]
        public async Task CanDeleteAProduct()
        {
            var service = BuildService();
            await service.Delete(1);

            var result = await service.GetProducts();

            Assert.NotNull(result);
            Assert.Equal(9, result.Count);
        }

        [Fact]
        public async void CanGetProduct()
        {
            var service = BuildService();

            var expected = "Intel core i9";
            var returnFromMethod = await service.GetProduct(1);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod.Name);
        }

        [Fact]
        public async Task CanGetProducts()
        {
            // arrange
            var repo = BuildService();
            // act
            var result = await repo.GetProducts();
            // assert
            Assert.NotNull(result);
            Assert.Equal(10, result.Count);
        }
    }
}