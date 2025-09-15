using FluentValidation.Results;
using MediatR;


namespace Core.Messages
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
