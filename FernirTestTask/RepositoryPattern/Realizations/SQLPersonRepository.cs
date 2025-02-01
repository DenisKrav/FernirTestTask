using FernirTestTask.DataModels;
using FernirTestTask.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FernirTestTask.RepositoryPattern.Realizations
{
    public class SQLPersonRepository : IRepository<Person>
    {
        private PersonDbContext db;

        public SQLPersonRepository()
        {
            this.db = new PersonDbContext();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return db.Persons;
        }

        public void AddPerson(Person newPerson)
        {
            db.Persons.Add(newPerson);
        }

        public void UpdatePersonInf(Person newPerson)
        {
            db.Entry(newPerson).State = EntityState.Modified;
        }

        public void DeletePerson(Guid personId)
        {
            Person person = db.Persons.Find(personId);
            if (person != null)
                db.Persons.Remove(person);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
