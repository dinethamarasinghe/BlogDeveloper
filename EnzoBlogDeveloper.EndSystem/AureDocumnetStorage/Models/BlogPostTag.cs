using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnzoBlogDeveloper.EndSystem.AureDocumnetStorage.Models
{
    public class BlogPostTag
    {
        [Key]
        public int BlogPostTagId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string BlogId { get; set; }

        public virtual BlogPost BlogPostId { get; set; }

        public string Tag { get; set; }

        public string TaggedUser { get; set; }

        public DateTime TaggedDateTime { get; set; }
    }
}
