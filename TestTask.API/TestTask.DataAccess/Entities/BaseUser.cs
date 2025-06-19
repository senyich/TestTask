using System.ComponentModel.DataAnnotations;

namespace TestTask.DataAccess.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}