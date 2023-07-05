using INT.ImageGenerator.API.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /*
     Test scenarios:
    - If query is null, return true
    - If query is empty, return true
    - If query contains less than 2 words, return false
    - If query contains more than 15 words, return false
    - If query contains special characters, return false
    - If query contains only letters and numbers, return true
     */
    public class ValidatorTests
    {
        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("a", false)]
        [InlineData("a b", true)]
        [InlineData("a b c d e f g h i j k l m n o", true)]
        [InlineData("a b c d e f g h i j k l m n o p", false)]
        [InlineData("a b c z !", false)]
        [InlineData(" ", true)]
        public void ValidateQuery(string query, bool expected)
        {
            var result = Validator.ValidateQuery(query);
            Assert.Equal(expected, result);
        }
    }
}
