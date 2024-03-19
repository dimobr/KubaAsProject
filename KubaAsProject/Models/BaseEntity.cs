using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace KubaAsProject.Models
{
    [ExcludeFromCodeCoverage]
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }    
    }
}
