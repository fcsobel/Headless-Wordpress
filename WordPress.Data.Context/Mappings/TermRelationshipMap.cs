using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WordPress.Data.Models;

namespace WordPress.Data.Mappings
{
    public class TermRelationshipMap : EntityTypeConfiguration<TermRelationship>
    {
		public TermRelationshipMap()
        {
			// Primary Key
			this.HasKey(t => new { t.Term_Taxonomy_Id, t.Object_Id });

            // Properties
            // Table & Column Mappings
			this.ToTable(string.Format("{0}term_relationships", WordpressSettings.TablePrefix));

			this.Property(t => t.Object_Id).HasColumnName("Object_Id");

			this.HasRequired(t => t.Post)
				.WithMany(t => t.Relationships)
				.HasForeignKey(d => d.Object_Id);

			this.HasRequired(t => t.Taxonomy)
				.WithMany(t => t.Relationships)
				.HasForeignKey(d => d.Term_Taxonomy_Id);

		}
    }
}
