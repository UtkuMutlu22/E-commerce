namespace ProductWriteRepository.Test
{
    using E_Commerce.Application.Repository;
    using E_Commerce.Domain.Entities;
    using Moq;

    /// <summary>
    /// Contains unit tests for the <see cref="IProductWriteRepository"/> interface using Moq.
    /// </summary>
    public class ProductWriteRepository
    {
        private readonly Mock<IProductWriteRepository> _productWriteRepositoryMock;
        private readonly Product _testProduct;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductWriteRepository"/> class.
        /// </summary>
        public ProductWriteRepository()
        {
            this._productWriteRepositoryMock = new Mock<IProductWriteRepository>();
            this._testProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Price = 100,
                Stock = 10,
            };
        }

        /// <summary>
        /// Tests that AddAsync returns true when a product entity is added asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task AddAsyncShouldReturnTrueWhenEntityIsAddedAsync()
        {
            // Arrange
            this._productWriteRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(true);

            // Act
            var result = await this._productWriteRepositoryMock.Object.AddAsync(this._testProduct);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that AddRangeAsync returns true when multiple product entities are added.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task AddRangeAsyncShouldReturnTrueWhenEntitiesAreAddedAsync()
        {
            // Arrange
            var products = new List<Product>
                    {
                        new () { Id = Guid.NewGuid(), Name = "Product 1", Price = 50, Stock = 5 },
                        new () { Id = Guid.NewGuid(), Name = "Product 2", Price = 75, Stock = 3 },
                    };
            this._productWriteRepositoryMock.Setup(repo => repo.AddRangeAsync(It.IsAny<IEnumerable<Product>>())).ReturnsAsync(true);

            // Act
            var result = await this._productWriteRepositoryMock.Object.AddRangeAsync(products);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that RemoveAsync returns true when a product entity exists and is removed.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task RemoveAsyncShouldReturnTrueWhenEntityExistsAsync()
        {
            // Arrange
            this._productWriteRepositoryMock.Setup(repo => repo.RemoveAsync("1")).ReturnsAsync(true);

            // Act
            var result = await this._productWriteRepositoryMock.Object.RemoveAsync("1");

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that RemoveRange returns true when multiple product entities exist and are removed.
        /// </summary>
        [Fact]
        public void RemoveRangeShouldReturnTrueWhenEntitiesExist()
        {
            // Arrange
            var products = new List<Product> { this._testProduct };
            this._productWriteRepositoryMock.Setup(repo => repo.RemoveRange(products)).Returns(true);

            // Act
            var result = this._productWriteRepositoryMock.Object.RemoveRange(products);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that Update returns true when a valid product entity is updated.
        /// </summary>
        [Fact]
        public void UpdateShouldReturnTrueWhenEntityIsValid()
        {
            // Arrange
            this._productWriteRepositoryMock.Setup(repo => repo.Update(this._testProduct)).Returns(true);

            // Act
            var result = this._productWriteRepositoryMock.Object.Update(this._testProduct);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that UpdateRange returns true when multiple valid product entities are updated.
        /// </summary>
        [Fact]
        public void UpdateRangeShouldReturnTrueWhenEntitiesAreValid()
        {
            // Arrange
            var products = new List<Product> { this._testProduct };
            this._productWriteRepositoryMock.Setup(repo => repo.UpdateRange(products)).Returns(true);

            // Act
            var result = this._productWriteRepositoryMock.Object.UpdateRange(products);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that Save does not throw an exception.
        /// </summary>
        [Fact]
        public async Task SaveShouldNotThrowException()
        {
            // Arrange
            _productWriteRepositoryMock.Setup(repo => repo.SaveAsync()).Returns(Task.CompletedTask);

            // Act
            var exception = await Record.ExceptionAsync(() => _productWriteRepositoryMock.Object.SaveAsync());

            // Assert
            Assert.Null(exception);
        }

    }
}
