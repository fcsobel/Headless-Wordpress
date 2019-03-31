using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordPress.Data.Models
{
	enum PostTypeEnum
	{
		Post,
		Page,
		Attachment,
		Revision,
		Nav_Menu_Item,
		Custom_Css,
		Customize_Changeset,
		User_Request
	}


	//[Table("wp_am9tey_posts")]
	//[Table("wp_posts")]
	public class Post
	{
		public long Id { get; set; }
		public long? Post_Author { get; set; }
		public DateTime Post_Date { get; set; }
		public DateTime Post_Date_Gmt { get; set; }
		public string Post_Content { get; set; }
		public string Post_Title { get; set; }
		public string Post_Excerpt { get; set; }
		public string Post_Status { get; set; }
		public string Comment_Status { get; set; }
		public string Ping_Status { get; set; }
		public string Post_Password { get; set; }
		public string Post_Name { get; set; }

		public string To_Ping { get; set; }
		public string Pinged { get; set; }

		public DateTime Post_Modified { get; set; }
		public DateTime Post_Modified_Gmt { get; set; }
		public string Post_Content_Filtered { get; set; }
		public long? Post_Parent { get; set; }
		public string Guid { get; set; }
		public int Menu_Order { get; set; }
		public string Post_Type { get; set; }
		public string Post_Mime_Type { get; set; }
		public long Comment_Count { get; set; }

		[NotMapped]
		public string HeaderImage {
			get {
				string path = null;

				var post = this.Children.LastOrDefault(x => x.PostType == PostTypeEnum.Attachment && x.MetaData.Any(m => m.Meta_Key == "_wp_attachment_image_alt"));

				//var post = this.Children.Find(x => x.PostType == PostTypeEnum.Attachment && x.MetaData.Any(m => m.Meta_Key == "_wp_attachment_image_alt" && m.Meta_Value == this.Post_Title));

				if (post != null)
				{
					var item = post.MetaData.Find(x => x.Meta_Key == "_wp_attached_file");

					if (item != null)
					{
						return item.Meta_Value;
					}
				}
				return path;
			}
		}
		

		[NotMapped]
		public List<Term> Areas { get { return this.Relationships.Where(x => x.Taxonomy.Taxonomy == "areas").Select(x => x.Taxonomy.Term).ToList(); } }
		[NotMapped]
		public List<Term> Categories { get { return this.Relationships.Where(x => x.Taxonomy.Taxonomy == "category").Select(x => x.Taxonomy.Term).ToList(); } }
		[NotMapped]
		public List<Term> Tags { get { return this.Relationships.Where(x => x.Taxonomy.Taxonomy == "post_tag").Select(x => x.Taxonomy.Term).ToList(); } }

		[NotMapped]
		PostTypeEnum PostType { get { return this.Post_Type.ParseEnum<PostTypeEnum>(PostTypeEnum.Post); } }

		public Post Parent { get; set; }
		public User Author { get; set; }
		public List<TermRelationship> Relationships { get; set; }
		public List<Comment> Comments { get; set; }
		public List<PostMeta> MetaData { get; set; }
		public List<Post> Children { get; set; }
		//public List<TermTaxonomy> Taxonomy { get; set; }

		public Post()
		{
			this.Relationships = new List<TermRelationship>();
			this.MetaData = new List<PostMeta>();
			this.Comments = new List<Comment>();
			this.Children = new List<Post>();
		//	this.Taxonomy = new List<TermTaxonomy>();
		}
	}
}