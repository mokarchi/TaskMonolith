﻿using Domain.Core.Exceptions;
using Domain.Core.Models;

namespace Domain.DomainModel.Workspace.Owners.ValueObjects.Projects
{
    public class ProjectName : BaseValueObject
    {
        public string Value { get; private set; }
        public ProjectName(string value)
        {
            Value = value;
            CheckPolicies();
        }

        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static ProjectName Create(string value)
        {
            return new ProjectName(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(ProjectName)));

            if (Value.Length < DomainConstValues.Project_Name_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(ProjectName), DomainConstValues.Project_Name_Min_Length, DomainConstValues.Project_Name_Max_Length));

            if (Value.Length > DomainConstValues.Project_Name_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(ProjectName), DomainConstValues.Project_Name_Min_Length, DomainConstValues.Project_Name_Max_Length));

        }
    }
}
