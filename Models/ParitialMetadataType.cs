using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace buiduckiem_aps.net.Models
{
    public class ParitialMetadataType
    {
        [MetadataType(typeof(ProductMasterData))]
        public partial class Product
        {
            [NotMapped]
            public System.Web.HttpPostedFileBase ImageUpload { get; set; }

        }

    }
}