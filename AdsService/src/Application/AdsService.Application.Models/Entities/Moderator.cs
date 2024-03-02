namespace AdsService.Application.Models.Entities;

using AdsService.Application.Models.ValueObjects;

public class Moderator(UserMail mail, PasswordHash password)
{
    public Guid Id { get; } = Guid.NewGuid();

    public UserMail Mail { get; } = mail;

    public PasswordHash Password { get; } = password;
}