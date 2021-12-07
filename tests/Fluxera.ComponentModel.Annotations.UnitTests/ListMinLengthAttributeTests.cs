﻿namespace Fluxera.ComponentModel.Annotations.UnitTests
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class ListMinLengthAttributeTests
	{
		[Test]
		public void ShouldHaveValidationError_TooLess()
		{
			// Arrange  
			TestClass obj = new TestClass();
			obj.ListMinLengthList = new List<object>();
			obj.ListMinLengthList.Add(new object());

			// Act
			ICollection<ValidationResult> results = new List<ValidationResult>();
			bool result = Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);

			// Assert
			result.Should().BeFalse();
			results.Count.Should().Be(1);
		}

		[Test]
		public void ShouldNotHaveValidationError()
		{
			// Arrange
			TestClass obj = new TestClass();
			obj.ListMinLengthList = new List<object>();
			for(int i = 0; i < 10; i++)
			{
				obj.ListMinLengthList.Add(new object());
			}

			// Act
			ICollection<ValidationResult> results = new List<ValidationResult>();
			bool result = Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);

			// Assert
			result.Should().BeTrue();
			results.Count.Should().Be(0);
		}
	}
}
