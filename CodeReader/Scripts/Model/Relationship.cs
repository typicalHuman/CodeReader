using CodeReader.Scripts.Enums;
using CodeReader.Scripts.Interfaces;
using System;
namespace CodeReader.Scripts
{
    /// <summary>
    /// Class designed for management Code Components and creating new associated relationships.  
    /// </summary>
    class Relationship: IRelationship
    {
        public Tuple<ICodeComponent, ICodeComponent> Objects { get; set; }

        public RelationshipType Type { get; set; }

        /// <summary>
        /// Create relationship between two code components.
        /// </summary>
        public static void CreateRelationship(ICodeComponent participant1, ICodeComponent participant2, RelationshipType type)
        {

        }
    }
}
