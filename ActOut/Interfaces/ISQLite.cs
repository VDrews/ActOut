using SQLite;

namespace ActOut.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
