using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorsForms
{
    internal class LazyList
    {
        private List<int> _lazyId;
        private string TableName;
        public LazyList(string _tableName)
        {
            TableName = _tableName;
        }
        public LazyList(string _tableName,List<int> _id)
        {
            TableName = _tableName;
            _lazyId = _id;
        }
        public DomainObject GetList(int ind)
        {
            Mapper mapper = new Mapper(TableName);
            return mapper.GetById(_lazyId[ind]);
        }
        public int Count { get { return _lazyId.Count; } }
    }
}
