namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using JetBrains.Annotations;

	/// <summary>
	///     An attribute to provide the composite indices of an entity. <br/>
	///		To create the actual indices consult the underlying stores documentation.
	/// </summary>
	/// <seealso cref="Attribute" />
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class CompositeIndexAttribute : Attribute
	{
		public CompositeIndexAttribute(params string[] propertyNames)
		{
			this.PropertyNames = propertyNames;
			this.IsUnique = false;
		}

		public string[] PropertyNames { get; }

		public bool IsUnique { get; set; }

		public IndexOrder Order { get; set; } = IndexOrder.Ascending;
	}
}
