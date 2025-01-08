using buiduckiem_aps.net.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace buiduckiem_aps.net.Models
{
    public class ProductMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập tên sản phẩm.")]
        public string Name { get; set; }
        public string Avatar { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string ShortDes { get; set; }
        public string FullDescription { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> PriceDiscount { get; set; }
        public Nullable<int> TypeId { get; set; }
        public string Slug { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

    }
}