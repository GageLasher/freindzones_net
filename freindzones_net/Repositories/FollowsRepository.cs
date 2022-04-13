using System.Data;
using Dapper;
using freindzones_net.Models;

namespace freindzones_net.Repositories
{
    public class FollowsRepository
    {
        private readonly IDbConnection _db;

        public FollowsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Follow Create(Follow data)
        {
            string sql = @"
            INSERT INTO follows
            (follower, following)
            VALUES
            (@Follower, @Following);
                    SELECT LAST_INSERT_ID();

            ";
            int id = _db.ExecuteScalar<int>(sql, data);
            data.Id = id;
            return data;
        }
        internal Follow Get(string follower, string following)
        {
            string sql = @"
            SELECT * FROM follows
            WHERE follower = @Follower AND following = @Following
            ";

            return _db.QueryFirstOrDefault<Follow>(sql, new { follower, following });
        }

        internal Follow Get(int id)
        {
            string sql = @"
            SELECT * FROM follows
            WHERE id = @id;
            ";
            return _db.QueryFirstOrDefault<Follow>(sql, new { id });
        }

        internal object Remove(int id)
        {
            string sql = @"
            DELETE FROM follows
            WHERE id = @id
            ";
            return _db.Execute(sql, new { id });
        }
    }
}