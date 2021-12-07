﻿namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using System.Collections;
	using System.ComponentModel.DataAnnotations;
	using JetBrains.Annotations;

	/// <summary>
	///     Checks if an enumerable contains at least one element.
	/// </summary>
	/// <seealso cref="ValidationAttribute" />
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property)]
	public class NotEmptyAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if(value is IEnumerable items)
			{
				// ReSharper disable PossibleMultipleEnumeration
				bool hasNext = items.GetEnumerator().MoveNext();
				items.GetEnumerator().Reset();
				// ReSharper restore PossibleMultipleEnumeration

				return hasNext;
			}

			throw new InvalidOperationException("The attribute can only be used with IEnumerable properties.");
		}
	}
}
