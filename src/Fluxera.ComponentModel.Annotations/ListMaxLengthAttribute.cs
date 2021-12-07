﻿namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using System.Collections;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using Guards;
	using JetBrains.Annotations;

	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class ListMaxLengthAttribute : ValidationAttribute
	{
		public ListMaxLengthAttribute(int maximumLength)
		{
			Guard.Against.Negative(maximumLength, nameof(maximumLength));

			this.MaximumLength = maximumLength;
		}

		/// <summary>
		///     Gets the maximum acceptable length of the enumerable.
		/// </summary>
		private int MaximumLength { get; }

		public override bool IsValid(object value)
		{
			if(value is IEnumerable items)
			{
				long length = items.Cast<object>().LongCount();
				return length <= this.MaximumLength;
			}

			throw new InvalidOperationException("The attribute can only be used with IEnumerable properties.");
		}
	}
}
