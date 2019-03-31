using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WordPress.Data.Models;

namespace WordPress.Data.Mappings
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
		public PostMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            //this.ToTable("Curbco_Products");
            this.ToTable(string.Format("{0}posts", WordpressSettings.TablePrefix));
            //this.ToTable("wp_am9tey_posts");
            //this.ToTable("wp_posts");

            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Post_Author).HasColumnName("Post_Author");
            this.Property(t => t.Post_Date).HasColumnName("Post_Date");

			//// Relationships
			//this.HasRequired(t => t.Quote)
			//	.WithMany(t => t.Lines)
			//	.HasForeignKey(d => d.QuoteId);

			this.HasOptional(t => t.Author )
            	.WithMany()
            	.HasForeignKey(d => d.Post_Author);

			this.HasMany(t => t.MetaData)
				.WithRequired()
				.HasForeignKey(d => d.Post_id);

			this.HasMany(x => x.Comments)
				.WithRequired()
				.HasForeignKey(x => x.PostId);

			this.HasMany(x => x.Children)
				.WithOptional(x => x.Parent)
				.HasForeignKey(x => x.Post_Parent);

			//this.HasOptional(x => x.Parent)
			//	.WithMany()
			//	.HasForeignKey(x => x.Post_Parent);

			//this.HasMany(t => t.Taxonomy)
			//	.WithMany(x => x.Posts)
			//		.Map(m =>
			//		{
			//			m.ToTable(string.Format("{0}term_relationships", WordpressSettings.TablePrefix));
			//			m.MapLeftKey("Object_Id");
			//			m.MapRightKey("Term_Taxonomy_Id");
			//		});
		}
    }
}
