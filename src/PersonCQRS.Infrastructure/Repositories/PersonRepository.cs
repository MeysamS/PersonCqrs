using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonCQRS.Domain.AggregatesModel;
using PersonCQRS.Domain.Common;

namespace PersonCQRS.Infrastructure.Repositories
{
    public class PersonRepository:IPersonRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public PersonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Person Add(Person person)
        {
            return _dbContext.Persons.Add(person).Entity;
        }

        public void Update(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
        }

        public async Task<Person> GetAsync(int personId)
        {
            var person = await _dbContext
                .Persons
                .FirstOrDefaultAsync(p => p.Id == personId);
            if (person == null)
            {
                person = _dbContext.Persons.Local.FirstOrDefault(p => p.Id == personId);
            }

            return person;
        }
    }
}