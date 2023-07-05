using Microsoft.IdentityModel.Tokens;

namespace INT.ImageGenerator.API.Validators
{
    public static class Validator
    {
        // query validation:
        //    - query is optional
        //    - query should contain minimum 2 words
        //    - query should contain maximum 15 words
        //    - query should not contain any special characters
        public static bool ValidateQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return true;
            }

            if (query.Split(' ').Length < 2 || query.Split(' ').Length > 15)
            {
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(query, "[^a-zA-Z0-9 ]"))
            {
                return false;
            }

            return true;
        }
    }
}
