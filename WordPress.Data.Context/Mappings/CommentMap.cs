using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WordPress.Data.Models;

namespace WordPress.Data.Mappings
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
		public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            //this.ToTable("Curbco_Products");
            //[Table("wp_am9tey_comments")]
            //[Table("wp_comments")]
            this.ToTable(string.Format("{0}comments", WordpressSettings.TablePrefix));
            this.Property(t => t.Id).HasColumnName("comment_id");
            this.Property(t => t.PostId).HasColumnName("comment_post_id");
            this.Property(t => t.Author).HasColumnName("comment_author");
            this.Property(t => t.Email).HasColumnName("comment_author_email");
            this.Property(t => t.Url).HasColumnName("comment_author_url");
            this.Property(t => t.Ip).HasColumnName("comment_author_ip");
            this.Property(t => t.CommentDate).HasColumnName("comment_date");
            this.Property(t => t.Content).HasColumnName("comment_content");
            this.Property(t => t.Approved).HasColumnName("comment_Approved");


			this.HasMany(t => t.MetaData)
				.WithRequired()
				.HasForeignKey(d => d.Comment_Id);

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
