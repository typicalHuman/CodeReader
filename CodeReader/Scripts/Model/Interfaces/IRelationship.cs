using CodeReader.Scripts.Enums;

namespace CodeReader.Scripts.Interfaces
{
    /// <summary>
    /// Interface for realization of abstraction - Relationship.
    /// </summary>
    public interface IRelationship
    {
        //// <summary>
        /// Main participant of relationships.
        /// </summary>
        ICodeComponent MainParticipant { get; }
        /// <summary>
        /// Second participant of relationships.
        /// </summary>
        ICodeComponent DependentParticipant { get; }
        /// <summary>
        /// Type of <see cref="Objects"/> relationship.
        /// </summary>
        RelationshipType Type { get; }

    }
}
