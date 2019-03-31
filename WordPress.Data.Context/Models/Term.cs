using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordPress.Data.Models
{
	public class Term
	{
		public long Term_Id { get; set; }
		//public long Post_id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public long Term_Group { get; set; }

		public List<TermMeta> MetaData { get; set; }
		public List<TermTaxonomy> Taxonomy { get; set; }

		public Term()
		{
			this.MetaData = new List<TermMeta>();
			this.Taxonomy = new List<TermTaxonomy>();
		}
	}

}