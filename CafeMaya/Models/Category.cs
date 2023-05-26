namespace CafeMaya.Models;

public class Category
{
    public int Id {get;set;}
    public string Name {get;set;} = "Category Sample";
    public List<Item> Items {get;set;} = new List<Item>();
    public string? PictureUrl {get;set;} = "https://placehold.co/1000";
}