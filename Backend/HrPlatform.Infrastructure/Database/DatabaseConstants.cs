namespace HrPlatform.Infrastructure.Database;

class DatabaseConstants
{
    public static class Schema
    {
        public static readonly string SchemaName = nameof(HrPlatform);
    }

    public static class SQLFunction
    {
        public static readonly string NowDateTime = "NOW()";
    }
}
