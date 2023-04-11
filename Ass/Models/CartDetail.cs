﻿namespace  Ass.Models
{
    public class CartDetail
    {
        public Guid Id { get; set; }
        public Guid IDSP { get; set; }
        public Guid UserID { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
