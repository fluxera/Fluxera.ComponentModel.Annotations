namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using JetBrains.Annotations;

	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class IgnoreAttribute : Attribute
	{
	}
}
