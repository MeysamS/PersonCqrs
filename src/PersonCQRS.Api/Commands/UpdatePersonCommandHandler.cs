using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using PersonCQRS.Domain.AggregatesModel;

namespace PersonCQRS.Api.Commands
{
    public class UpdatePersonCommandHandler:IRequestHandler<UpdatePersonCommand,Result>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        
        public async Task<Result> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = _mapper.Map<UpdatePersonCommand, Person>(request);
            _personRepository.Update(person);
            await _personRepository.UnitOfWork.SaveChangeAsync(cancellationToken);
            return Result.Success();
        }
    }
}