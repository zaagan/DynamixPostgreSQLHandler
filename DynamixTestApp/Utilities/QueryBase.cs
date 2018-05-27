namespace DynamixTestApp.Utilities
{
    public static class QueryBase
    {
        public static string GetAllFrom(eTables tableName)
        {
            return $"SELECT * FROM {tableName.ToString()};";
        }

        public static string GetTotal(eTables tableName)
        {
            return $"SELECT COUNT(*) FROM {tableName.ToString()};";
        }

        public static string GetFilmByID(int id)
        {
            return $"SELECT * FROM film WHERE film_id = {id};";
        }

        public const string query_GetLastActor = "SELECT * from actor order by last_update desc limit 1";
        public const string Function_GetActorsCount = "getactorscount";
        public const string Function_GetCountriesCount = "getcountriescount";
        public const string Function_InventoryHeldByCustomer = "inventory_held_by_customer";
        public const string Function_GetActors = "getactors";
        public const string Function_GetInventories_By_FilmID_And_StoreID = "getinventory_by_filmid_and_storeid";
        public const string Function_GetActorDetailByID = "getactor_detail_by_id";
        public const string Function_GetCustomerWithID_1 = "getcustomer_with_id_1";
        public const string Function_AddNewActor = "add_new_actor";

    }
}
