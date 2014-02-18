using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.IO
{
    public class TemplateFileWriter
    {
        public String Content { get; set; }
        private String _fileName;
        public List<TemplateProperty> Properties { get; set; }
        public List<String> ModelBuilders { get; set; }

        public TemplateProperty AddProperty(String typeName, String propertyName)
        {
            TemplateProperty prop = new TemplateProperty(typeName, propertyName);
            this.Properties.Add(prop);
            return prop;
        }
        public TemplateFileWriter(String fileName, String templateFileName)
        {
            this._fileName = fileName;
            this.Properties = new List<TemplateProperty>();
            this.ModelBuilders = new List<string>();
            FileStream stream = new FileStream(templateFileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            this.Content = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();

        }

        public void ReplaceTag(String tag, String value)
        {
            this.Content = this.Content.Replace(tag, value);
        }
        public void WriteContent()
        {
            FileStream stream = new FileStream(this._fileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
            StringWriter ws = new StringWriter();
            foreach (TemplateProperty p in this.Properties)
            { 
                foreach (String a in p.Attributes )
                {
                    ws.WriteLine(new String(' ', 8) + a);
                }
                ws.WriteLine(new String(' ', 8) + ""+p.TypeName +" "+p.PropertyName);
                ws.WriteLine(new String(' ', 8) + "{");
                ws.WriteLine(new String(' ', 12) + "get;");               
                ws.WriteLine(new String(' ', 12) + "set;");                
                ws.WriteLine(new String(' ', 8) + "}");
               
            }
            this.Content = this.Content.Replace("@Properties", ws.ToString());
            this.Content = this.Content.Replace("@ModelBuilder",String.Join ("\r\n",(from s in ModelBuilders select "            "+s).ToList ()));
            writer.WriteLine(this.Content);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();

        }
    }
}
