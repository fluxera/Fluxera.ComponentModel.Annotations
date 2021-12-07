// ReSharper disable once CheckNamespace

namespace System.ComponentModel.DataAnnotations
{
	using JetBrains.Annotations;

	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
	public sealed class SelectAttribute : DataTypeAttribute
	{
		public SelectAttribute() : base("SelectEnum")
		{
		}

		/// <inheritdoc />
		public SelectAttribute(string optionsPropertyName) : base("Select")
		{
			this.OptionsPropertyName = optionsPropertyName;
		}

		public string OptionsPropertyName { get; }

		public bool HasEmptyOption { get; set; } = true;

		//public string EmptyOption { get; set; }

		public Type ResourceType { get; set; }
	}
}
