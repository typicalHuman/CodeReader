namespace CodeReader.Scripts.Model
{
    /// <summary>
    /// Enum for defining type of tree's component.
    /// </summary>
    public enum CodeComponentType
    {
        Code, AbstractClass, Attribute,
        Class, Delegate, Enum,
        Event, Indexer, Interface,
        Variable, Method, Namespace,
        Property, Struct
    }
}
