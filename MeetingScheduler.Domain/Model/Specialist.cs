using MeetingScheduler.Domain.IDs;
using MeetingScheduler.Domain.Model.Base;
using MeetingScheduler.Shared.Domain.Results;

namespace MeetingScheduler.Domain.Model;

public class Specialist : Entity<SpecialistId>
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }

    private Specialist(SpecialistId id, DateTime createdAt, string createdBy, string name, string surname, string email,
        string phoneNumber) : base(id, createdAt, createdBy)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public static IDomainResult<Specialist> Create(SpecialistId id, DateTime createdAt, string createdBy, string name, string surname,
        string email, string phoneNumber)
    {
        var specialist = new Specialist(id, createdAt, createdBy, name, surname, email, phoneNumber);
        return DomainResult<Specialist>.Success(specialist);
    }
}