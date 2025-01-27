﻿using Application.Features.Courses.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Queries.GetAll
{
    public class GetAllCoursesQuery : IRequest<IEnumerable<CourseDTO>>
  {
    public class Handler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseDTO>>
    {

      private readonly IApplicationDbContext _context;
      public Handler(IApplicationDbContext context)
      {
        _context = context;
      }
      public async Task<IEnumerable<CourseDTO>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
      {
        var countries = await _context.Countries.Select(x =>
              new CourseDTO
              {
                Id = x.Id,
                Name = x.Name,
                SortIndex = x.SortIndex,
                Focus = x.Focus,
                Active = x.Active

              }
          ).ToListAsync();

        return countries;
      }
    }
  }

}
