namespace AdsService.Application.Contracts;

public interface IAccountService
{
    public UserDto LoginUser(UserMail  email, UserPassword password);
    public ModeratorDto LoginModerator(UserMail  email, UserPassword password);
    public UserDto RegisterUser(UserMail email, UserPassword password);
    public ModeratorDto RegisterModerator(UserMail email, UserPassword password);
}