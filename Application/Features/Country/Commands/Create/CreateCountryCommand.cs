﻿using Application.Features.Country.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Country.Commands.Create
{
    public class CreateCountryCommand : CountryDTO, IRequest<long>
    {
        public CreateCountryCommand()
        { }


        public CreateCountryCommand(CountryDTO dto)
        {
            NameA = dto.NameA;
            NameE = dto.NameE;
            Id = dto.Id;

        }
        public class Handler : IRequestHandler<CreateCountryCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Country entity = new Domain.Entities.Country
                {
                    Id = request.Id,

                    NameA = request.NameA,
                    NameE = request.NameE,

                };


                await _context.Countries.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }
}

