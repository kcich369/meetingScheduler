using MeetingScheduler.Domain.IDs;
using MeetingScheduler.Domain.Model.Base;
using MeetingScheduler.Shared.Domain.Results;

namespace MeetingScheduler.Domain.Model;

public class Client : Entity<ClientId>
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }

    private Client(ClientId id, DateTime createdAt, string createdBy, string name, string surname, string email,
        string phoneNumber) : base(id, createdAt, createdBy)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public static IDomainResult<Client> Create(ClientId id, DateTime createdAt, string createdBy, string name, string surname,
        string email, string phoneNumber) => DomainResult<Client>.Success(new Client(id, createdAt, createdBy, name, surname, email, phoneNumber));
}