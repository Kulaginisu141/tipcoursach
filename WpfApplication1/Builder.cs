using System.IO;

namespace WpfApplication1 {
    /// <summary>
    /// 1. Строитель – для создания или открытия проекта;
    /// </summary>
    class Builder 
    {
        public static byte[] Load(string path) {
            return File.ReadAllBytes(path);
        }
    }
}