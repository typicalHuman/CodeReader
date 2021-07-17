using System;
using System.Text;

namespace CodeReader.Scripts.FileSystem
{
    internal static class Encoder64
    {
        internal static string Encode(string input)
        {
            byte[] toEncodeAsBytes= Encoding.ASCII.GetBytes(input);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        internal static string Decode(string encodedData)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);
            string returnValue = Encoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}