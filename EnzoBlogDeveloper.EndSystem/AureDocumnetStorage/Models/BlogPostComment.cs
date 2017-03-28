using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnzoBlogDeveloper.EndSystem.AureDocumnetStorage.Models
{
    public class BlogPostComment
    {
        [Key]
        public int BlogPostCommentId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string BlogId { get; set; }

        public virtual BlogPost BlogPostId { get; set; }

        public string Comment { get; set; }

        public string CommentedUser { get; set; }

        public DateTime CommentedDateTime { get; set; }
    }
}
