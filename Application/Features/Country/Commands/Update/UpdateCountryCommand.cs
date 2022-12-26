﻿using Application.Features.Country.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Country.Commands.Update
{
    public class UpdateCountryCommand : CountryDTO, IRequest<int>
    {
        public UpdateCountryCommand()
        { }


        public UpdateCountryCommand(CountryDTO dto)
        {
            Id = dto.Id;

            NameA = dto.NameA;NameE = dto.NameE;



        }
        public class Handler : IRequestHandler<UpdateCountryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<int> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Country entity = new Domain.Entities.Country
                {
                    NameA = request.NameA,NameE = request.NameE,
                    Id = request.Id

                };


                _context.Countries.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }

}