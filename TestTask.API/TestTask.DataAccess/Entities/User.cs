using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.DataAccess.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    [ForeignKey("Type")]
    public int TypeId { get; set; }
    public UserType Type { get; set; }
}