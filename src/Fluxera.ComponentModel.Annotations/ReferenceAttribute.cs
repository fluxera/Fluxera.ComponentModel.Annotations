namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using Guards;
	using JetBrains.Annotations;

	/// <summary>
	///		An attribute to signal potential data stores that this property should be stored as database reference.
	/// </summary>
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class ReferenceAttribute : Attribute
	{
		public ReferenceAttribute(Type referencedEntityType)
		{
			Guard.Against.Null(referencedEntityType, nameof(referencedEntityType));

			this.ReferencedEntityType = referencedEntityType;
		}

		public ReferenceAttribute(string referencedTypeName)
		{
			Guard.Against.NullOrWhiteSpace(referencedTypeName, nameof(referencedTypeName));

			this.ReferencedTypeName = referencedTypeName;
		}

		public Type? ReferencedEntityType { get; }

		public string? ReferencedTypeName { get; }
	}
}
