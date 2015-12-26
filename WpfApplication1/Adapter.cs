using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApplication1 {
    /// <summary>
    /// 2. Адаптер – для инкапсуляции сохранения файла;
    /// </summary>
    internal class Adapter {
        public static bool WriteModel(Model model, string path) {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream s = new MemoryStream();
            formatter.Serialize(s,model);
            s.Seek(0, SeekOrigin.Begin);
            var data = s.ToArray();
            s.Close();
            return Saver.Save(data,path);
        }
        public static Model ReadModel(string path) {
            var data = Builder.Load(path);
            Stream s = new MemoryStream(data);
            IFormatter formatter = new BinaryFormatter();
            var model = (Model)formatter.Deserialize(s);
            s.Close();
            return model;
        }
    }
}