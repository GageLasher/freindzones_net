using System.Collections.Generic;
using freindzones_net.Models;
using freindzones_net.Repositories;

namespace freindzones_net.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _pRepo;

        public ProfilesService(ProfilesRepository pRepo)
        {
            _pRepo = pRepo;
        }

        internal List<Profile> GetAll()
        {
            return _pRepo.GetAll();
        }

        internal Profile GetById(string id)
        {
            return _pRepo.GetById(id);
        }

        internal List<ProfileFollow> GetFollowing(string id)
        {
            return _pRepo.GetFollowingByProfileId(id);
        }

        internal List<ProfileFollow> GetFollowers(string id)
        {
            return _pRepo.GetFollowersByProfileId(id);
        }
    }
}