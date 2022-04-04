using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace ToDoApi.Models
{
    /// <summary>
    /// Todo model document 
    /// </summary>
    public class TodoItem : BaseModel
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Surename { get; set; }

        public bool IsComplete { get; set; }

        //public static bool operator ==(TodoItems item1, object item2)
        //{
        //    if (item2 == null) return false;
        //    return (item1 as TodoItems).Id == (item2 as TodoItems).Id && (item1 as TodoItems).Name == (item2 as TodoItems).Name;
        //}

        //public static bool operator !=(TodoItems item1, object item2)
        //{
        //    if (item2 == null) return true;
        //    return (item1 as TodoItems).Id != (item2 as TodoItems).Id || (item1 as TodoItems).Name != (item2 as TodoItems).Name;

        //}
        //public bool Equals(TodoItems obj)
        //{
        //    if (obj == null) return false;
        //    return (Id == obj.Id && obj.Name == Name);
        //}
    }
}
