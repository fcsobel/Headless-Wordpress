using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WordPress.Data.Models;

namespace WordPress.Data.Mappings
{
    public class PostMetaMap : EntityTypeConfiguration<PostMeta>
    {
		public PostMetaMap()
        {
            // Primary Key
            this.HasKey(t => t.Meta_Id);

            // Properties
            // Table & Column Mappings
            //this.ToTable("Curbco_Products");
			this.ToTable(string.Format("{0}postmeta", WordpressSettings.TablePrefix));

			//this.ToTable("wp_am9tey_posts");
			//this.ToTable("wp_posts");

			this.Property(t => t.Meta_Id).HasColumnName("Meta_Id");

			//// Relationships
			//this.HasRequired(t => t.Quote)
			//	.WithMany(t => t.Lines)
			//	.HasForeignKey(d => d.QuoteId);
			//this.HasOptional(t => t.Product )
			//	.WithMany()
			//	.HasForeignKey(d => d.ProductId);
		}
    }
}
