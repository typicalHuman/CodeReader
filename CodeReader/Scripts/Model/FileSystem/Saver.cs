using Associations;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CodeReader.Scripts.FileSystem
{
    internal static class Saver
    {
       
        internal static void associate()
        {
            // Initializes a new AF_FileAssociator to associate the .ABC file extension.
            AF_FileAssociator assoc = new AF_FileAssociator(".cdrd");

            // Creates a new file association for the .ABC file extension. 
            // Data is overwritten if it already exists.
            assoc.Create("My_App",
                "My application's file association",
                new ProgramIcon(@"C:\Users\HP\Desktop\bn.ico"),
                new ExecApplication(@"C:\files\Programming\Projects\CodeReader\CodeReader\bin\Debug\CodeReader.exe"),
                new OpenWithList(new string[] { "My_App" }));
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        internal static void Save(CodeComponentsCollection components, string path)
        {
            string jsonString = Serializer.Serialize(components);
            string encodedString = Encoder64.Encode(jsonString);
            using (StreamWriter sw = new StreamWriter(@"C:\Users\HP\Desktop\test.cdrd"))
                sw.Write(encodedString);
        }

        internal static CodeComponentsCollection Open(string path)
        {
            string encodedData = File.ReadAllText(@"C:\Users\HP\Desktop\test.cdrd");
            string jsonString = Encoder64.Decode(encodedData);
            CodeComponentsCollection components = Serializer.Deserialize(jsonString);
            return components;
        }

    }
}
