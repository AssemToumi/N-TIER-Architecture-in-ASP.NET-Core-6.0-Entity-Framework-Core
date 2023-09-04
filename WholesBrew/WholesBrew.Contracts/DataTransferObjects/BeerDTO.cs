using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace WholesBrew.Contracts.Dtos
{
    [DataContract]
    public class BeerDTO 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string? Name { get; set; } 

        [DataMember] 
        public string? AlcoholContent { get; set; }

        [DataMember]
        public decimal Price { get; set;}

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public BrewerDTO Brewer { get; set; }
    }
}
