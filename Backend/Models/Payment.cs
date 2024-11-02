﻿using PhoneVault.Models;

namespace PhoneVault.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; } 
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionId { get; set; }

        //public Order Order { get; set; }
    }  
}