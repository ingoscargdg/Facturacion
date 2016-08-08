using System.IO;

namespace Alis.Utils.IO
{
    public static class File
    {
        public static byte[] GetBytes(string fileName)
        {
            using (Stream stm = new FileStream(fileName, FileMode.Open))
            {
                byte[] fbytes = new byte[stm.Length];
                stm.Seek(0, SeekOrigin.Begin);
                stm.Read(fbytes, 0, (int)stm.Length);
                stm.Close();
                return fbytes;
            }
        }
    }
}
