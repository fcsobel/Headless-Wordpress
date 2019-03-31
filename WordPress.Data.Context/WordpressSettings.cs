using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;

namespace WordPress.Data
{
	public static class WordpressSettings
    {
		public static string TablePrefix { get { return ConfigurationManager.AppSettings.Get("WordPress:TablePrefix"); } }
    }
}