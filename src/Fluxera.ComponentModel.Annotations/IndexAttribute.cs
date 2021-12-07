namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using JetBrains.Annotations;

	/// <summary>
	///     Property marker attribute to show an index of the entity. To create
	///     the actual indices consult the underlying stores documentation.
	/// </summary>
	/// <seealso cref="Attribute" />
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class IndexAttribute : Attribute
	{
		public IndexAttribute()
		{
			this.IsUnique = false;
		}

		public bool IsUnique { get; set; }

		public IndexOrder Order { get; set; } = IndexOrder.Ascending;
	}
}
