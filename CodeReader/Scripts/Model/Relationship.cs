using CodeReader.Scripts.Enums;
using CodeReader.Scripts.Interfaces;

namespace CodeReader.Scripts
{
    /// <summary>
    /// Class designed for management Code Components and creating new associated relationships.  
    /// </summary>
    class Relationship: IRelationship
    {

        #region Ctor

        /// <summary>
        /// Private constructor for initializing participants and relationship type.
        /// </summary>
        private Relationship(ICodeComponent main, ICodeComponent dependent, RelationshipType type)
        {
            MainParticipant = main;
            DependentParticipant = dependent;
            Type = type;
        }

        #endregion

        #region Properties

        public ICodeComponent MainParticipant { get; private set; }

        public ICodeComponent DependentParticipant { get; private set; }

        public RelationshipType Type { get; set; }

        #endregion

        #region Methods

        #region Static

        /// <summary>
        /// Create relationship between two code components.
        /// </summary>
        public static void CreateRelationship(ICodeComponent main, ICodeComponent dependent, RelationshipType type)
        {
            Relationship r = new Relationship(main, dependent, type);
            main.Relationships.Add(r);
            dependent.Relationships.Add(r);
        }

        #endregion

        #region Non-static

        /// <summary>
        /// Define is <paramref name="component"/> main participant or dependent.
        /// </summary>
        public bool IsMainParticipant(ICodeComponent component)
        {
            return component == MainParticipant;
        }

        #endregion

        #endregion
    }
}
