using Data;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RN_Tickets
    {
        public static async Task<EN_Response<EN_Tickets>> RN_getAllTicketsActivas()
        {
            return await DB_Tickets.getAllTicketsActivas();
        }
        public static async Task<List<EN_Tickets>> RN_GetAllTickets()
        {
            return await DB_Tickets.getAllTickets();
        }
        public static async Task<List<EN_Tickets>> RN_GetTicketByID(int _id)
        {
            return await DB_Tickets.getTicketById(_id);
        }
        public static async Task<List<EN_Tickets>> RN_DeleteTicket(int _id)
        {
            return await DB_Tickets.deleteTicket(_id);
        }
        public static async Task  RN_UpdateTicket(EN_Tickets eN_Tickets)
        {
            await DB_Tickets.updateTicket(eN_Tickets);
        }
        public static async Task<EN_Response<EN_Tickets>> RN_AddNewTicket(EN_Tickets eN_Tickets)
        {
            return await DB_Tickets.addNewTicket(eN_Tickets);
        }
        public static async Task<EN_Response<EN_Tickets>> RN_GetNewFolio()
        {
            return await DB_Tickets.getNewFolio();
        }
    }
}
