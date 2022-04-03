using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Contract
{
    public class TodoItemContract
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
