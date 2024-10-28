using DataAccessDemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDemoLibrary.Data
{
    public class PeopleData : IPeopleData
    {
        private readonly ISqlDataAccess _sql;

        public PeopleData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        // This is an added layer that can be used between the data access methods and the UI that calls it, this way the folks designing the UI don't need to remember the names and parameters of the stored procedures
        public async Task<IEnumerable<PersonModel>> GetAllPeople()
        {
            var output = await _sql.LoadDataAsync<PersonModel, dynamic>(
                "dbo.GetPeople", new { });

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task UpdatePerson(PersonModel person)
        {
            await _sql.SaveDataAsync("dbo.UpdatePerson", person);
        }

        /// <summary>
        /// This one takes and updates a Person model. It is a little more complex than the others because it is updating a record in the database
        /// It takes the parameters (U type). The parameters here would be the parameters in the SP, and then the assigned value
        /// NOTE: If the parameters have the same casing/spelling as the property names, than you don't need to specify the names, and instead can just pass the properties
        ///       Left the nameing in here for future reference
        /// It's a little bit magical for my taste, but it works!      
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task InsertPerson(PersonModel person)
        {
            await _sql.SaveDataAsync("dbo.AddPerson", new { FirstName = person.FirstName, LastName = person.LastName, DateOfBirth = person.DateOfBirth });
        }

        public async Task DeletePerson(int id)
        {
            await _sql.SaveDataAsync("dbo.DeletePerson", new { Id = id });
        }
    }
}
