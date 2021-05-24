using BasicCSharp.Common;
using System;
using Xunit;

namespace BasicCSharp
{
    public class OtherOperators
    {
        [Fact]
        public void should_use_ternary_conditional_operator_for_conditional_value_assignments()
        {
            bool trueStatement = (1 + 1 == 2) ? true : false;
            string falseStatement = (1 + 1 == 3) ? "true" : "false";

            var expectedTrueStatement = true;
            var expectedFalseStatement = "false";

            Assert.Equal(expectedTrueStatement, trueStatement);
            Assert.Equal(expectedFalseStatement, falseStatement);
        }

        [Fact]
        public void should_use_double_ampersand_for_logical_AND_expression()
        {
            bool trueStatement = true && true;
            bool falseStatement = true && false;

            var expectedTrueStatement = true;
            var expectedFalseStatement = false;

            Assert.Equal(expectedTrueStatement, trueStatement);
            Assert.Equal(expectedFalseStatement, falseStatement);
        }

        [Fact]
        public void should_use_double_pipe_for_logical_OR_expression()
        {
            bool trueStatement = false || true;
            bool falseStatement = false || false;

            // change boolean values to 
            var expectedTrueStatement = true;
            var expectedFalseStatement = false;

            Assert.Equal(expectedTrueStatement, trueStatement);
            Assert.Equal(expectedFalseStatement, falseStatement);
        }

        [Fact]
        public void should_be_aware_of_short_circuit_behaviour()
        {
            Func<bool> throwException = () => { throw new NotImplementedException("should not be called"); };

            // change boolean values to avoid an exception being thrown
            bool expectedAndResult = false && throwException();
            bool expectedOrResult = true || throwException();

            Assert.False(expectedAndResult);
            Assert.True(expectedOrResult);
        }

        [Fact]
        public void should_use_null_coalescing_operator_for_null_checks()
        {
            int? emptyInt = null;
            int? nonNullInt = 13;
            int someDefault = 42;

            var firstCalculation = emptyInt ?? someDefault;
            var secondCalculation = emptyInt ?? nonNullInt ?? someDefault;

            // change expected results to correct values
            var expectedFirstResult = 42;
            var expectedSecondResult = 13;

            Assert.Equal(expectedFirstResult, firstCalculation);
            Assert.Equal(expectedSecondResult, secondCalculation);
        }

        [Fact]
        public void should_be_aware_of_null_coalesces_short_circuit_behaviour()
        {
            Func<bool?> throwException = () => { throw new NotImplementedException("should not be called"); };

            bool? nullBool = null;
            bool? notNullBool = true;

            // change order to avoid an exception being thrown
            bool? expectedTrue = nullBool ?? notNullBool ?? throwException();

            Assert.True(expectedTrue);
        }

        [Fact]
        public void should_use_null_conditional_operator_on_arrays_to_avoid_null_reference_exceptions()
        {
            string[] noPeople = null;
            string[] somePeople = { "chris", "jo", "kim" };

            var somebody = somePeople?[0];
            var nobody = noPeople?[1];

            string expectedNobody = null;
            var expectedSomebody = "chris";

            Assert.Equal(expectedSomebody, somebody);
            Assert.Equal(expectedNobody, nobody);
        }

        [Fact]
        public void should_use_null_conditional_operator_on_objects_to_avoid_null_reference_exceptions()
        {
            AutoPropertyDemoClass chris = new AutoPropertyDemoClass() { Name = "chris" };
            AutoPropertyDemoClass notChris = null;

            var chrisName = chris?.Name;
            var notChrisName = notChris?.Name;

            var expectedChrisName = "chris";
            string expectedNotChrisName = null;

            Assert.Equal(expectedChrisName, chrisName);
            Assert.Equal(expectedNotChrisName, notChrisName);
        }
    }
}