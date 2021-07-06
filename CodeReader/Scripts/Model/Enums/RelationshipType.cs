namespace CodeReader.Scripts.Model
{
    /// <summary>
    /// Enum for different types of code objects relations.
    /// </summary>
    public enum RelationshipType
    {
        Dependency,//one object works with another object
        Association,//object of one class knows about object of another class
        Aggregation,//'has a'
        Composition,//'part of' 
        Inheritance//'is a'
    }
}
