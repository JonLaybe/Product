using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace WpfProducts.Model
{
    public class RequestsDatabase
    {
        private List<Product> products;
        private MySQLConnaction _connaction;

        public RequestsDatabase()
        {
            _connaction = new MySQLConnaction();
        }

        public int Delete(Product product)
        {
            string request = $"DELETE FROM products WHERE id = {product.id}";
            _connaction.connaction.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(request, _connaction.connaction);
            int delete_rows = mySqlCommand.ExecuteNonQuery();
            _connaction.connaction.Clone();

            return delete_rows;
        }
        public int Update(Product product)
        {
            string request = $"UPDATE products SET name='{product.name}', price='{product.price}', photo='{product.photo_path}',description='{product.description}' WHERE id = {product.id};";
            _connaction.connaction.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(request, _connaction.connaction);
            int update_rows = mySqlCommand.ExecuteNonQuery();
            _connaction.connaction.Clone();

            return update_rows;
        }
        public int Insert(Product products)
        {
            string request = $"INSERT INTO products(name, price, photo, description) VALUES ('{products.name}', '{products.price}', '{products.photo_path}', '{products.description}')";
            _connaction.connaction.Open();
            MySqlCommand mysqlCommand = new MySqlCommand(request, _connaction.connaction);
            int add_rows = mysqlCommand.ExecuteNonQuery();
            _connaction.connaction.Close();

            return add_rows;
        }
        public List<Product> Select()
        {
            products = new List<Product>();
            string request = "SELECT * FROM products WHERE 1";

            MySqlDataAdapter data = new MySqlDataAdapter(request, _connaction.connaction);
            DataTable data_table = new DataTable();
            try
            {
                data.Fill(data_table);

                for (int i = 0; i < data_table.Rows.Count; i++)
                {
                    products.Add(new Product()
                    {
                        id = (int)data_table.Rows[i][0],
                        name = data_table.Rows[i][1].ToString(),
                        price = (int)data_table.Rows[i][2],
                        photo_path = data_table.Rows[i][3].ToString(),
                        description = data_table.Rows[i][4].ToString()
                    });
                }
                return products;
            }
            catch(MySqlException)
            {
                return null;
            }
        }
    }
}
