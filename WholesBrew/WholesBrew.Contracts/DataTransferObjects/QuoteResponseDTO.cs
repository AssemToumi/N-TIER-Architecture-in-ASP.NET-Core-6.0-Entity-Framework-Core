using System.Runtime.Serialization;

namespace WholesBrew.Contracts.Dtos
{
    [DataContract]
    public class QuoteResponseDTO
    {
        [DataMember]
        public List<OrderResponseDTO> OrderResponses { get; set; } = null!;

        [DataMember]
        public string Summary { get; set; } = null!;

        [DataMember]
        public WholesalerDTO Wholesaler { get; set; } = null!;
    }

}
