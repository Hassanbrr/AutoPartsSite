namespace AutoPartsSite.Application.Help
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string phrase)
        {
            string str = phrase.ToLowerInvariant().Trim();

            str = str.Replace("‌", "-") // نیم‌فاصله به خط فاصله
                .Replace(" ", "-")
                .Replace("ي", "ی")
                .Replace("ك", "ک");

            str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-zA-Z0-9\-ء-ياآ]", "-");
            str = System.Text.RegularExpressions.Regex.Replace(str, @"-+", "-");
            return str.Trim('-');
        }
    }

}
