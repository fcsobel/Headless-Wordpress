using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordPress.Data.Models
{
	public class User
	{
		public long Id { get; set; }
		public string User_Login { get; set; }
		public string User_Pass { get; set; }
		public string User_Nicename { get; set; }
		public string User_Email { get; set; }
		public string User_Url { get; set; }
		public DateTime User_Registered { get; set; }
		public string User_Activation_Key { get; set; }
		public int User_Status { get; set; }
		public string Display_Name { get; set; }
	}
}