using System.Linq;
using YouthConference.Models;

namespace YouthConference.DataAccess.Services
{
    public class UserProfilePersistenceService
    {
        private readonly IRepository<UserProfile> _repository;

        public UserProfilePersistenceService(IRepository<UserProfile> repository)
        {
            _repository = repository;
        }

        public void Delete(int userId)
        {
            _repository.Delete(userId);
        }

        public void Insert(UserProfile user)
        {
            _repository.Insert(user);
        }

        public IQueryable<UserProfile> AllUsers()
        {
            return _repository.GetAll();
        }

        public UserProfile GetSingle(int userId)
        {
            return _repository.GetSingle(userId);
        }

        public UserProfile GetForUser(string userName)
        {
            return _repository.Find(i => i.UserName == userName).FirstOrDefault();
        }
    }
}