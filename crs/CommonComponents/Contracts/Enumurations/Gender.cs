namespace Contracts.Enumurations;

public class Gender(int value, string name) : Enumeration<Gender>(value, name)
{
    public static readonly Gender Male = new(1, nameof(Male));
    public static readonly Gender Female = new(2, nameof(Female));
    public static readonly Gender Undefined = new(3, nameof(Undefined));
}
