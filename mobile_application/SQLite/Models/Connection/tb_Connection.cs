
using SQLite;

namespace mobile_application.SQLite.Models.Connection
{
    public class tb_Connection
    {
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string name { get; set; }
		public string server { get; set; }
		public string login { get; set; }
		public string password { get; set; }
		public string database { get; set; }
		public int is_default { get; set; } //select 1 for defalut and 0 means not selected .
	}
}