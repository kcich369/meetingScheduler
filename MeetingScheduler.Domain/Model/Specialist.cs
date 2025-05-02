using MeetingScheduler.Domain.IDs;
using MeetingScheduler.Domain.Model.Base;

namespace MeetingScheduler.Domain.Model;

public class Specialist : Entity
{
    public SpecialistId Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }


    private Specialist(Guid id, DateTime createdAtAt, string name, string surname, string email, string phoneNumber)
    {
        Id = SpecialistId.Create(id);
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        CreatedAt = createdAtAt;
    }

    public static Specialist Create(Guid id, DateTime createdAt, string name, string surname, string email,
        string phoneNumber) => new Specialist(id, createdAt, name, surname, email, phoneNumber);
}