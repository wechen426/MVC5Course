//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderLine = new HashSet<OrderLine>();
        }
        
        public int ProductId { get; set; }

        [Required(ErrorMessage = "商品名稱尚未輸入({0})")]
        [DisplayName("商品名稱")]
        public string ProductName { get; set; }

        [Required]
        [Range (100,5000,ErrorMessage = "商品金額超過範圍 ({0} ~ {1} ~ {2})") ]
        //如果要再全部的網頁中顯示特定的顯示方式
        [DisplayFormat(DataFormatString ="{0:N0}")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<bool> Active { get; set; }

        [Required]
        [Range (0,10000,ErrorMessage = "庫存量不得超過{2}!!")]
        public Nullable<decimal> Stock { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
