using System;
namespace Domain
{
    public class RentBook: EntidadeBase
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }        
        public int Term { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Delivered { get; set; }        
        public RentBook Delivery(){
            Delivered = true;
            return this;
        }
    }
}