using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Specialized;
using Prueba2.Entities;

namespace Prueba2.Controllers;
[ApiController]
[Route("users")]
public class PruebaController : ControllerBase
{

    static HttpClient client = new HttpClient();

    //URL: /users
    //Realiza la peticion de todos los usuarios, crea una lista de Users y la regresa como respuesta
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers(){
        string path = "http://jsonplaceholder.typicode.com/users";
        string text="";
        List<User> users = new List<User>();
        HttpResponseMessage response = await client.GetAsync(path);
        if(response.IsSuccessStatusCode)
        {
            text = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<User>>(text);
            if(result == null)
                return NotFound();
            foreach(User s in result)
                users.Add(s);
            return users.ToArray();
        }
        return NotFound();
    }

    //URL: /users/id
    //Realiza la peticion del usuario correspondiente con el id recibido, regresa el usuario que corresponda con ese id si no se encuentra regresa error
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        string path = "http://jsonplaceholder.typicode.com/users/"+id.ToString();
        Console.WriteLine(path);
        string text="";
        HttpResponseMessage response = await client.GetAsync(path);
        if(response.IsSuccessStatusCode)
        {
            text = await response.Content.ReadAsStringAsync();
            Console.WriteLine(text);
            var result = JsonConvert.DeserializeObject<User>(text);
            if(result != null)
                return (User) result;
        }
        return NotFound();
    }
    
    //URL: /users/id/posts
    //Realiza la peticion de los posts correspondientes con ese usuario, crea una lista de Publication y para cada post busca los comentarios correspondientes a este post crea una lista de Comment y los agrega a cada una de las publicaciones. Regresa error si no se encuentra ese usuario
    [HttpGet("{id}/posts")]
    public async Task<ActionResult<IEnumerable<Publication>>> GetPost(int id)
    {
        string path = "http://jsonplaceholder.typicode.com/users/"+id.ToString()+"/posts";
        Console.WriteLine(path);
        string text="";
        List<Publication> posts = new List<Publication>();
        HttpResponseMessage response = await client.GetAsync(path);
        if(response.IsSuccessStatusCode)
        {
            text = await response.Content.ReadAsStringAsync();
            Console.WriteLine(text);
            var result = JsonConvert.DeserializeObject<List<Publication>>(text);
            if(result != null)
            {
                foreach(Publication p in result)
                {
                    int idPost = p.id;
                    string pathComments = "http://jsonplaceholder.typicode.com/posts/"+idPost.ToString()+"/comments";
                    HttpResponseMessage responseComments = await client.GetAsync(pathComments);
                    List<Comment> comments = new List<Comment>();
                    if(responseComments.IsSuccessStatusCode)
                    {
                        text = await responseComments.Content.ReadAsStringAsync();
                        Console.WriteLine(text);
                        var resultComments = JsonConvert.DeserializeObject<List<Comment>>(text);
                        if(resultComments != null)
                        {
                            foreach (Comment c in resultComments)
                            {
                                comments.Add((Comment)c);
                            }
                        }
                    }
                    p.comments = comments;
                    posts.Add(p);
                }
                return posts.ToArray();
            }
        }
        return NotFound();
    }

    //URL: /users/id/todos
    //Realiza la peticion de las tareas correspondientes a ese usuario, crea una lista de Todo con las tareas regresadas por la peticion y regresa esta lista. Regresa error si no se encuentra el usuario
    [HttpGet("{id}/todos")]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos(int id)
    {
        string path = "http://jsonplaceholder.typicode.com/users/"+id.ToString()+"/todos";
        Console.WriteLine(path);
        string text="";
        List<Todo> todos = new List<Todo>();
        HttpResponseMessage response = await client.GetAsync(path);
        if(response.IsSuccessStatusCode)
        {
            text = await response.Content.ReadAsStringAsync();
            Console.WriteLine(text);
            var result = JsonConvert.DeserializeObject<List<Todo>>(text);
            if(result != null)
            {
                foreach (Todo t in result)
                {
                    todos.Add(t);
                }
                return todos.ToArray();
            }
        }
        return NotFound();
    }

    //URL: users?userId=&title=&completed
    //Recibe los parametros correspondientes a la tarea, realiza la peticion post y regresa el id de la nueva tarea. Regresa error si no se pudo realizar la peticion post
    [HttpPost]
    public async Task<ActionResult<string>> PostTodo(int userId,string title,bool completed)
    {
        string path = "http://jsonplaceholder.typicode.com/todos";
        Console.WriteLine(path);
        var todo = new Dictionary<string,string>{
            {"userId", userId.ToString()},
            {"title", title},
            {"completed", completed.ToString()}
        };
        string text="";
        var content = new FormUrlEncodedContent(todo);
        HttpResponseMessage response = await client.PostAsync(path,content);
        if(response.IsSuccessStatusCode)
        {
            text = await response.Content.ReadAsStringAsync();
            if(text != null)
            {
                Todo newTodo = JsonConvert.DeserializeObject<Todo>(text);
                if(newTodo != null)
                {
                    var id = new Dictionary<string,int>{
                        {"id",newTodo.id}
                    };
                    return JsonConvert.SerializeObject(id);
                }
            }
            return BadRequest();
        }
        return BadRequest();
    }
}
