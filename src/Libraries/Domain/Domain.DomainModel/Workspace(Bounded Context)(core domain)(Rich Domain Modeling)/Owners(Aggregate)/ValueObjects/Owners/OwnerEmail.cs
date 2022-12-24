using Domain.Core.Exceptions;
using Domain.Core.Models;

namespace Domain.DomainModel.Workspace.Owners.ValueObjects.Owners
{
    public class OwnerEmail : BaseValueObject
    {
        public string Value { get; private set; }
        private OwnerEmail(string value)
        {
            Value = value;
            CheckPolicies();
        }
        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static OwnerEmail Create(string value)
        {
            return new OwnerEmail(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(OwnerEmail)));

            if (Value.Length < DomainConstValues.Owner_Email_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(OwnerEmail), DomainConstValues.Owner_Email_Min_Length, DomainConstValues.Owner_Email_Max_Length));

            if (Value.Length > DomainConstValues.Owner_Email_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(OwnerEmail), DomainConstValues.Owner_Email_Min_Length, DomainConstValues.Owner_Email_Max_Length));

            if (!EmailValidator.IsValid(Value))
                throw new DomainException(DomainMessages.Invalid_Email_Address);
        }
    }
}
