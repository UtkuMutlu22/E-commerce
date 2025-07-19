using E_Commerce.Application.Repository;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistance.Concretes;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace ProductWriteRepository.Test
{
    public class ProductWriteRepository
    {
        private readonly Mock<IProductWriteRepository> _productWriteRepositoryMock;
        private readonly Product _testProduct;

        public ProductWriteRepository()
        {
            _productWriteRepositoryMock = new Mock<IProductWriteRepository>();
            _testProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Price = 100,
                Stock = 10
            };
        }

        [Fact]
        public async Task AddAsync_ShouldReturnTrue_WhenEntityIsAdded()
        {
            // Arrange
            _productWriteRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(true);

            // Act
            var result = await _productWriteRepositoryMock.Object.AddAsync(_testProduct);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public async Task AddRangeAsync_ShouldReturnTrue_WhenEntitiesAreAdded()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Product 1", Price = 50, Stock = 5 },
                new Product { Id = Guid.NewGuid(), Name = "Product 2", Price = 75, Stock = 3 }
            };
            _productWriteRepositoryMock.Setup(repo=>repo.AddRangeAsync(It.IsAny<IEnumerable<Product>>())).ReturnsAsync(true);

            // Act
            var result = await _productWriteRepositoryMock.Object.AddRangeAsync(products);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnTrue_WhenEntityExists()
        {
            // Arrange
            _productWriteRepositoryMock.Setup(repo => repo.RemoveAsync("1")).ReturnsAsync(true);

            // Act
            var result = await _productWriteRepositoryMock.Object.RemoveAsync("1");

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void RemoveRange_ShouldReturnTrue_WhenEntitiesExist()
        { 
            // Arrange
            var products = new List<Product> { _testProduct };
            _productWriteRepositoryMock.Setup(repo => repo.RemoveRange(products)).Returns(true);
           
            // Act
            var result = _productWriteRepositoryMock.Object.RemoveRange(products);
            
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_ShouldReturnTrue_WhenEntityIsValid()
        {
            // Arrange
            _productWriteRepositoryMock.Setup(repo => repo.Update(_testProduct)).Returns(true);

            // Act
            var result = _productWriteRepositoryMock.Object.Update(_testProduct);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateRange_ShouldReturnTrue_WhenEntitiesAreValid()
        {
            // Arrange
            var products = new List<Product> { _testProduct };
            _productWriteRepositoryMock.Setup(repo => repo.UpdateRange(products)).Returns(true);

            // Act
            var result = _productWriteRepositoryMock.Object.UpdateRange(products);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Save_ShouldNotThrowException()
        {
            // Arrange
            _productWriteRepositoryMock.Setup(repo => repo.Save());

            // Act
            var exception = Record.Exception(() => _productWriteRepositoryMock.Object.Save());

            // Assert
            Assert.Null(exception);
        }
    }
}