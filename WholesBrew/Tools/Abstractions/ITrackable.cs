namespace Helper
{
    public interface ITrackable : IEntity
    {
        long CreatorId { get; set; }

        DateTime CreationDate { get; set; }

        long ModificatorId { get; set; }

        DateTime ModificationDate { get; set; }
    }
}


