using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VectorsForms
{
    internal class Vector:DomainObject
    {
        public double _x,_y;
        
        public Vector(int id) : base(id) {
            string query = $"SELECT * FROM vectors WHERE id={id}";

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                _x = reader.GetDouble(1);
                _y = reader.GetDouble(2);
            }
            reader.Close();
            _connection.closeConnection();
        }
        public Vector(double x,double y):base(0)
        {
            this._x = x;
            this._y = y;         
        }
        public double Lenght()
        {
            return Math.Sqrt(_x*_x+_y*_y);
        }

        
    }
}
