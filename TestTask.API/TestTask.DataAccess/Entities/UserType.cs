namespace TestTask.DataAccess.Entities;

public class UserType : BaseEntity
{
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }

}