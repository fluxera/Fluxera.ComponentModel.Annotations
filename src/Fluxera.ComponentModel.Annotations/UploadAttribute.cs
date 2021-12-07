// ReSharper disable once CheckNamespace

namespace System.ComponentModel.DataAnnotations
{
	using JetBrains.Annotations;

	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
	public sealed class UploadAttribute : DataTypeAttribute
	{
		/// <inheritdoc />
		public UploadAttribute() : base(DataType.Upload)
		{
		}
	}
}
