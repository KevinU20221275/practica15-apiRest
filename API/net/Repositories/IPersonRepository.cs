using net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPersonsAsync();
        Task<Person?> GetPersonByIdAsync(int id);
        Task AddPersonAsync(Person person);
        Task EditPersonAsync(Person person);
        Task DeletePersonAsync(int id);
    }
}
