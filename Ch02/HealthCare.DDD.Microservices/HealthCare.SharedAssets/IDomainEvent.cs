using MediatR;
using System;

namespace DomainEventsConsole.Interfaces
{
    public interface IDomainEvent : INotification 
    {
        DateTime ActionDate { get; }
    }
}
