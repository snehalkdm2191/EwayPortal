using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Portal.Api.Model
{
    public partial class ContentMaster
    {
        public ContentMaster()
        {
            ContentGroups = new HashSet<ContentGroup>();
        }

        public Guid ContentId { get; set; }
        public string ContentHeader { get; set; }

        [JsonIgnore]
        public virtual ICollection<ContentGroup> ContentGroups { get; set; }
    }
}
