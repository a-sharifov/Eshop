namespace Contracts.Enumurations;

public class Role(int value, string name) 
    : Enumeration<Role>(value, name)
{
    public static readonly Role User = new(0, nameof(User));
    public static readonly Role Admin = new(1, nameof(Admin));
}
