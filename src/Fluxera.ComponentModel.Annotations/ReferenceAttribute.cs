namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using Fluxera.Guards;
	using JetBrains.Annotations;

	/// <summary>
	///     An attribute to signal potential data stores that this property should be stored as database reference.
	/// </summary>
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class ReferenceAttribute : Attribute
	{
		/// <summary>
		///     Creates a new instance of the <see cref="ReferenceAttribute" /> type.
		/// </summary>
		/// <param name="referencedEntityType"></param>
		public ReferenceAttribute(Type referencedEntityType)
		{
			Guard.Against.Null(referencedEntityType, nameof(referencedEntityType));

			this.ReferencedEntityType = referencedEntityType;
		}

		/// <summary>
		///     Creates a new instance of the <see cref="ReferenceAttribute" /> type.
		/// </summary>
		/// <param name="referencedTypeName"></param>
		public ReferenceAttribute(string referencedTypeName)
		{
			Guard.Against.NullOrWhiteSpace(referencedTypeName, nameof(referencedTypeName));

			this.ReferencedTypeName = referencedTypeName;
		}

		/// <summary>
		///     Gets the type of the referenced entity.
		/// </summary>
		public Type ReferencedEntityType { get; }

		/// <summary>
		///     Gets the name of the type of the referenced entity.
		/// </summary>
		public string ReferencedTypeName { get; }
	}
}
