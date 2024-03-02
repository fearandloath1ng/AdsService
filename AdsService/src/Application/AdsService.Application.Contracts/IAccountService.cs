namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface IAccountService
{
    public Jwt LoginUser(UserMail email, PasswordHash password);

    public Jwt LoginModerator(UserMail email, PasswordHash password);

    public Jwt RegisterUser(UserMail email, PasswordHash password);

    public Jwt RegisterModerator(UserMail email, PasswordHash password);
}