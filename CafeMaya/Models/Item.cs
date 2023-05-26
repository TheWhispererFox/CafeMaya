namespace CafeMaya.Models;

public class Item
{
    public int Id {get;set;}
    public string Name {get;set;}
    public int Weight {get;set;}
    public double Price {get;set;}
    public string? PictureUrl {get;set;}

    public Item(string name, double price, int weight = 150, int id = 0, string? pictureUrl = "https://placehold.co/1000")
    {
        Id = id;
        Name = name;
        Weight = weight;
        Price = price;
        PictureUrl = pictureUrl;
    }
}