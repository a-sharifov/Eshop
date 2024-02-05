namespace Email.Infrastructure.Email;

/// <summary>
/// This class is used to get the path of the email templates.
/// </summary>
public static class EmailTemplatePath
{
    /// <summary>
    /// required change this template: {{firstName}}, {{lastName}}, {{confirmationLink}}
    /// </summary>
    public static string ConfirmEmailTemplate => GetTemplatePath("ConfirmEmailTemplate.html");


    private static string GetTemplatePath(string templateName) =>
        Path.Combine(Templates.AssemblyReference.AssemblyPath, "Templates", templateName);
}
