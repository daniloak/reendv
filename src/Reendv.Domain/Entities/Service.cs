namespace Reendv.Domain.Entities
{
    public class Service : Entity
    {
        public Service(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
