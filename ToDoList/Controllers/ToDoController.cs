﻿using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Dtos;
using AutoMapper;
using ToDoList.Enums;
using ToDoList.Repositories;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private static int id = 0;
    private ITodoRepository _todoRepository;
    private IMapper _mapper;

    public ToDoController(IMapper mapper, ITodoRepository todoRepository)
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
    }

    /// <summary>
    /// Adds a new to do.
    /// </summary>
    /// <param name="toDoDto">Object with necessary fields for creating a todo</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">If insertion is successful</response>
    [HttpPost]
    [ProducesResponseType(typeof(ToDo), 201)]
    [ProducesResponseType(typeof(void), 400)]
    public IActionResult AddToDo([FromBody] CreateToDoDto toDoDto)
    {
        ToDo newToDo = _mapper.Map<ToDo>(toDoDto);

        newToDo.Id = id++;
        _todoRepository.AddToDo(newToDo);
        return CreatedAtAction(nameof(GetToDoById), new { id = newToDo.Id },
            newToDo);
    }

    /// <summary>
    /// A to do list with pagination and filtering options.
    /// </summary>
    /// <param name="skip">Number of records to skip.</param>
    /// <param name="take">Maximum number of records to return.</param>
    /// <param name="priority">Priority of the to do.</param>
    /// <param name="isCompleted">Indicates if the to do is completed.</param>
    /// <returns>To do list.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<IListToDosDto>), 200)]
    public IEnumerable<IListToDosDto> GetToDos([FromQuery] TodoPriority priority, [FromQuery] bool isCompleted,
        [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var filteredTodos = _todoRepository.GetAllToDos(skip, take, priority, isCompleted).AsQueryable();
        var userAgent = Request.Headers["User-Agent"].ToString().ToLower();
        bool isMobileRequest = userAgent.Contains("mobile");

        if (isMobileRequest)
            return _mapper.Map<IEnumerable<ListMobileToDosDto>>(filteredTodos);
        else
            return _mapper.Map<IEnumerable<ListWebToDosDto>>(filteredTodos);
    }

    /// <summary>
    /// Gets a to do by its ID.
    /// </summary>
    /// <param name="id">ID of the to do.</param>
    /// <returns>The to do corresponding to the specified ID.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IListToDosDto), 200)]
    [ProducesResponseType(typeof(void), 404)]
    public IActionResult GetToDoById(int id)
    {
        var toDo = _todoRepository.GetToDoById(id);
        if (toDo == null) return NotFound();
        return Ok(_mapper.Map<ListWebToDosDto>(toDo));
    }

    /// <summary>
    /// Updates the completion status of a to do.
    /// </summary>
    /// <param name="id">ID of the to do.</param>
    /// <returns>IActionResult</returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(ToDo), 200)]
    [ProducesResponseType(typeof(void), 404)]
    public IActionResult UpdateIsCompleted(int id)
    {
        var toDo = _todoRepository.GetToDoById(id);
        if (toDo == null) return NotFound();

        _todoRepository.UpdateIsCompleted(toDo.Id);
        return Ok(toDo);
    }

    /// <summary>
    /// Updates a to do.
    /// </summary>
    /// <param name="id">ID of the to do.</param>
    /// <param name="toDoDto">Object with updated to do data.</param>
    /// <returns>IActionResult</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(void), 204)]
    [ProducesResponseType(typeof(void), 404)]
    public IActionResult EditToDo(int id, [FromBody] UpdateToDoDto toDoDto)
    {
        var toDo = _todoRepository.GetToDoById(id);
        if (toDo == null) return NotFound();
        _mapper.Map(toDoDto, toDo);
        return NoContent();
    }

    /// <summary>
    /// Deletes a to do.
    /// </summary>
    /// <param name="id">ID of the 'to do' to delete.</param>
    /// <returns>IActionResult</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(void), 204)]
    [ProducesResponseType(typeof(void), 404)]
    public IActionResult DeleteToDo(int id)
    {
        var toDo = _todoRepository.GetToDoById(id);
        if (toDo == null) return NotFound();
        _todoRepository.DeleteToDo(toDo);
        return NoContent();
    }

    /// <summary>
    /// Handles unknown requests and returns a 404 status.
    /// </summary>
    /// <returns>Status 404 (NotFound).</returns>
    [Route("{*url}", Order = int.MaxValue)]
    [HttpGet]
    [HttpPut]
    [HttpPost]
    [HttpDelete]
    [HttpPatch]
    //Changing the visibility to avoid cluttering the documentation.
    [ApiExplorerSettings(IgnoreApi = true)]
    [ProducesResponseType(typeof(void), 404)]
    public IActionResult HandleUnknownRequests()
    {
        return NotFound();
    }
}