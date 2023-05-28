namespace CafeMaya.Models;

public class Courier
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }

    public Courier(int id, string firstName, string lastName, string? patronymic = null)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
    }

    public Courier(string firstName, string lastName, string? patronymic = null)
    : this(0, firstName, lastName, patronymic) { }
}