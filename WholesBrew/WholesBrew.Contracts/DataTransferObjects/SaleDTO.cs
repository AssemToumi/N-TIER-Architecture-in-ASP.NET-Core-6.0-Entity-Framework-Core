using System.Runtime.Serialization;

namespace WholesBrew.Contracts.Dtos
{
    [DataContract]
    public class SaleDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public WholesalerDTO Wholesaler { get; set; }

        [DataMember]
        public BeerDTO Beer { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }
}
