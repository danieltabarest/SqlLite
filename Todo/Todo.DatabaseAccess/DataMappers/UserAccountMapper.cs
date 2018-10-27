using Todo.LocalData.Models;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Models;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class UserAccountMapper : IDataMapper<UserProfile, User>
    {
        public User ToData(UserProfile domain)
        {
            return new User
            {
                Id = domain.Id,
                Username = domain.Username,
                NsuId = domain.NsuId,
                Name = domain.Name,
                EmailAddress = domain.EmailAddress,
                Photo = domain.Photo
            };
        }

        public UserProfile ToDomain(User data)
        {
            return new UserProfile(data.Id, data.EmailAddress)
            {
                Username = data.Username,
                NsuId = data.NsuId,
                Name = data.Name,
                EmailAddress = data.EmailAddress,
                Photo = data.Photo
            };
        }
    }
}
