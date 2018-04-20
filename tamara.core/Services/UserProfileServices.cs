using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamara.core.infrastructure;
using tamara.webhook.core.domain;

namespace tamara.webhook.core.services
{
    public interface IUserProfileServices
    {
        IEnumerable<UserProfile> GetUsers();
        UserProfile GetByDeviceId(string deviceId);

        UserProfile GetByAccoutNo(string accountNo);
    }

    public class UserProfileServices :  BaseService, IUserProfileServices
    {
        private readonly IRepository<UserProfile> _userProfileRepo;

        public UserProfileServices()
        {
            _userProfileRepo = new BaseRepository<UserProfile>(this.unitOfWork);
        }
        public IEnumerable<UserProfile> GetUsers()
        {
            return _userProfileRepo.All.Where(x => x.Status == "Active").ToList();
        }

        public UserProfile GetByDeviceId(string deviceId)
        {
            return _userProfileRepo.All.FirstOrDefault(x=>x.DeviceId == deviceId);
        }

        public UserProfile GetByAccoutNo(string accountNo)
        {
            return _userProfileRepo.All.FirstOrDefault(x => x.AccountNo == accountNo);
        }

        public bool Add(UserProfile userProfile)
        {
           _userProfileRepo.Add(userProfile);
            return true;
        }
    }


}
