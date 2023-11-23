﻿using petrovkt42_20.Database;
using petrovkt42_20.Filters.PrepodDegreeFilters;
using petrovkt42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace petrovkt42_20.Interfaces.DegreeInterfaces
{
    public interface IDegreesService
    {
        public Task<Prepod[]> GetPrepodsByDegreeAsync(PrepodDegreeFilter filter, CancellationToken cancellationToken);
    }

    public class DegreeService : IDegreesService
    {
        private readonly PrepodDbContext _dbContext;
        public DegreeService(PrepodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Prepod[]> GetPrepodsByDegreeAsync(PrepodDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var degrees = _dbContext.Set<Prepod>().Where(w => w.Degree.DegreeName == filter.DegreeName).ToArrayAsync(cancellationToken);

            return degrees;
        }
    }
}
