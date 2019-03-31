using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WordPress.Data.Models;

namespace WordPress.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
		public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            //this.ToTable("Curbco_Products");
			this.ToTable(string.Format("{0}users", WordpressSettings.TablePrefix));

			//this.ToTable("wp_am9tey_posts");
			//this.ToTable("wp_posts");

			this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Display_Name).HasColumnName("Display_Name");
            this.Property(t => t.User_Email).HasColumnName("User_Email");
			this.Property(t => t.User_Nicename).HasColumnName("User_Nicename");

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
