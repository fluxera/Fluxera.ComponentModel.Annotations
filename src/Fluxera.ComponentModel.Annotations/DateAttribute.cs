// ReSharper disable once CheckNamespace

namespace System.ComponentModel.DataAnnotations
{
	using JetBrains.Annotations;

	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
	public sealed class DateAttribute : DataTypeAttribute
	{
		/// <inheritdoc />
		public DateAttribute() : base(DataType.Date)
		{
		}
	}
}
