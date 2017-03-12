namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    
    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [Required(ErrorMessage = "商品名稱尚未輸入({0})")]
        [DisplayName("商品名稱")]
        public string ProductName { get; set; }

        [Required]
        [Range(100, 5000, ErrorMessage = "商品金額超過範圍 ({0} ~ {1} ~ {2})")]
        //如果要再全部的網頁中顯示特定的顯示方式
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<bool> Active { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "庫存量不得超過{2}!!")]
        public Nullable<decimal> Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
