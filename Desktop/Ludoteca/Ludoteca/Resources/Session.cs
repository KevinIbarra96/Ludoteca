using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System;
using System.Xml.Serialization;

namespace Ludoteca.Resources
{
    public class Session
    {
        public  static string SessionId { get; set; }
        public static  int UserId { get; set;}
        public static  string UserName { get; set; }
        public static  string RolName { get; set; }
        public static int RolId { get; set; }

 
        private const string xmlFilePath = "session.xml";

        // Método para guardar la sesión en un archivo XML
    public static void SaveSession()
    {
        try
        {
            // Crear un objeto XmlSerializer para la clase Session
            XmlSerializer serializer = new XmlSerializer(typeof(Session));
            using (TextWriter writer = new StreamWriter(xmlFilePath))
            {
                serializer.Serialize(writer, typeof(Session));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al guardar la sesión: " + ex.Message);
        }
    }

    // Método para cargar la sesión desde un archivo XML
    public static void LoadSession()
    {
        try
        {
            if (File.Exists(xmlFilePath))
            {
                
                XmlSerializer serializer = new XmlSerializer(typeof(Session));

                using (TextReader reader = new StreamReader(xmlFilePath))
                {
                    // Deserializar el archivo XML y cargar la información en la instancia de Session
                    Session session = (Session)serializer.Deserialize(reader);
                        SessionId = Session.SessionId;
                        UserId = Session.UserId;
                        UserName = Session.UserName;
                        RolName = Session.RolName;
                        RolId = Session.RolId;
                    }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar la sesión: " + ex.Message);
        }
    }
        

    }

}
