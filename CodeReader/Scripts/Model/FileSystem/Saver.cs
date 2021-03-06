using Associations;
using CodeBox.Enums;
using CodeReader.Scripts.Interfaces;
using CodeReader.Scripts.Model;
using System.Linq;
using CodeReader.Scripts.ViewModel;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace CodeReader.Scripts.FileSystem
{
    internal static class Saver
    {

        #region Properties

        #endregion

        #region Constants

        private const string PROG_ID = "CodeReader";

        private const string ASSOCIATION_DESCRIPTION = "Association cb files with special program which will read data " +
            "and convert it to info about code components.";

        private const string ICON_FILE_PATH = "bookIcon.ico";

        private const string FILES_HISTORY_FILE_NAME = "recentfiles.json";

        #endregion

        /// <summary>
        /// The instance for creating file associations.
        /// </summary>
        private static AF_FileAssociator _associator { get; set; } = new AF_FileAssociator(MainWindow.FILE_EXTENSION);

        internal static bool TryAssociate()
        {
            try
            {
                string applicationPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string iconPath = Path.GetFullPath(ICON_FILE_PATH);
                _associator.Create(PROG_ID,
                    ASSOCIATION_DESCRIPTION,
                    new ProgramIcon(iconPath),
                    new ExecApplication(applicationPath),
                    new OpenWithList(new string[] { PROG_ID }));
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        internal static void Save(CodeComponentsCollection components, string path)
        {
            string jsonString = Serializer.Serialize(components);
            string encodedString = Encoder64.Encode(jsonString);
            using (StreamWriter sw = new StreamWriter(path))
                sw.Write(encodedString);
        }

        internal static CodeComponentsCollection Open(string path)
        {
            string encodedData = File.ReadAllText(path);
            string jsonString = Encoder64.Decode(encodedData);
            CodeComponentsCollection components = Serializer.Deserialize(jsonString);
            return components;
        }

        internal static ICodeComponent ImportCode(string path)
        {
            string srcCode = File.ReadAllText(path);
            ICodeComponent comp = new CodeComponent
            {
                Code = srcCode,
                Language = GetLanguageByPath(path)
            };
            return comp;
        }

        private static Languages GetLanguageByPath(string path)
        {
            string extension = Path.GetExtension(path);
            switch (extension)
            {
                case ".cs": return Languages.CSharp;
                case ".cpp": return Languages.CPP;
                case ".h": return Languages.CPP;
                case ".c": return Languages.C;
                case ".py": return Languages.Python;
                case ".js": return Languages.JS;
                case ".php": return Languages.PHP;
                default: return Languages.Assembly;
            }
        }


        public static void SaveFilesHistory(RecentFilesList files)
        {
            string json = Serializer.SerializeFilesHistory(files);
            File.WriteAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + FILES_HISTORY_FILE_NAME, json);
        }

        public static RecentFilesList LoadFilesHistory()
        {
            string fp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + FILES_HISTORY_FILE_NAME;
            if (File.Exists(fp))
            {
                string json = File.ReadAllText(fp);
                var des = Serializer.DeserializeFilesHistory(json);
                RecentFilesList rf = new RecentFilesList();
                rf.AddRange(des);
                return rf;
            }
            return null;
        }

    }
}
