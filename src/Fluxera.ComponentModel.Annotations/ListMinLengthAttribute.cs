namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using System.Collections;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using Guards;
	using JetBrains.Annotations;

	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class ListMinLengthAttribute : ValidationAttribute
	{
		public ListMinLengthAttribute(int minimumLength)
		{
			Guard.Against.Negative(minimumLength, nameof(minimumLength));

			this.MinimumLength = minimumLength;
		}

		/// <summary>
		///     Gets or sets the minimum acceptable length of the enumerable.
		/// </summary>
		private int MinimumLength { get; }

		public override bool IsValid(object value)
		{
			if(value is IEnumerable items)
			{
				long length = items.Cast<object>().LongCount();
				return length >= this.MinimumLength;
			}

			throw new InvalidOperationException("The attribute can only be used with IEnumerable properties.");
		}
	}
}
