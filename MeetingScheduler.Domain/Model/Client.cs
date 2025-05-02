using MeetingScheduler.Domain.IDs;
using MeetingScheduler.Domain.Model.Base;

namespace MeetingScheduler.Domain.Model;

public class Client : Entity
{
    public ClientId Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }

    private Client(Guid id, DateTime createdAtAt, string name, string surname, string email, string phoneNumber)
    {
        Id = ClientId.Create(id);
        CreatedAt = createdAtAt;
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public static Client Create(Guid id, DateTime createdAt, string name, string surname, string email,
        string phoneNumber) => new Client(id, createdAt, name, surname, email, phoneNumber);
}