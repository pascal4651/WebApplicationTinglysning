using System.IO;
using System.Xml.Serialization;

namespace WebApplicationTinglysning.Servises
{
    public static class XmlSerializerHelper<T>
    {
        public static T Deserialaize(string xml)
        {
            var result = default(T);

            using (TextReader textReader = new StringReader(xml))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T));
                result = (T)deserializer.Deserialize(textReader);
            }
            return result;
        }
    }
}
