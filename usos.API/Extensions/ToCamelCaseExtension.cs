namespace usos.API.Extensions
{
    public static class ToCamelCaseExtension
    {
        public static string ToCamelCase(this string name)
        {
            return string.IsNullOrEmpty(name)
                ? name
                : name[..1].ToLower() + name[1..];
        }
    }
}