using System;

namespace CodeReader.Scripts.Model
{
    public static class IDGenerator
    {
        public static string GenerateID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
