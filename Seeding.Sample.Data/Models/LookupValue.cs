using System;

namespace Seeding.Sample.Data.Models
{
    public class LookupValue
    {
        public int Id { get; set; }
        public int LookupTypeId { get; set; }
        public virtual LookupType LookupType { get; set; }
        public String Value { get; set; }
    }
}
