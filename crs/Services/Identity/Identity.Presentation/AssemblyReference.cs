namespace Identity.Presentation;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    public static readonly string AssemblyPath = Path.GetDirectoryName(Assembly.Location)!;
}
