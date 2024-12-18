﻿using Entidad;
using System.Diagnostics;
using System.Xml.Linq;

namespace Ludoteca.Resources
{
    public class AccionesSession
    {

        private static string xmlFilePath = AppDomain.CurrentDomain.BaseDirectory + "session.xml";

        // Método para cargar la sesión desde el archivo XML
        private static void CargarSessionDesdeArchivo()
        {
            if (File.Exists(xmlFilePath))
            {
                XDocument doc = XDocument.Load(xmlFilePath, LoadOptions.None);
                Session.SessionId = doc.Element("Session").Element("SessionId").Value;
                Session.UserId = int.Parse(doc.Element("Session").Element("UserId").Value);
                Session.UserName = doc.Element("Session").Element("UserName").Value;
                Session.RolName = doc.Element("Session").Element("RolName").Value;
                Session.RolId = int.Parse(doc.Element("Session").Element("RolId").Value);
                Session.SessionActiva = bool.Parse(doc.Element("Session").Element("SessionActiva").Value);
                Session.HoraInicioSession = DateTime.Parse(doc.Element("Session").Element("HoraInicioSession").Value);
            }
            else App.Current.MainPage = new Login();
        }

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

            SaveSession();
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

            try
            {
                CargarSessionDesdeArchivo();
                if (Session.SessionActiva)
                {
                    // La sesión está activa, se redirige a la página principal
                    App.Current.MainPage = new AppShell();
                    return true;
                }
                else
                {
                    // La sesión no está activa, se redirige a la página de inicio de sesión
                    App.Current.MainPage = new Login();
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }

            return Session.SessionActiva;
        }

        public static void CerrarSession()
        {
            try
            {
                // Crear un archivo XML vacío
                Session.SessionId = "";
                Session.SessionActiva = false;


                SaveSession();

                Debug.WriteLine("¡La sesión se ha cerrado correctamente!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al cerrar la sesión: " + ex.Message);
            }
        }


    }
}
