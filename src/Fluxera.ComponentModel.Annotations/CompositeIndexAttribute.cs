namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using JetBrains.Annotations;

	/// <summary>
	///     Class marker attribute to show the composite indices of the entity. To create
	///     the actual indices consult the underlying stores documentation.
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
