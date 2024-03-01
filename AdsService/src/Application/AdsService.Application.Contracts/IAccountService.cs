namespace AdsService.Application.Contracts;

public interface IAccountService
{
    public User LoginUser(UserMail  email, UserPassword password);
    public Moderator LoginModerator(UserMail  email, UserPassword password);
    public User RegisterUser(UserMail email, UserPassword password);
    public Moderator RegisterModerator(UserMail email, UserPassword password);
}