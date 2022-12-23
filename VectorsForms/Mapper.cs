using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VectorsForms
{
    internal class Mapper
    {
        protected static DBConnection _connection = null;
        private string TableName;
        public Mapper(string tableName)
        {
            if (_connection == null)
            {
                _connection = new DBConnection(@"Data Source=DESKTOP-RQ1TD73\SQLEXPRESS;Initial Catalog=VectorsBase;Integrated Security=True");
            }
            TableName = tableName;
        }
        public LazyList SelectAll()
        {
            string query = $"SELECT * FROM {TableName}";
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            List<int> ret = new List<int>();

            _connection.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);                
                ret.Add(id);
            }
            reader.Close();
            _connection.closeConnection();
            Console.WriteLine($"Выполняется запрос {query}");

            return new LazyList(TableName,ret);
        }

        public void Insert(DomainObject obj)
        {
            string query = $"insert into {TableName}{obj.GetStringParams()} VALUES ({obj.GetStringParamsValues()})";

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            cmd.ExecuteNonQuery();
            _connection.closeConnection();
            Console.WriteLine($"Выполняется запрос {query}");

        }
        public DomainObject GetById(int id)
        {
            ObjectWatcher ObjectList = ObjectWatcher.GetInstance();
            DomainObject result = ObjectList.GetObject($"{TableName}_{id}");
            if (result == null)
            {
                string query = $"SELECT * FROM {TableName} WHERE id={id}";

                _connection.openConnection();
                SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();

                List<string> par = new List<string>();
                par.Add(Convert.ToString(id));

                while (reader.Read())
                {                    
                    par.Add(reader.GetString(1));
                    par.Add(reader.GetString(2));
                }
                reader.Close();
                _connection.closeConnection();
                Console.WriteLine($"Выполняется запрос {query}");

                //reflection time
                result = new DomainObject(par);
                ObjectList.Add($"{TableName}_{id}", result);
            }
            return result;
        }
        public bool Delete(int id)
        {
            string query = $"DELETE FROM {TableName} WHERE id={id}";

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            int num = cmd.ExecuteNonQuery();
            _connection.closeConnection();
            Console.WriteLine($"Выполняется запрос {query}");

            return num > 0;
        }
        public bool Update(int id, DomainObject obj)
        {
            string query = $"UPDATE {TableName} SET {obj.GetStringSetValues()} WHERE  id={id}";
            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            int num = cmd.ExecuteNonQuery();
            _connection.closeConnection();
            Console.WriteLine($"Выполняется запрос {query}");
            return num > 0;
        }
    }
}
