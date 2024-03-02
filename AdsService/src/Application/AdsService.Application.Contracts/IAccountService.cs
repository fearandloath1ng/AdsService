namespace AdsService.Application.Contracts;

using AdsService.Application.Models.Dto;
using AdsService.Application.Models.ValueObjects;

public interface IAccountService
{
    public UserDto LoginUser(UserMail email, PasswordHash password);

    public ModeratorDto LoginModerator(UserMail email, PasswordHash password);

    public UserDto RegisterUser(UserMail email, PasswordHash password);

    public ModeratorDto RegisterModerator(UserMail email, PasswordHash password);
}