using System;
using System.Linq;
using System.Threading.Tasks;
using Doco.Domain;
using Doco.Domain.Entities;
using Doco.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Doco.Infrastructure.Persistence
{
    public class DocoDbContextInitializer
    {
        private readonly ILogger<DocoDbContextInitializer> _logger;
        private readonly DocoDbContext _context;

        public DocoDbContextInitializer(ILogger<DocoDbContextInitializer> logger, DocoDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task MigrateDb()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred on the DB migrations applying");
                throw;
            }
        }

        public async Task Seed()
        {
            try
            {
                if (!_context.Users.Any())
                {
                    await _context.Users.AddAsync(new User()
                    {
                        Created = DateTime.Now,
                        LastModified = DateTime.Now,
                        Name = "Admin",
                        Email = $"admin{DomainConstants.CompanyEmailPostfix}",
                        Type = UserType.Internal
                    });

                    await _context.Users.AddAsync(new User()
                    {
                        Created = DateTime.Now,
                        LastModified = DateTime.Now,
                        Name = "ExternalUser",
                        Email = $"external.user@ex.com",
                        Type = UserType.External
                    });

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred the DB seeding");
                throw;
            }
        }
    }
}