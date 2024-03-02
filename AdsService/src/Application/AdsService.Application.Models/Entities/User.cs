namespace AdsService.Application.Models.Entities;

using AdsService.Application.Models.ValueObjects;

public class User(UserMail mail, Name name)
{
    public Guid Id { get; } = Guid.NewGuid();

    public UserMail Mail { get; } = mail;

    public Name Name { get; } = name;

    public Balance Balance { get; } = new(0, 0);
}