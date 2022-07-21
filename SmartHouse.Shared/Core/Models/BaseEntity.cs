using System.ComponentModel.DataAnnotations;

namespace SmartHouse.Shared.Core.Models
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
