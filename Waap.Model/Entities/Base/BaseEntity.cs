
using System.ComponentModel.DataAnnotations;

namespace Waap.Model.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTimeOffset CreateDateTime { get; set; }
    }
}
