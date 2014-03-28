using Emash.GeoPat.Generator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Emash.GeoPat.Generator.IO
{
    public class ProjectReader
    {
         public String FileName { get; private set; }

         public ProjectReader(String fileName)
        {
            this.FileName = fileName;
          
        }


         public Project Read()
         {
             Project result = null;
             XmlSerializer serializer = new XmlSerializer(typeof(Project));
             using (FileStream stream = new FileStream(this.FileName, FileMode.Open))
             {
                 using (StreamReader reader = new StreamReader(stream))
                 {result = serializer.Deserialize(reader) as Project ;}
             }
             serializer = null;
             return result;
         }
    }
}
