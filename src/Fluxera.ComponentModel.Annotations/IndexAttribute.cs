namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using JetBrains.Annotations;

	/// <summary>
	///     An attribute to provide an index of the entity. <br/>
	///		To create the actual indices consult the underlying stores documentation.
	/// </summary>
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
