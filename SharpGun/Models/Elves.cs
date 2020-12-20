using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SharpGun.Models
{
    public class Elves
    {
        [BindNever] public int Id { get; set; }

        [Required(ErrorMessage = "Name不能为空")]
        [StringLength(50, ErrorMessage = "名称不能超过50个字符")]
        [RegularExpression(@"\w*", ErrorMessage = "名称必须含有字符")]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Detail
        {
            get => Name + Age;
            set { }
        }
    }
}
