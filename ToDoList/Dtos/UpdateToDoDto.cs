using System.ComponentModel.DataAnnotations;
using ToDoList.Enums;

namespace ToDoList.Dtos;

public class UpdateToDoDto: IValidatableObject
{
    [Required]
    public string Description { get; set; }
    [Required]
    public TodoPriority? Priority { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Enum.IsDefined(typeof(TodoPriority), Priority))
        {
            yield return new ValidationResult("Invalid Priority value.", new[] { nameof(Priority) });
        }
    }
}   
