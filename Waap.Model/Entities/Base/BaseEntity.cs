
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Waap.Model.Entities.Base
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset ModifiedDateTime { get; set; }
    }
}
