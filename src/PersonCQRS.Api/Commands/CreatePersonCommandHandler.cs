using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using PersonCQRS.Domain.AggregatesModel;

namespace PersonCQRS.Api.Commands
{
    public class CreatePersonCommandHandler:IRequestHandler<CreatePersonCommand,Result>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonRepository personRepository,IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = _mapper.Map<CreatePersonCommand, Person>(request);
            _personRepository.Add(person);
            await _personRepository.UnitOfWork.SaveChangeAsync(cancellationToken);
            return Result.Success();
        }
    }
}