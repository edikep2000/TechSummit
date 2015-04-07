using System;
using System.Linq;
using YouthConference.Models;

namespace YouthConference.DataAccess.Services
{
    public class RegistrantPersistenceService
    {
        private readonly IRepository<Registrant> _repository;

        public RegistrantPersistenceService(IRepository<Registrant> repository)
        {
            _repository = repository;
        }

        public void Insert(Registrant registrant)
        {
            _repository.Insert(registrant);
        }

        public void Delete(Registrant registrant)
        {
            _repository.Delete(registrant);
        }

        public IQueryable<Registrant> GetAll()
        {
            return _repository.GetAll();
        }

        public Registrant GetUnique(String email, string phoneNumber)
        {
            return _repository.Find(i => i.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) || i.PhoneNumber == phoneNumber).FirstOrDefault();
        }

        public IQueryable<Registrant> GetForCountry(string state)
        {
            return _repository.Find(i => i.State.Equals(state, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}