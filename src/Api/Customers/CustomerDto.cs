﻿using System;
using System.Collections.Generic;

namespace Api.Customers
{
    public class CustomerDto 
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime? StatusExpirationDate { get; set; }
        public decimal MoneySpent { get; set; }
        public List<PurchasedMovieDto> PurchasedMoviesDtos { get; set; }        
    }
}
