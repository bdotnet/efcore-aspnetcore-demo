using System;
using System.Collections.Generic;
using demo_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace demo_web_api.Controllers
{
    public class ToDoController : Controller
    {
        static List<TodoItem> toDoItems = new List<TodoItem>();
        TodoRepository repo = new TodoRepository();
        [HttpGet()]
        [Route("api/todo/items")]
        public List<TodoItem> GetAll()
        {
            // return toDoItems;
            return repo.GetAllItems();
        }

        [HttpPost()]
        [Route("api/todo/item")]
        public int Post([FromBody] TodoItem newTodo)
        {
            if (newTodo != null)
            {
                // toDoItems.Add(newTodo);
                return repo.AddItem(newTodo);
            }
            // return toDoItems.IndexOf(newTodo);
            return -1;
        }

        [HttpPut()]
        [Route("api/todo/{id}")]
        public int Put(int id, [FromBody] TodoItem itemToUpdate)
        {
            // if (toDoItems[id] != null)
            // {
            //     toDoItems[id] = itemToUpdate;
            // }
            // return id;
            return repo.UpdateItem(id, itemToUpdate);
        }

        [HttpDelete()]
        [Route("api/todo/{id}")]
        public bool Delete(int id)
        {
            bool isDeleteSuccessful = false;
            // if (toDoItems[id] != null)
            // {
            //     toDoItems.RemoveAt(id);
            //     isDeleteSuccessful = true;
            // }
            try
            {
                repo.DeleteItem(id);  
                isDeleteSuccessful = true;  
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return isDeleteSuccessful;
        }
    }
}