using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Emash.GeoPatNet.Generator.Services
{
    public class SerializationService
    {
        public T UnzipAndDeserialize<T>(String fileName)
        {
            String tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempPath);
            ZipFile.ExtractToDirectory(fileName, tempPath);
            String tempFileName = Path.Combine(tempPath, "Data.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream stream = new FileStream(tempFileName, FileMode.Open);
            StreamReader reader = new StreamReader (stream,System.Text.Encoding.UTF8);
            T value = (T)serializer.Deserialize(reader);
            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();
            Directory.Delete(tempPath, true);
            return value;
        }


        public void SerializeAndZip<T>(String fileName,T value)
        {
            String tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempPath);
            String tempFileName = Path.Combine(tempPath, "Data.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream stream = new FileStream(tempFileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
            serializer.Serialize(writer, value);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
            if (File.Exists(fileName))
            {File.Delete(fileName);}
            ZipFile.CreateFromDirectory(tempPath, fileName);
            Directory.Delete(tempPath, true);
        }

    }
}
