namespace ExampleApp.Configuration;

[AttributeUsage(AttributeTargets.Property)]
public class VariableAttribute : Attribute
{
    public readonly string Key;
    public readonly bool Required;
    public readonly string DefaultValue;

    public VariableAttribute(string key, bool required)
    {
        Key = key;
        Required = required;
    }
    public VariableAttribute(string key, string defaultValue)
    {
        Key = key;
        DefaultValue = defaultValue;
    }
}