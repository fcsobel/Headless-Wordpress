using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;
//using c3o.Core;

namespace WordPress.Data.Models
{
	//[Table("wp_am9tey_comments")]
	//[Table("wp_comments")]
	public class Comment
	{
		//[Column("comment_id")]
		public long Id { get; set; }
		//[Column("comment_post_id")]
		public long PostId { get; set; }		
		//[Column("comment_author")]
		public string Author { get; set; }		
		//[Column("comment_author_email")]
		public string Email { get; set; }		
		//[Column("comment_author_url")]
		public string Url { get; set; }		
		//[Column("comment_author_ip")]
		public string Ip		{ get; set; }
		//[Column("comment_date")]
		public DateTime CommentDate { get; set; }
		//[Column("comment_content")]
		public string Content { get; set; }
		//[Column("comment_Approved")]
		public string Approved { get; set; }
		public string Comment_Agent { get; set; }
		public string Comment_Type { get; set; }
		public long Comment_Parent { get; set; }
		public long User_Id { get; set; }

		public List<CommentMeta> MetaData { get; set; }

		public Comment()
		{
			this.MetaData = new List<CommentMeta>();
		}

		//[NotMapped]
		//public string AvatarUrl { get { return string.Format("//www.gravatar.com/avatar/{0}", IdentityHelper.HashEmailForGravatar(this.Email)); } }
	}

	public class CommentMeta
	{
		public long Meta_Id { get; set; }
		public long Comment_Id { get; set; }
		public string Meta_Key { get; set; }
		public string Meta_Value { get; set; }
	}
}