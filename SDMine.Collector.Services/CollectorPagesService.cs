using Dapper;
using SDMine.Collector.DataAccess;
using SDMine.Collector.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SDMine.Collector.Services
{
    public class CollectorPagesService : ICollectorPagesService
    {
        public IList<CollectorPageEntity> GetPages()
        {
            using (var conn = DbContext.CreateConnection())
            {
                var sql = $@"SELECT cp.[PageId], cp.[Name], cp.[Description] 
                             FROM [dbo].[CollectorPages] cp 
                             WHERE cp.Status = '1' AND cp.UpdatedDate IS NULL";
                return conn.Query<CollectorPageEntity>(sql).ToList();
            }
        }
    }
}
