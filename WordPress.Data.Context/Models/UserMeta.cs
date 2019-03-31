using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordPress.Data.Models
{
	public class UserMeta
	{
		public long Umeta_Id { get; set; }
		public long UserId { get; set; }
		public string Meta_Key { get; set; }
		public string Meta_Value { get; set; }
	}
}