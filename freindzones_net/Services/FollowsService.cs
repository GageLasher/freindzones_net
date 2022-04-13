using System;
using freindzones_net.Models;
using freindzones_net.Repositories;

namespace freindzones_net.Services
{
    public class FollowsService
    {
        private readonly FollowsRepository _followsRepo;

        public FollowsService(FollowsRepository followsRepo)
        {
            _followsRepo = followsRepo;
        }

        internal Follow Create(Follow data)
        {
            Follow exists = _followsRepo.Get(data.Follower, data.Following);
            if (exists != null)
            {
                return exists;
            }
            return _followsRepo.Create(data);
        }

        internal void Remove(int id, string userId)
        {
            Follow found = Get(id);
            if (found.Follower != userId)
            {
                throw new System.Exception("you do not have acces to this");
            }
            _followsRepo.Remove(id);
        }

        private Follow Get(int id)
        {
            Follow found = _followsRepo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid ID");
            }
            return found;
        }
    }
}