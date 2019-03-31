using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordPress.Data.Models
{
	public class TermRelationship
	{
		public long Object_Id { get; set; }
		public long Term_Taxonomy_Id { get; set; }
		public int Term_Order { get; set; }

		public Post Post { get; set; }
		public TermTaxonomy Taxonomy { get; set; }
	}
}