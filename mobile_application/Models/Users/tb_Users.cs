
using SQLite;

namespace mobile_application.Models.Users
{
    public class tb_Users
    {
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public int is_admin { get; set; }
	}
}
