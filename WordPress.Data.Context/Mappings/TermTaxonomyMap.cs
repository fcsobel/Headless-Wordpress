using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WordPress.Data.Models;

namespace WordPress.Data.Mappings
{
    public class TermTaxonomyMap : EntityTypeConfiguration<TermTaxonomy>
    {
		public TermTaxonomyMap()
		{
			// Primary Key
			this.HasKey(t => t.Term_Taxonomy_Id);

			// Properties
			// Table & Column Mappings
			//this.ToTable("Curbco_Products");
			this.ToTable(string.Format("{0}term_taxonomy", WordpressSettings.TablePrefix));

			//this.ToTable("wp_am9tey_posts");
			//this.ToTable("wp_posts");

			this.Property(t => t.Term_Taxonomy_Id).HasColumnName("Term_Taxonomy_Id");

			//// Relationships
			this.HasRequired(t => t.Term)
				.WithMany(x => x.Taxonomy)
				.HasForeignKey(d => d.Term_Id);

			//this.HasOptional(t => t.Product )
			//	.WithMany()
			//	.HasForeignKey(d => d.ProductId);

		}
    }
}
