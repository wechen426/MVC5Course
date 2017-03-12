using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.Vailedation
{
    public class 檢查商品名稱不能有大便Attribute : DataTypeAttribute
    {
        public 檢查商品名稱不能有大便Attribute() :base(DataType.Text)
        {
            ErrorMessage = "名稱裡面不能有大便啦!";
        }
        public override bool IsValid(object value)
        {
            string str = Convert.ToString(value);
            if(str.Contains("大便") || str.ToUpper().Contains("SHIT"))
            {
                return false;
            }
                return true;
        }
                  
         
    }
}