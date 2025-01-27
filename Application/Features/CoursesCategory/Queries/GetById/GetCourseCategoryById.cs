﻿using Application.Features.CoursesCategory.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CoursesCategory.Queries.GetById
{
    public class GetCourseCategoryById : IRequest<CourseCategoryDTO>
  {
    public int Id { get; set; }
  }
  public class Handler : IRequestHandler<GetCourseCategoryById, CourseCategoryDTO>
  {
    private readonly IApplicationDbContext _context;
    public Handler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<CourseCategoryDTO> Handle(GetCourseCategoryById request, CancellationToken cancellationToken)
    {
      var country = await _context.Countries.Where(x => x.Id == request.Id).Select(x => new CourseCategoryDTO
      {
        Id = x.Id,
        Name = x.Name,
        SortIndex = x.SortIndex,
        Focus = x.Focus,
        Active = x.Active
      }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

      return country;
    }
  }
}
