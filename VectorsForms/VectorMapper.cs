using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VectorsForms
{
    internal class VectorMapper
    {
        protected static DBConnection _connection = null;
        public VectorMapper()
        {
            if (_connection == null)
            {
                _connection = new DBConnection(@"Data Source=DESKTOP-RQ1TD73\SQLEXPRESS;Initial Catalog=VectorsBase;Integrated Security=True");
            }
        }
        public List<Vector> SelectAll()
        {
            string query = $"SELECT * FROM vectors";
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            List<Vector> ret = new List<Vector>();

            _connection.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                Vector v = new Vector(id);
                ret.Add(v);
            }
            reader.Close();
            _connection.closeConnection();
            Console.WriteLine($"Выполняется запрос {query}");

            return ret;
        }

        public void Insert(Vector v)
        {
            string query = $"insert into vectors(x,y) VALUES ({v._x},{v._y})";

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            cmd.ExecuteNonQuery();
            _connection.closeConnection();
            Console.WriteLine($"Выполняется запрос {query}");

        }
        public Vector GetById(int id)
        {
            ObjectWatcher ObjectList=ObjectWatcher.GetInstance();
            Vector result = (Vector)ObjectList.GetObject($"vectors_{id}");
            if (result == null)
            {
                result=new Vector(id);
                ObjectList.Add($"vectors_{id}",result);
            }
            return result;
        }
        public bool Delete(int id)
        {
            string query = $"DELETE FROM vectors WHERE id={id}";

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());            
            int num = cmd.ExecuteNonQuery();
            _connection.closeConnection();
            Console.WriteLine($"Выполняется запрос {query}");

            return num>0;
        }
        public bool Update(int id,Vector new_v)
        {
            string query = $"UPDATE vectors SET x='{new_v._x}' , y='{new_v._y}' WHERE  id={id}";
            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            int num = cmd.ExecuteNonQuery();
            _connection.closeConnection();
            Console.WriteLine($"Выполняется запрос {query}");
            return num > 0;
        }

    }
}
