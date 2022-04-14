using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using freindzones_net.Models;

namespace freindzones_net.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Profile> GetAll()
        {
            string sql = @"
            SELECT
            *
            FROM accounts
            ";
            return _db.Query<Profile>(sql).ToList();

        }

        internal Profile GetById(string id)
        {
            string sql = @"
            SELECT
            *
            FROM accounts
            WHERE id = @id
            ";
            return _db.QueryFirstOrDefault<Profile>(sql, new { id });
        }

        internal List<ProfileFollow> GetFollowersByProfileId(string id)
        {
            string sql = @"
                SELECT
                f.id AS FollowId,
                a.*
                FROM follows f
                JOIN accounts a ON a.id = f.follower
                WHERE f.following = @id
            ";
            return _db.Query<ProfileFollow>(sql, new { id }).ToList();
        }

        internal List<ProfileFollow> GetFollowingByProfileId(string id)
        {
            string sql = @"
                SELECT
                f.id AS FollowId,
                a.*
                FROM follows f
                JOIN accounts a ON a.id = f.following
                WHERE f.follower = @id
            ";
            return _db.Query<ProfileFollow>(sql, new { id }).ToList();
        }
    }
}