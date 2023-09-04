using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WholesBrew.Contracts.Dtos;

namespace WholesBrew.Contracts.DataTransferObjects
{
    [DataContract]
    public class RestrictionDTO
    {
        [DataMember]
        public WholesalerDTO Wholesaler { get; set; }

        [DataMember]
        public BeerDTO Beer { get; set; }

        [DataMember]
        public int MaxQuantity { get; set; }
    }
}
