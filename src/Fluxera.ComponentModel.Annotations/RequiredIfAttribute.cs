namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using Guards;
	using JetBrains.Annotations;

	/// <summary>
	///     http://stackoverflow.com/questions/7390902/requiredif-conditional-validation-attribute
	/// </summary>
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class RequiredIfAttribute : RequiredAttribute
	{
		private readonly object[] desiredValues;
		private readonly string propertyName;

		// Or-ed together
		public RequiredIfAttribute([InvokerParameterName] string propertyName, params object[] desiredValues)
		{
			Guard.Against.NullOrWhiteSpace(propertyName, nameof(propertyName));
			Guard.Against.Null(desiredValues, nameof(desiredValues));

			this.propertyName = propertyName;
			this.desiredValues = desiredValues;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			Type type = validationContext.ObjectInstance.GetType();
			object propertyValue = type.GetProperty(this.propertyName)?.GetValue(validationContext.ObjectInstance, null);

			foreach(object desiredValue in this.desiredValues)
			{
				if(propertyValue?.ToString() == desiredValue?.ToString())
				{
					ValidationResult validationResult = base.IsValid(value, validationContext);
					return validationResult;
				}
			}

			return ValidationResult.Success;
		}

		public bool IsRequired(object objectInstance)
		{
			Type type = objectInstance.GetType();
			object propertyValue = type.GetProperty(this.propertyName)?.GetValue(objectInstance, null);

			bool isRequired = false;

			foreach(object desiredValue in this.desiredValues)
			{
				isRequired |= propertyValue?.ToString() == desiredValue?.ToString();
			}

			return isRequired;
		}
	}
}
