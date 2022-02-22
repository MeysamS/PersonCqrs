using System.Threading.Tasks;
using PersonCQRS.Domain.Common;

namespace PersonCQRS.Domain.AggregatesModel
{
    public interface IPersonRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Person Add(Person person);
        void Update(Person person);
        Task<Person> GetAsync(int personId);
    }
}