namespace Email.Templates;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    public static readonly string AssemblyPath = Path.GetDirectoryName(Assembly.Location)!;
}
