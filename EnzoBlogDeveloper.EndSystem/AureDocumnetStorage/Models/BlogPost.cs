using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnzoBlogDeveloper.EndSystem.AureDocumnetStorage.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            Comments = new List<BlogPostComment>();
            Tags = new List<BlogPostTag>();
        }

        [Key]
        [JsonProperty(PropertyName = "BlogPostId")]
        public int BlogPostId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string BlogId { get; set; }

        [JsonProperty(PropertyName = "Heading")]
        public string Heading { get; set; }

        [JsonProperty(PropertyName = "Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [DisplayName("Created Date")]
        [JsonProperty(PropertyName = "CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [DisplayName("Wrriten By")]
        [JsonProperty(PropertyName = "CreatedUser")]
        public string CreatedUser { get; set; }

        [DisplayName("Last Updated By")]
        [JsonProperty(PropertyName = "LastUpdatedUser")]
        public string LastUpdatedUser { get; set; }

        [JsonProperty(PropertyName = "Comments")]
        public ICollection<BlogPostComment> Comments { get; set; }

        [JsonProperty(PropertyName = "Tags")]
        public ICollection<BlogPostTag> Tags { get; set; }
    }
}
