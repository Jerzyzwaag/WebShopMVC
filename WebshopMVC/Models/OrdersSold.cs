//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebshopMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdersSold
    {
        public int ID { get; set; }
        public int ArticleID { get; set; }
        public int CustomerID { get; set; }
        public Nullable<byte> InBasket { get; set; }
        public int Amount { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
