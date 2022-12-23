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
        private int _v1_id, _v2_id;
        private Vector? _v1, _v2;
        public int v1_id { get { return _v1_id; } set { _v1_id = value; } }
        public int v2_id { get { return _v2_id; } set { _v2_id = value; } }
        public Vector? v1 { 
            get
            {
                if( v1_id>0)
                {
                    VectorMapper mapper = new VectorMapper();
                    _v1=mapper.GetById((int)v1_id);
                }
                else
                {
                    if (v1_id!= 0)
                    {
                        throw new Exception("Не могу загрузить объект");
                    }
                    else
                    { 
                        _v1=null;
                    }
                }
                return _v1;

            }
            set
            {
                _v1 = value;
            }
        }

        public Vector? v2
        {
            get
            {
                if (v2_id > 0)
                {
                    VectorMapper mapper = new VectorMapper();
                    _v2 = mapper.GetById((int)v2_id);
                }
                else
                {
                    if (v2_id != 0)
                    {
                        throw new Exception("Не могу загрузить объект");
                    }
                    else
                    {
                        _v2 = null;
                    }
                }
                return _v2;

            }
            set
            {
                _v2 = value;
            }
        }

        public Triangle(int id) : base(id)
        {
            string query = $"SELECT * FROM triangles WHERE id={id}";            

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();            

            while (reader.Read())
            {
                _v1_id = reader.GetInt32(1);
                _v2_id = reader.GetInt32(2);
            }
            reader.Close();
            _connection.closeConnection();
            Console.WriteLine($"Выполняется запрос {query}");
        }
        public Triangle(int v1_id,int v2_id) : base(0)
        {
            this._v1_id = v1_id;
            this._v2_id = v2_id;
        }        
    }
}
