//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FGMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int paymentId { get; set; }
        public string cardHolderName { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string cvn { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public int farmId { get; set; }
    
        public virtual Farm Farm { get; set; }
    }
}
