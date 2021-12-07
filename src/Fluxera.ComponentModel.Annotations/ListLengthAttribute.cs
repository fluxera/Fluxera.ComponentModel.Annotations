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
	public sealed class ListLengthAttribute : ValidationAttribute
	{
		public ListLengthAttribute(int maximumLength)
		{
			Guard.Against.Negative(maximumLength, nameof(maximumLength));

			this.MaximumLength = maximumLength;
		}

		/// <summary>
		///     Gets the maximum acceptable length of the enumerable.
		/// </summary>
		private int MaximumLength { get; }

		/// <summary>
		///     Gets or sets the minimum acceptable length of the enumerable.
		/// </summary>
		public int MinimumLength { get; set; }

		public override bool IsValid(object value)
		{
			if(value is IEnumerable items)
			{
				long length = items.Cast<object>().LongCount();
				return (length >= this.MinimumLength) && (length <= this.MaximumLength);
			}

			throw new InvalidOperationException("The attribute can only be used with IEnumerable properties.");
		}
	}
}
