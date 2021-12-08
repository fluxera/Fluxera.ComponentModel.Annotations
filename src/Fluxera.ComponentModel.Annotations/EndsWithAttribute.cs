namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using Guards;
	using JetBrains.Annotations;

	/// <summary>
	///		A validation attribute that checks if the value end with the given value.
	/// </summary>
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class EndsWithAttribute : ValidationAttribute
	{
		public EndsWithAttribute(string end,
			StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
		{
			Guard.Against.NullOrEmpty(end, nameof(end));

			this.End = end;
			this.StringComparison = stringComparison;
		}

		public string End { get; }

		public StringComparison StringComparison { get; }

		public override bool IsValid(object value)
		{
			if(value is string stringValue)
			{
				bool endsWith = !string.IsNullOrWhiteSpace(stringValue) && stringValue.EndsWith(this.End, this.StringComparison);
				return endsWith;
			}

			throw new InvalidOperationException("The attribute can only be used with string properties.");
		}
	}
}
