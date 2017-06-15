using System;

namespace SDMine.Collector.DataAccess.Entities
{
    public class CollectorPageEntity
    {
        public string PageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Status { get; set; }
    }
}
