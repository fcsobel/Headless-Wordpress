using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WordPress.Data.Models;

namespace WordPress.Data.Mappings
{
    public class TermMap : EntityTypeConfiguration<Term>
    {
		public TermMap()
        {
            // Primary Key
            this.HasKey(t => t.Term_Id);

            // Properties
            // Table & Column Mappings
            //this.ToTable("Curbco_Products");
			this.ToTable(string.Format("{0}terms", WordpressSettings.TablePrefix));

			//this.ToTable("wp_am9tey_posts");
			//this.ToTable("wp_posts");

			this.Property(t => t.Term_Id).HasColumnName("Term_Id");

			//// Relationships
			//this.HasRequired(t => t.Quote)
			//	.WithMany(t => t.Lines)
			//	.HasForeignKey(d => d.QuoteId);
			//this.HasOptional(t => t.Product )
			//	.WithMany()
			//	.HasForeignKey(d => d.ProductId);

			this.HasMany(x => x.Taxonomy)
				.WithRequired(x=>x.Term)
				.HasForeignKey(d => d.Term_Id);

			this.HasMany(x => x.MetaData)
				.WithRequired()
				.HasForeignKey(d => d.Term_Id);


		}
    }
}
