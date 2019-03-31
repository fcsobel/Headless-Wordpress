using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.Entity;
using System.Data.Common;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using WordPress.Data.Models;
using WordPress.Data.Mappings;

namespace WordPress.Data
{
	// Code-Based Configuration and Dependency resolution
	//[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public class WordpressContext : DbContext
	{
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Term> Terms { get; set; }
		public DbSet<TermTaxonomy> Taxonomy { get; set; }

		//WordpressContext
		public WordpressContext() : base("Name=WordpressContext")
		{

		}

		// Constructor to use on a DbConnection that is already opened
		public WordpressContext(DbConnection existingConnection, bool contextOwnsConnection)
			: base(existingConnection, contextOwnsConnection)
		{

		}

		
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new CommentMap());
			modelBuilder.Configurations.Add(new UserMap());
			modelBuilder.Configurations.Add(new PostMetaMap());
			modelBuilder.Configurations.Add(new CommentMetaMap());
			modelBuilder.Configurations.Add(new TermMap());
			modelBuilder.Configurations.Add(new TermMetaMap());
			modelBuilder.Configurations.Add(new TermRelationshipMap());
			modelBuilder.Configurations.Add(new TermTaxonomyMap());
		}
    }
}