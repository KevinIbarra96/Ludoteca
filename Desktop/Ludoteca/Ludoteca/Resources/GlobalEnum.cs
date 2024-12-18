namespace Ludoteca.Resources
{
    public class GlobalEnum
    {
        public enum Action
        {
            CREAR_NUEVO,
            ACTUALIZAR,
            REMOVER
        }

        public enum ActionFrom
        {
            AsyncFunction,
            UserInterface
        }

        public enum ErrorCode
        {
            SUCCESS = 0,
            NOT_FOUND = 402
        }
        public enum ActionSession
        {
            LOGIN,
            GET_VALUE_FROM_XML
        }

    }
}
