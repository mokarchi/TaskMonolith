using Domain.Core.Exceptions;
using Domain.Core.Models;

namespace Domain.DomainModel.Workspace.Owners.ValueObjects.Owners
{
    public class OwnerDisplayName : BaseValueObject
    {
        public string Value { get; private set; }
        private OwnerDisplayName(string value)
        {
            Value = value;
            CheckPolicies();
        }

        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static OwnerDisplayName Create(string value)
        {
            return new OwnerDisplayName(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(OwnerDisplayName)));

            if (Value.Length < DomainConstValues.Owner_DisplayName_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(OwnerDisplayName), DomainConstValues.Owner_DisplayName_Min_Length, DomainConstValues.Owner_DisplayName_Max_Length));

            if (Value.Length > DomainConstValues.Owner_DisplayName_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(OwnerDisplayName), DomainConstValues.Owner_DisplayName_Min_Length, DomainConstValues.Owner_DisplayName_Max_Length));

            //TODO should only contain alphabet and space ...
        }
    }
}
