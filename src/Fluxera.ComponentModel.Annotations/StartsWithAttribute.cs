namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using Guards;
	using JetBrains.Annotations;

	/// <summary>
	///		A validation attribute that checks if the value starts with the given value.
	/// </summary>
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class StartsWithAttribute : ValidationAttribute
	{
		public StartsWithAttribute(string start,
			StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
		{
			Guard.Against.NullOrEmpty(start, nameof(start));

			this.Start = start;
			this.StringComparison = stringComparison;
		}

		public string Start { get; }

		public StringComparison StringComparison { get; }

		//public override string FormatErrorMessage(string name)
		//{
		//    var errorMessage = this.ErrorMessage.FormatInvariantWith(name, this.Start);
		//    return errorMessage;
		//}

		public override bool IsValid(object value)
		{
			if(value is string stringValue)
			{
				bool startsWith = !string.IsNullOrWhiteSpace(stringValue) &&
					stringValue.StartsWith(this.Start, this.StringComparison);
				return startsWith;
			}

			throw new InvalidOperationException("The attribute can only be used with string properties.");
		}
	}
}
