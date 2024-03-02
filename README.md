## Команда №28 - Сервис для создания рекламы в инстаграме и телеграме"

## Состав команды:
- Кахикало Кирилл Романович
- Бинов Даниил Евгеньевич
- Заблудовский Даниил Павлович
- Шишкина Анна Станиславовна
- Яковлева Таисия Данииловна
- Манукян Даниил Алексеевич

## Доменные сущности:
### User

```
public readonly struct UserMail 
{
    public string Mail { get; }
    
    public UserMail(string mail)
    {
        Mail = mail;
        if (mail.Length > 30) 
            throw new ArgumentException("Mail length can't exceed 30 symbols.", nameof(mail));
    }
    
    public UserMail() 
    {
        Mail = "Empty mail";
    }
}

public readonly struct UserName 
{
    public string Name { get; }
    
    public UserName(string name)
    {
        Name = name;
        if (name.Length > 30) 
            throw new ArgumentException("Name length can't exceed 30 symbols.", nameof(name));
    }
    
    public UserName() 
    {
        Name = "Empty name";
    }
}

public readonly struct UserBalance 
{
    public decimal Balance { get; }
    
    public UserBalance(decimal balance)
    {
        Balance = balance;
        if (balance < 0) 
            throw new ArgumentException("Balance can't be less than 0.");
    }
    
    public UserBalance() 
    {
        Balance = 0;
    }
}


public class User
{
    public Guid Id { get; }
    public UserMail Mail { get; }
    public UserName Name { get; }
    public UserBalance Balance { get; }

    public User(UserMail mail, UserName name) {
        Id = Guid.NewGuid();
        Mail = mail;
        Name = name;
        Balance = new UserBalance();
    }
}
```

### Post

```
public readonly struct PostContent
{
	public string Text { get; }
	
	public PostContent(string text)
	{
		Text = text;
		 if (text.Length > 1024) 
            throw new ArgumentException("Content length can't exceed 1024 symbols.", nameof(name));
		
	}
	
	public PostContent() 
	{
		Text = "Empty content"
	}
}

public enum PostStatus 
{
	Moderation,
	Approved,
	Rejected
}

public class Post
{
    public Guid Id { get; }
    public Guid UserId { get; }
    public PostContent Content { get; }
    public PostStatus ModerationStatus { get; }
    
    public Post(User user, PostContent content)
    {
    	Id = Guid.NewGuid();
    	UserId = user.id;
    	Content = content;
    	ModerationStatus = PostStatus.Moderation;
    }
    
    public void Approve() 
    {
    	TrowIfNotOnModeration();
    	ModerationStatus = PostStatus.Approved;
    }
    
    public void Reject() 
    {
    	TrowIfNotOnModeration();
    	ModerationStatus = PostStatus.Rejected;
    }
    
    private void ThrowIfNotOnModeration()
    {
    	if (ModerationStatus != PostStatus.Moderation)
    		trow one InvalidOperationException("Post is not on moderation.")
    }
}
```

### Moderator

```
public readonly struct PasswordHash
{
    public string Password {get;}
    
    public PasswordHash(string mail)
    {
        Password = password;
        if (password.Length > 50)
        throw new ArgumentException("Password length can't exceed 50 symbols.", nameof(password));
    }
    
    public PasswordHash()
    {
        Mail = "Empty password";
    }
}

public class Moderator
{
    public Guid Id { get; }
    public UserMail Mail { get; }
    public PasswordHash Password { get; }
    
    public Moderator(UserMail Mail, PasswordHash Password){
        Id = Guid.NewGuid();
        Mail = mail;
        Password = password;
    }
}
```

### AdCampaign
```
public readonly struct AdCampaignCost 
{
    public decimal Cost { get; }
    
    public AdCampaignCost(decimal cost)
    {
        Cost = cost;
        if (cost < 0) 
            throw new ArgumentException("Cost can't be less than 0.");
    }
    
    public AdCampaignCost() 
    {
        Cost = 0;
    }
}

public class AdCampaign
{
    public Guid Id { get; }
    public Guid PostId { get; }
    public Guid UserId { get; }
    public AdCampaignCost Cost { get; }
    public TimeSpan Duration { get; }
    public IsActive IsActive { get; }
    
    public AdCampaign(AdCampaignCost cost, TimeSpan duration, IsActive isActive) {
        Id = Guid.NewGuid();
        PostId = Guid.NewGuid();
        UserId = Guid.NewGuid();
        Cost = cost;
        Duration = duration;
        IsActive = isActive;
    }
}
```

### Check

```
public readonly struct Reason 
{
    public decimal Reason { get; }
	  public decimal Result { get; }
    
    public Reason(decimal reason)
    {
        Result = result;
		    Reason = reason;
        if (result = 1 & reason != '') 
            throw new ArgumentException("Result error.");
    }
    
    public UserBalance() 
    {
        Result = 0;
    }
}


public class Check
{
    public Guid Id { get; }
    public Guid ModeratorId { get; }
    public Guid PostId { get; }
    public bool Result { get; }
	  public CheckReason Reason { get; }

    public Check(Guid ModeratorId, Guid PostId, bool Result, CheckReason Reason) {
        Id = Guid.NewGuid();
        Post = PostId;
        Result = result;
        Reason = new CheckReason();
    }
}
```

Регистрация клиента - `POST api/v1/users/registration`  
request - `{"userMail": "vasyavasin@gmail.com", "PasswordHash": "VerySafePassword1234!"}`  
response - `{"codeAnswer": "12345"}`

Проверка регистрации - `POST api/v1/users/code-check`  
request - `{"codeAnswer": "12345"}`  
response - `{"message": "You've successfully registered."}`

Аутентификация клиента - `POST api/v1/users/authentication`  
request - `{"userMail": "vasyavasin@gmail.com", "PasswordHash": "VerySafePassword1234!"}`  
response - `{"token": "xxxxx.yyyyy.zzzzz"}`

Создание поста - `POST api/v1/posts/create`  
request - `{"text": "blablabla", "picture": "imageUrl", "token": "xxxxx.yyyyy.zzzzz"}`  
response - `{"message": "The post is successfully created."}`

Проверка поста - `POST api/v1/posts/{postId}/list`  
request - `{"postId": "123abc"}`  
response - `{"message": "post approved"}`

Пополнение баланса - `POST api/v1/balance/replenish`  
request - `{"token": "xxxxx.yyyyy.zzzzz", "amount":100.00}`  
response - `{"message":"Balance successfully replenished."}`

Запуск рекламной кампании - `POST api/v1/ad-campaigns/start`  
request - `{"token": "xxxxx.yyyyy.zzzzz", "postId":"123cde", "price": 50.00, "duration": "24:00:00"}`  
response - `{"compaignId":"4w5l6jn4wlk5j6nw4lk56"}`

Остановка рекламной кампании - `POST api/v1/ad-campaigns/stop`  
request - `{"token": "xxxxx.yyyyy.zzzzz", "campaignId":"4w5l6jn4wlk5j6nw4lk56"}`  
response - `{"message":"Ad campaign successfully stopped."}`

Просмотр аналитики кампании - `GET api/v1/ad-campaigns/{campaignId}/analytics`
response - `{"campaignId": "4w5l6jn4wlk5j6nw4lk56", "views": 1000, "clicks": 500, "conversions": 50}`

