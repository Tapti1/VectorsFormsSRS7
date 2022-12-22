using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VectorsForms
{
    internal class TriangleMapper
    {
        protected static DBConnection _connection = null;
        public TriangleMapper()
        {
            if (_connection == null)
            {
                _connection = new DBConnection(@"Data Source=DESKTOP-RQ1TD73\SQLEXPRESS;Initial Catalog=VectorsBase;Integrated Security=True");
            }
        }
        public List<Triangle> SelectAll()
        {
            string query = $"SELECT * FROM triangles";
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            List<Triangle> ret = new List<Triangle>();

            _connection.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                Triangle v = new Triangle(id);
                ret.Add(v);
            }
            reader.Close();
            _connection.closeConnection();

            return ret;
        }

        public void Insert(Triangle t)
        {
            string query = $"insert into triangles(v1_id,v2_id) VALUES ({t.v1._id},{t.v2._id})";

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            cmd.ExecuteNonQuery();            
            _connection.closeConnection();

        }
        public Triangle GetById(int id)
        {
            return new Triangle(id);
        }
        public bool Delete(int id)
        {
            string query = $"DELETE FROM triangles WHERE id={id}";

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            int num = cmd.ExecuteNonQuery();
            _connection.closeConnection();

            return num > 0;
        }
        public bool Update(int id, Triangle t)
        {
            string query = $"UPDATE triangles SET v1_id='{t.v1._id}' , v2_id='{t.v2._id}' WHERE  id={id}";
            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            int num = cmd.ExecuteNonQuery();
            _connection.closeConnection();
            return num > 0;
        }
    }
}
