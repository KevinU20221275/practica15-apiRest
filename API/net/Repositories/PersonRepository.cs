using net.Data;
using net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static net.Repositories.PersonRepository;

namespace net.Repositories
{
    public class PersonRepository : IPersonRepository
    {

       
            private readonly IDbDataAccess _dataAccess;

            public PersonRepository(IDbDataAccess dataAccess)
            {
                _dataAccess= dataAccess;
            }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
            {
                var sql = "SELECT Id, Name, email FROM Person";
                return await _dataAccess.GetDataAsync<Person>(sql);
            }

            public async Task<Person?> GetPersonByIdAsync(int id)
            {
                var sql = "SELECT Id, Name, email FROM Person WHERE Id = @Id";
                var product = await _dataAccess.GetDataAsync<Person>(sql, new { Id = id });
                return product.FirstOrDefault();
            }

            public async Task AddPersonAsync(Person person)
            {
                var sql = "INSERT INTO Person (Name, email) VALUES (@Name, @email)";
                await _dataAccess.SaveDataAsync(sql, new { person.Name, person.email });
            }

            public async Task EditPersonAsync(Person person)
            {
                var sql = "UPDATE Person SET Name = @Name, email = @email WHERE Id = @Id";
                await _dataAccess.SaveDataAsync(sql, new { person.Name, person.email, person.Id });
            }

            public async Task DeletePersonAsync(int id)
            {
                var sql = "DELETE FROM Person WHERE Id = @Id";
                await _dataAccess.SaveDataAsync(sql, new { Id = id });
            }
    }
}
