using Domain.Core.Exceptions;
using Domain.Core.Models;

namespace Domain.DomainModel.Workspace.Owners.ValueObjects.Projects
{
    public class ProjectDescription : BaseValueObject
    {
        public string Value { get; private set; }
        public ProjectDescription(string value)
        {
            Value = value;
            CheckPolicies();
        }

        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static ProjectDescription Create(string value)
        {
            return new ProjectDescription(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                return;

            if (Value.Length > DomainConstValues.Project_Description_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Max_Length_Error, nameof(ProjectName), DomainConstValues.Project_Description_Max_Length));

        }
    }
}
