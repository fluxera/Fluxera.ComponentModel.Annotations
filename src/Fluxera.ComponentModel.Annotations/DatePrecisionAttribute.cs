namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using JetBrains.Annotations;

	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class DatePrecisionAttribute : Attribute
	{
		public DatePrecisionAttribute(byte precision)
		{
			this.Precision = precision;
		}

		public byte Precision { get; }
	}
}
