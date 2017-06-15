using SDMine.Collector.DataAccess.Entities;
using System.Collections.Generic;

namespace SDMine.Collector.Services
{
    public interface ICollectorPagesService
    {
        IList<CollectorPageEntity> GetPages();
    }
}
