using System.Runtime.Serialization;

namespace WholesBrew.Contracts.Dtos
{
    [DataContract]
    public class OrderResponseDTO
    {
        [DataMember]
        public BeerDTO Beer { get; set; } = null!;

        [DataMember]
        public string? Label { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal UnitPrice { get; set; }

        [DataMember]
        public decimal TotalBeforeDiscount { get; set; }

        [DataMember]
        public string? Discount { get; set; }

        [DataMember]
        public decimal TotalAfterDiscount { get; set; }
    }
}
