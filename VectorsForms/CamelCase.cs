using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorsForms
{
    internal class CamelCase
    {
        public static string GetClassName(string _tableName)
        {
            string nameClass = _tableName.ToUpper()[0]+_tableName.Substring(1,_tableName.Length-2);
            return nameClass;
        }        
    }
}
