namespace RandomUser.Api.Data.Models.UsersExternals;

public class Street
{
    public int Number { get; set; }
    public string? Name { get; set; }

    public override string ToString()
        => $"{Name}, {Number}";
}