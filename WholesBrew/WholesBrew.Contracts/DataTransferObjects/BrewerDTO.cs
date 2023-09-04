using System.Runtime.Serialization;

namespace WholesBrew.Contracts.Dtos
{
    [DataContract]
    public class BrewerDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string? Name { get; set; } 
    }
}
