using FernirTestTask.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace FernirTestTask.RepositoryPattern.Interfaces
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAllPersons();
        void AddPerson(Person newPerson);
        void UpdatePersonInf(Person newPerson);
        void DeletePerson(Guid personId);
        void Save();
    }
}
