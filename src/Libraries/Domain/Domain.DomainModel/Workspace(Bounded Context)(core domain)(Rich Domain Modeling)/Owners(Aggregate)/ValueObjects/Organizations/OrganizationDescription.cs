using Domain.Core.Exceptions;
using Domain.Core.Models;

namespace Domain.DomainModel.Workspace.Owners.ValueObjects.Organizations
{
    public class OrganizationDescription : BaseValueObject
    {
        public string Value { get; private set; }

        public OrganizationDescription(string value)
        {
            Value = value;
            CheckPolicies();
        }

        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static OrganizationDescription Create(string value)
        {
            return new OrganizationDescription(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                return;

            if (Value.Length > DomainConstValues.Organization_Description_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Max_Length_Error, nameof(OrganizationName), DomainConstValues.Organization_Description_Max_Length));
        }
    }
}
