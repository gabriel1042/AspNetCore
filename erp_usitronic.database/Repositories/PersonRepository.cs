using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using Newtonsoft.Json;

namespace erp_usitronic.database.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly IStateRepository _stateRepository;

        public PersonRepository(ApiDbContext context,
                                IStateRepository stateRepository) : base(context) {
            _stateRepository = stateRepository;
        }

        public override async Task<Person> GetById(int id)
        {
            return await DbSet.Include(p => p.Adresses)
                                .ThenInclude(a => a.City)
                              .Include(p => p.Telephones)
                              .Include(p => p.Emails)
                              .Include(p => p.Customers)
                              .Include(p => p.Supplier)
                              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async override Task<List<Person>> GetAll()
        {
            var query = from p in Db.People
                        from c in Db.Customers.Where(x => x.PersonId == p.Id).DefaultIfEmpty()
                        from s in Db.Suppliers.Where(x => x.PersonId == p.Id).DefaultIfEmpty()
                        select new
                        {
                            p.Id,
                            p.Name,
                            p.IdNumber,
                            Customer = c,
                            Supplier = s,
                            p.KindPerson
                        };
            var result = await query.ToListAsync();
            var json = JsonConvert.SerializeObject(result);
            var people = JsonConvert.DeserializeObject<List<Person>>(json);
            return people;
        }
    }
}
