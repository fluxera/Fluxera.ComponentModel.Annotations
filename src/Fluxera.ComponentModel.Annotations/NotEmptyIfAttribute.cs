namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using Guards;
	using JetBrains.Annotations;

	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class NotEmptyIfAttribute : NotEmptyAttribute
	{
		private readonly object[] desiredValues;
		private readonly string propertyName;

		public NotEmptyIfAttribute(string propertyName, params object[] desiredValues)
		{
			Guard.Against.Null(desiredValues, nameof(desiredValues));

			this.propertyName = propertyName;
			this.desiredValues = desiredValues;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			object instance = validationContext.ObjectInstance;
			Type type = instance.GetType();

			object propertyValue = type.GetProperty(this.propertyName)?.GetValue(instance, null);

			foreach(object desiredValue in this.desiredValues)
			{
				if(propertyValue?.ToString() == desiredValue?.ToString())
				{
					ValidationResult result = base.IsValid(value, validationContext);
					return result;
				}
			}

			return ValidationResult.Success;
		}
	}
}
