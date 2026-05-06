// Program: ProxyPattern
// Difficulty: High
// Description: Proxy pattern for lazy loading, access control, and logging.
using System;

interface IDatabase { string Query(string sql); }

class RealDatabase : IDatabase
{
    public RealDatabase() => Console.WriteLine("Connecting to real database...");
    public string Query(string sql) => $"Results for: {sql}";
}

class DatabaseProxy : IDatabase
{
    private RealDatabase _db;
    private string _userRole;

    public DatabaseProxy(string role) => _userRole = role;

    public string Query(string sql)
    {
        Console.WriteLine($"[Proxy] User role: {_userRole}");
        if (_userRole != "admin" && sql.StartsWith("DROP"))
            return "Access denied: DROP not allowed";
        _db ??= new RealDatabase(); // lazy initialization
        Console.WriteLine($"[Proxy] Logging query: {sql}");
        return _db.Query(sql);
    }
}

class ProxyPattern
{
    static void Main(string[] args)
    {
        IDatabase db = new DatabaseProxy("user");
        Console.WriteLine(db.Query("SELECT * FROM users"));
        Console.WriteLine(db.Query("DROP TABLE users"));

        IDatabase adminDb = new DatabaseProxy("admin");
        Console.WriteLine(adminDb.Query("DROP TABLE temp"));
    }
}
