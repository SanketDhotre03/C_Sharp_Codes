// Program: CustomAttribute
// Difficulty: High
// Description: Defines and uses custom attributes for metadata annotation.
using System;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
class TableAttribute : Attribute { public string Name; public TableAttribute(string name) => Name = name; }

[AttributeUsage(AttributeTargets.Property)]
class ColumnAttribute : Attribute {
    public string Name; public bool PrimaryKey; public bool Nullable = true;
    public ColumnAttribute(string name) => Name = name;
}

[Table("Users")]
class UserEntity
{
    [Column("user_id", PrimaryKey = true, Nullable = false)]
    public int Id { get; set; }

    [Column("user_name", Nullable = false)]
    public string Username { get; set; }

    [Column("email_address")]
    public string Email { get; set; }

    public string NotMapped { get; set; } // no ColumnAttribute
}

class CustomAttribute
{
    static void GenerateInsertSql<T>()
    {
        Type t = typeof(T);
        var table = t.GetCustomAttribute<TableAttribute>();
        Console.WriteLine($"Table: {table?.Name ?? t.Name}");
        var cols = new List<string>();
        foreach (var prop in t.GetProperties())
        {
            var col = prop.GetCustomAttribute<ColumnAttribute>();
            if (col != null) cols.Add($"  {col.Name} (PK:{col.PrimaryKey}, Nullable:{col.Nullable})");
        }
        Console.WriteLine("Columns:
" + string.Join("
", cols));
    }

    static void Main(string[] args)
    {
        GenerateInsertSql<UserEntity>();
    }
}
