namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using Guards;
	using JetBrains.Annotations;

	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class ReferenceAttribute : Attribute
	{
		public ReferenceAttribute(Type referencedEntityType)
		{
			Guard.Against.Null(referencedEntityType, nameof(referencedEntityType));

			this.ReferencedEntityType = referencedEntityType;
		}

		public Type ReferencedEntityType { get; }
	}
}
