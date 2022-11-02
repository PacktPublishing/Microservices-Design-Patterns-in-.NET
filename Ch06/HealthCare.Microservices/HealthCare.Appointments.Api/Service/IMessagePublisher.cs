namespace HealthCare.Appointments.Api.Service;

public interface IMessagePublisher
{
    Task PublishMessage<T>(T data, string topicName);
}