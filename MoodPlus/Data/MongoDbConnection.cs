namespace MoodPlus.Data
{
    public class MongoDbConnection 
    {
        public class MongoDbSettings()
        {
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
    }
}
