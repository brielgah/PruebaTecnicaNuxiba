namespace Prueba2.Entities;
public class Publication
{
    public int userId { get; set; }
    public int id {get;set;}
    public string title{get;set;}
    public string body{get;set;}
    public List<Comment> comments{get;set;}
}