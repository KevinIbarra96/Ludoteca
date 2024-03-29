using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Ludoteca.Resources
{
    public class AccionesSession
    {

        private static string xmlFilePath = AppDomain.CurrentDomain.BaseDirectory + "session.xml";

        public static void LLenarValoresSession(EN_User userData)
        {
            // Llenar la clase Session con los datos del usuario
            Session.SessionId = Guid.NewGuid().ToString();
            Session.UserId = userData.id;
            Session.UserName = userData.UserName;
            Session.RolName = userData.RolName;
            Session.RolId = userData.idRol;
            Session.SessionActiva = true;
            Session.HoraInicioSession = DateTime.Now;
        }


        // Método para guardar la sesión en un archivo XML
        public static void SaveSession()
        {
            try
            {
                // Crear un objeto XmlSerializer para la clase Session
                var sessionxml = new XElement("Session",
                    new XElement("SessionId", Session.SessionId),
                    new XElement("UserName", Session.UserName),
                    new XElement("RolName", Session.RolName),
                    new XElement("UserId", Session.UserId),
                    new XElement("RolId", Session.RolId),
                    new XElement("SessionActiva", Session.SessionActiva),
                    new XElement("HoraInicioSession", Session.HoraInicioSession)
                    );
                sessionxml.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la sesión: " + ex.Message);
            }
        }

        public static bool VerificarSession()
        {
            bool SessionActiva = true;
            try
            {

                if (File.Exists(xmlFilePath))
                {
                    XDocument doc = XDocument.Load(xmlFilePath, LoadOptions.None);
                    bool isSesionActive = bool.Parse(doc.Element("Session").Element("SessionActiva").Value);
                    

                        if (isSesionActive == SessionActiva)
                        {
                            Session.SessionId = doc.Element("Session").Element("SessionId").Value; ;
                            Session.UserId = int.Parse(doc.Element("Session").Element("UserId").Value);
                            Session.UserName = doc.Element("Session").Element("UserName").Value;
                            Session.RolName = doc.Element("Session").Element("RolName").Value;
                            Session.RolId = int.Parse(doc.Element("Session").Element("RolId").Value);
                            Session.SessionActiva = isSesionActive;
                            
                            // La sesión está activa, se redirige a la página principal
                            App.Current.MainPage = new AppShell();   
                        }
                        else
                        {
                            // La sesión no está activa, se redirige a la página de inicio de sesión
                            App.Current.MainPage = new Login();
                        }
                    
                }
                else
                {
                    // No hay archivo de sesión, se redirige a la página de inicio de sesión
                    App.Current.MainPage = new Login();
                }
            }
            catch (Exception ex)
            {
                SessionActiva = false;
            }

            return SessionActiva;
        }

        public static void CerrarSession()
        {
            try
            {
                // Crear un archivo XML vacío
                Session.SessionId = "";
                Session.SessionActiva = false;


                SaveSession();

                Console.WriteLine("¡La sesión se ha cerrado correctamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la sesión: " + ex.Message);
            }
        }
        

    }
}
