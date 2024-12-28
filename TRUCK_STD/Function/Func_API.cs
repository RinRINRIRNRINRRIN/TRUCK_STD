using TRUCK_STD.Functions;

namespace TRUCK_STD.Function
{
    class Func_API
    {
        public static string State
        {
            get { return registy.function.APIState; }
        }

        public static string Endpoint
        {
            get { return registy.function.APIEndpoint; }
        }

        public static string Key
        {
            get { return registy.function.APIKey; }
        }


    }
}
