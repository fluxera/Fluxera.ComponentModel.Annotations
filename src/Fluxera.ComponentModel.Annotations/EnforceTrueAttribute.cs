namespace Fluxera.ComponentModel.Annotations
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using JetBrains.Annotations;

	/// <summary>
	///     http://stackoverflow.com/questions/4730183/mvc-model-require-true/9036075#9036075
	/// </summary>
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class EnforceTrueAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if(value == null)
			{
				return false;
			}

			if(value.GetType() != typeof(bool))
			{
				throw new InvalidOperationException("Can only be used on boolean properties.");
			}

			return (bool)value;
		}
	}
}
