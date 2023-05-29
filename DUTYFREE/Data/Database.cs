﻿using Dapper;
using DUTYFREE.Models.Products;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DUTYFREE.Data
{
    public static class Database
    { 
        internal static string connectionString = "Data Source=.;Initial Catalog=dutyfree.db;Integrated Security=True;TrustServerCertificate=True;";

        public static Product GetProductById(int productId)
        {
            using(IDbConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductID = @ProductId";
                var parameters = new { ProductId = productId };
                return db.QueryFirstOrDefault<Product>(query, parameters);
            }
        }

        public static int GetProductId(int productId)
        {
            using (var db = new SqlConnection(connectionString))
            {
                string query = "EXEC ProcGetProductById @ProductId";
                var parameters = new { ProductId = productId };
                return db.QueryFirstOrDefault<int>(query, parameters);
            }
        }

        public static IEnumerable<Product> GetProducts()
        {
            using (var db = new SqlConnection(connectionString))
            {
                string query = "EXEC ProcProducts";
                return db.Query<Product>(query);
            }
        }

        public static void InsertProduct(string name, string imageUrl, int quantity, decimal price)
        {
            using (var db = new SqlConnection(connectionString))
            {
                string query = "EXEC ProcProductInsert @Name, @ImageUrl, @Quantity, @Price";
                var parameters = new { Name = name, ImageUrl = imageUrl, Quantity = quantity, Price = price };
                db.Execute(query, parameters);
            }
        }

        public static void EditProduct(int productId, string name, string imageUrl, int quantity, decimal price)
        {
            using (var db = new SqlConnection(connectionString))
            {
                string query = "EXEC ProcProductEdit @ProductId, @Name, @ImageUrl, @Quantity, @Price";
                var parameters = new { ProductId = productId, Name = name, ImageUrl = imageUrl, Quantity = quantity, Price = price };
                db.Execute(query, parameters);
            }
        }

        public static void DeleteProduct(int productId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = "EXEC ProcProductDelete @ProductId";
                var parameters = new { ProductId = productId };
                db.Execute(query, parameters);
            }
        }
    }
}