namespace WeQuestion.Common
{
    public static class Check
    {
        public static bool IsEmptyOrWhitespace(string value) => (value != null) && value.Trim() == string.Empty;
        public static bool IsNullOrEmptyOrWhitespace(string value) => (value == null) || IsEmptyOrWhitespace(value);
    }
}
