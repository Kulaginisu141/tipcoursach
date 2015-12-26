using System;
using System.IO;

namespace WpfApplication1 {
    /// <summary>
    /// 3. Хранитель – для организации сохранения;
    /// </summary>
    internal class Saver {
        public static bool Save(byte[] content, string path) {
            try {
                File.WriteAllBytes(path, content);
            } catch (Exception) {
                return false;
            }
            return true;
        }
    }
}