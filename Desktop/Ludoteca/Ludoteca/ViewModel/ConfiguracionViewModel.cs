using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.ViewModel
{
    internal class ConfiguracionViewModel
    {

        public ObservableCollection<EN_Gafete> Gafetes { get; set; }

        public ConfiguracionViewModel() {

            Gafetes = new ObservableCollection<EN_Gafete>();
            getAllActiveGafetes();

        }

        private async void getAllActiveGafetes()
        {

            var gafeteResponse = await RN_Gafete.getAllActiveGafete();

            foreach (EN_Gafete en in gafeteResponse.Rbody)
            {
                if (en.Asignado == 0)
                    en.AsignadoString = "No";
                else
                    en.AsignadoString = "Si";

                if (en.Status == 0)
                    en.StatusString = "Inactivo";
                else
                    en.StatusString = "Activo";

                addGafeteToCollection(en);
            }
        }

        private void addGafeteToCollection(EN_Gafete gafete)
        {
            Gafetes.Add(gafete);
        }

    }
}
