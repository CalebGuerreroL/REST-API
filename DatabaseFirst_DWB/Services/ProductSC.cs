using DatabaseFirst_DWB.DataAccess;
using DatabaseFirst_DWB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_DWB.Services
{
    public class ProductSC : BaseSC, IActions<Product, ProductDTO, int>
    {
        public void Add(ProductDTO obj)
        {
            try
            {
                var newProduct = new Product()
                {
                    ProductName = obj.Product,
                    UnitPrice = obj.Price,
                    QuantityPerUnit = obj.QuantityPerProduct,
                    UnitsInStock = obj.InStock
                };

                dataContext.Add(newProduct);
                dataContext.SaveChanges();
            }
            catch(Exception)
            {
                Console.WriteLine("Hubo un error tratando de agregar el producto");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var product = Get(id);
                dataContext.Products.Remove(product);
                dataContext.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrió un error al interntar borrar el usuario.");
            }
        }

        public Product Get(int id)
        {
            var product = GetAll().FirstOrDefault(fd => fd.ProductId == id);

            if (product == null)
                throw new ArgumentException($"El empleado con el id: {id} no fue encontrado");

            return product;
        }

        public IQueryable<Product> GetAll()
        {
            return dataContext.Products;
        }

        public void Update(int id, ProductDTO obj)
        {
            try
            {
                var product = Get(id);

                product.ProductName = obj.Product ?? product.ProductName;
                product.UnitPrice = obj.Price ?? product.UnitPrice;
                product.UnitsInStock = obj.InStock ?? product.UnitsInStock;
                product.QuantityPerUnit = obj.QuantityPerProduct ?? product.QuantityPerUnit;

                dataContext.Update(product);
                dataContext.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrió un error al guardar los cambios");
            }
        }
    }
}
