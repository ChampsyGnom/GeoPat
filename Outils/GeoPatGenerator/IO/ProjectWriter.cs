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
    public  class ProjectWriter
    {
        public String FileName { get; private set; }
        public Project Project { get; private set; }

        public ProjectWriter(String fileName, Project project)
        {
            this.FileName = fileName;
            this.Project = project;
        }

        public void Write()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Project));
            using (FileStream stream = new FileStream(this.FileName, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {serializer.Serialize(writer, this.Project);}
            }
            serializer = null;
          
        }
    }
}
