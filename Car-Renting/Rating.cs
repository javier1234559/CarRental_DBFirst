//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Car_Renting
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rating
    {
        public int RatingId { get; set; }
        public Nullable<int> RentId { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<int> RatingValue { get; set; }
        public string FeedBack { get; set; }
        public Nullable<int> ClientId { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Client Client { get; set; }
        public virtual Rent Rent { get; set; }
    }
}
