using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.Data
{
    public interface IDbDataAccess
    {
        Task<IEnumerable<T>> GetDataAsync<T>(string sqlQuery, object parameters = null, string connection = "default");
        Task SaveDataAsync(string sqlQuery, object parameters, string connection = "default");
    }
}
