namespace Domain.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; private set; }
        public CreationTime CreationTime { get; private set; }

        public BaseEntity()
        {
            Id = ObjectId.GenerateNewId().ToString();
            CreationTime = CreationTime.Create();
        }

        protected void UpdateModifiedDateTime()
        {
            CreationTime = CreationTime.UpdateModifiedDateTime();
        }

        protected void SetId(string id)
        {
            Id = id;
            UpdateModifiedDateTime();
        }
    }
}
