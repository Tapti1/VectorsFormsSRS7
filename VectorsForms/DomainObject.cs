using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace VectorsForms
{
    abstract class DomainObject
    {
        public int _id;
        protected static DBConnection _connection = null;
        protected abstract void LoadObject(List<string> _params);
        public DomainObject(List<string> _params)
        {
            _connection=new DBConnection(@"Data Source=DESKTOP-RQ1TD73\SQLEXPRESS;Initial Catalog=VectorsBase;Integrated Security=True");
            _id = Convert.ToInt32(_params[0]);
            LoadObject(_params);            
        }
        public abstract string GetStringParams();
        public abstract string GetStringParamsValues();

        public abstract string GetStringSetValues();

    }
}
