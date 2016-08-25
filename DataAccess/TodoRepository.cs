using demo_web_api.Models;
using System.Linq;
using System.Collections.Generic;

public class TodoRepository
{
    public TodoRepository()
    {

    }
    /// <summary>
    /// Adds a new item 
    /// </summary>
    /// <param name="newTodo"></param>
    /// <returns></returns>
    public int AddItem(TodoItem newTodo)
    {
        int itemIndex;
        using (TodoDbContext context = new TodoDbContext())
        {
            context.TodoItems.Add(newTodo);
            context.SaveChanges();
            itemIndex = context.TodoItems.ToList().IndexOf(newTodo);
        }
        return itemIndex;
    }

    /// <summary>
    /// Gets all the available items from the DB
    /// </summary>
    /// <returns></returns>
    public List<TodoItem> GetAllItems()
    {
        using (TodoDbContext context = new TodoDbContext())
        {
            return context.TodoItems.ToList();
        }
    }

    /// <summary>
    /// Updates an individual item
    /// </summary>
    /// <param name="index"></param>
    /// <param name="itemToUpdate"></param>
    /// <returns></returns>
    public int UpdateItem(int index, TodoItem itemToUpdate)
    {
        using (TodoDbContext context = new TodoDbContext())
        {
            var updatingItem = context.TodoItems.Where(item => item.TodoId == index).FirstOrDefault();
            updatingItem.isDone = itemToUpdate.isDone;
            updatingItem.Description = itemToUpdate.Description;
            updatingItem.DueDate = itemToUpdate.DueDate;
            context.SaveChanges();
            return index;
        }
    }

    /// <summary>
    /// Deletes an individual item
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool DeleteItem(int index)
    {
        using (var context = new TodoDbContext())
        {
            var itemToRemove = context.TodoItems.ToList()[index];
            context.TodoItems.Remove(itemToRemove);
            context.SaveChanges();
            return true;
        }
    }
}