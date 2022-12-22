using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VectorsForms
{
    internal class Triangle:DomainObject
    {
        public double _v1_x, _v1_y, _v2_x,_v2_y;

        public Triangle(int id) : base(id)
        {
            string query = $"SELECT * FROM triangles WHERE id={id}";

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            int _v1_id=0, _v2_id=0;

            while (reader.Read())
            {
                _v1_id = reader.GetInt32(1);
                _v2_id = reader.GetInt32(2);
            }
            reader.Close();
            _connection.closeConnection();
            //////////////////////////////////////tytaa

            VectorMapper mapper = new VectorMapper();
            Vector v1 = mapper.GetById(_v1_id);
        }
        public Triangle(int v1_id,int v2_id) : base(0)
        {
            this._v1_id=v1_id;
            this._v2_id=v2_id;
        }        
    }
}
