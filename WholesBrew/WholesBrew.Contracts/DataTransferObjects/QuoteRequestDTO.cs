using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WholesBrew.Contracts.Dtos
{
    [DataContract]
    public class QuoteRequestDTO
    {
        [DataMember]
        public List<BeerDTO>? OrderBeers { get; set; }

        [DataMember]
        public WholesalerDTO Wholesaler { get; set; } = null!;
    }
    
}
