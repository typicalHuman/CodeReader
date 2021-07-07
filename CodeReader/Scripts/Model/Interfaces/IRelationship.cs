using CodeReader.Scripts.Enums;
using System;

namespace CodeReader.Scripts.Interfaces
{
    /// <summary>
    /// Interface for realization of abstraction - Relationship.
    /// </summary>
    public interface IRelationship
    {
        /// <summary>
        /// Two participants of relationship.
        /// </summary>
        Tuple<ICodeComponent, ICodeComponent> Objects { get; }
        /// <summary>
        /// Type of <see cref="Objects"/> relationship.
        /// </summary>
        RelationshipType Type { get; }

    }
}
