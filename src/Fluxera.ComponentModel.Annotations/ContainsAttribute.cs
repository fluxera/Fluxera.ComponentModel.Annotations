namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using Guards;
	using JetBrains.Annotations;

	/// <summary>
	///		A validation that checks if the annotated property contains the given check value.
	/// </summary>
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class ContainsAttribute : ValidationAttribute
	{
		public ContainsAttribute(string part)
		{
			Guard.Against.NullOrEmpty(part, nameof(part));

			this.Part = part;
		}

		public string Part { get; }

		public override bool IsValid(object value)
		{
			if(value is string stringValue)
			{
				bool contains = !string.IsNullOrWhiteSpace(stringValue) && stringValue.Contains(this.Part);
				return contains;
			}

			throw new InvalidOperationException("The attribute can only be used with string properties.");
		}
	}
}
