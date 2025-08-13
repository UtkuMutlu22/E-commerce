using AutoFixture;
using AutoFixture.AutoMoq;

using E_Commerce.Application.Repository;
using E_Commerce.Application.ViewModels.Products;

using Xunit;

namespace E_Commerce.Test.Unit.Services.Repository
{
    public class ProductRepositoryTest
    {
        [Theory]
        [InlineData("Test Product", 10, 1)]
        public void AddSingleProduct_ShouldAddedTable(string name, decimal price, int stock)
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var createPRoductVM = fixture.Create<Vm_CreateProduct>();
            var sut = fixture.Create<IProductWriteRepository>();

            var result = sut.AddAsync(new Domain.Entities.Product() { Id = Guid.NewGuid(), Name = name, Price = price, Stock = stock, CreatedDate = DateTime.Now, UpdateDate = DateTime.Now, Orders = null }).Result;

            Assert.True(result);
        }
    }
}
