using MySql.Data.MySqlClient;

namespace WpfProducts
{
    public class MySQLConnaction
    {
        private string _path_dateBase = "Server=localhost;Database=test;Uid=root;Pwd=root;";
        public MySqlConnection connaction { get; private set; }

        public MySQLConnaction()
        {
            connaction = new MySqlConnection(_path_dateBase);
        }
    }
}
