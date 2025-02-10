namespace AssetManager.Infrastructure.Configuration
{
    public static class EnvironmentVariables
    {
        public const string ElasticsearchUrl = "ELASTICSEARCH_URL";
        public const string SQLLiteUrl = "SQLLITE_DB_URL";
    }

    public static class EnvUtil
    {
        public static string GetElasticUrl()
        {
            string? elasticUrl = Environment.GetEnvironmentVariable(EnvironmentVariables.ElasticsearchUrl);
            if (elasticUrl != null)
            {
                return elasticUrl;
            }

            throw new Exception($"{EnvironmentVariables.ElasticsearchUrl} env variable missing!");
        }

        public static string GetSQLLiteDbUrl()
        {
            string? dbUrl = Environment.GetEnvironmentVariable(EnvironmentVariables.SQLLiteUrl);

            if (dbUrl != null)
            {
                return dbUrl;
            }

            throw new Exception($"{EnvironmentVariables.SQLLiteUrl} env variable missing!");
        }
    }
}
