namespace AdsService.Application.Models.ValueObjects;

public readonly struct UserMail
{
    public string Mail { get; }

    public UserMail(string mail)
    {
        Mail = mail;
        if (mail.Length > 64)
            throw new ArgumentException("Mail length can't exceed 64 symbols.", nameof(mail));
    }

    public UserMail()
    {
        Mail = "Empty mail";
    }
}