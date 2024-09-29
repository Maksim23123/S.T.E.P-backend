using System.ComponentModel.DataAnnotations;

namespace STEP_backend.Entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
    public abstract class BaseEntity<T> : IEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
