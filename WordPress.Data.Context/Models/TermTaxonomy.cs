using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordPress.Data.Models
{
	public class TermTaxonomy
	{
		public long Term_Taxonomy_Id { get; set; }
		public long Term_Id { get; set; }
		public string Taxonomy { get; set; }
		public string Description { get; set; }
		public long Parent { get; set; }
		public long Count { get; set; }

		public Term Term { get; set; }
		public List<TermRelationship> Relationships { get; set; }
		//public List<Post> Posts { get; set; }


		public TermTaxonomy()
		{
			this.Relationships = new List<TermRelationship>();
			//this.Posts = new List<Post>();
		}
	}
}