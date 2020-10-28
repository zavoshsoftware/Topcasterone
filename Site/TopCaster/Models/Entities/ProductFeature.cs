using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Models
{
    public class ProductFeature : BaseEntity
    {
        [Display(Name="ویژگی")]
        public string Key { get; set; }

        [Display(Name="مقدار")]
        public string Value { get; set; }

        [Display(Name="محصول")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        internal class configuration : EntityTypeConfiguration<ProductFeature>
        {
            public configuration()
            {
                HasRequired(p => p.Product).WithMany(t => t.ProductFeatures).HasForeignKey(p => p.ProductId);
            }
        }
    }
}