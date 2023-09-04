using System.Runtime.Serialization;

namespace WholesBrew.Contracts.Dtos
{
    [DataContract]
    public class WholesalerStockDTO
    {
        [DataMember]
        public BeerDTO Beer { get; set; }

        [DataMember]
        public WholesalerDTO Wholesaler { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal Price { get; set; }
    }
}
