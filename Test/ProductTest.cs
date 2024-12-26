using DevOps_Testing_Task.Data;
using DevOps_Testing_Task.Entities;
using DevOps_Testing_Task.Repositories.Abstracts;
using DevOps_Testing_Task.Repositories.Concretes;
using DevOps_Testing_Task.Services.Abstracts;
using DevOps_Testing_Task.Services.Concretes;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class ProductTest
    {
        private ProductDbContext _context;
        private IProductRepository _repository;
        private IProductService _service;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductTestingDB;Integrated Security=True;Trust Server Certificate=False")
            .Options;

            _context = new ProductDbContext(options);

            _repository = new ProductRepository(_context);
            _service = new ProductService(_repository);
            _context.Database.EnsureCreated();
            _context.Products.RemoveRange(_context.Products);
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Products.RemoveRange(_context.Products);
            _context.SaveChanges();

            _context.Dispose();
        }

        [Test]
        public async Task GetAllProductsAsync_ReturnsAllProducts()
        {
            // Arrange
            _context.Products.AddRange(new List<Product>
            {
                new Product { Name = "Cola",Description="drink cool",Quantity=22 },
                new Product { Name = "Lays",Description="so tasty",Quantity=7 },
            });
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.That(result != null);
            Assert.That(2, Is.EqualTo(result.Count()));

        }

        [Test]
        public async Task GetByIdProductsAsync_ReturnsProduct()
        {
            //Arrange
            _context.Products.AddRange(new List<Product>
            {
                new Product{ Name="Pepsi", Description="drink cool", Quantity=22 }
            });
            await _context.SaveChangesAsync();
            var product = _context.Products.FirstOrDefault();

            //Assert
            if (product != null)
            {
                var result = await _service.GetByIdAsync(product.Id);
                Assert.That(result != null);

                Assert.That(result.Id, Is.EqualTo(product.Id));

            }
        }

        [Test]
        public async Task DeleteProductsAsync_ReturnsResponse()
        {
            //Arrange
            _context.Products.AddRange(new List<Product>
            {
                new Product{ Name="Cola", Description="drink cool", Quantity=22 }
            });
            await _context.SaveChangesAsync();
            var product = _context.Products.FirstOrDefault();

            //Assert
            if (product != null)
            {
                var result = await _service.DeleteAsync(product.Id);
                Assert.That(result != false);

            }
        }

        [Test]
        public async Task AddProductsAsync_ReturnsResponse()
        {
            //Arrange
            var newProduct = new Product
            {
                Name = "Pepsi",
                Description = "drink cool",
                Quantity = 30,
            };

            //Act
            var result = await _service.AddAsync(newProduct);

            //Assert
            Assert.That(result != null);
        }

        [Test]
        public async Task UpdateProductsAsync_ReturnsResponse()
        {
            //Arrange
            _context.Products.AddRange(new List<Product>
            {
                new Product{ Name="Cola", Description="drink cool", Quantity=22 }
            });
            await _context.SaveChangesAsync();
            var product = _context.Products.FirstOrDefault();


            //Assert
            if (product != null)
            {
                product.Name = "Bizon";
                product.Description = "drink cool";
                product.Quantity = 22;

                var result = await _service.UpdateAsync(product);
                Assert.That(result != null);
                Assert.That(product.Id, Is.EqualTo(result.Id));
                Assert.That(product.Name, Is.EqualTo(result.Name));

            }
        }
    }
}
