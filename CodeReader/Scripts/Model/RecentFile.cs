namespace CodeReader.Scripts.Model
{
    public class RecentFile
    {
        /// <summary>
        /// File location.
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// File name.
        /// </summary>
        public string Name { get; set; }

        public string GetPath()
        {
            return $"{Location}\\{Name}.cb";
        }
    }
}
