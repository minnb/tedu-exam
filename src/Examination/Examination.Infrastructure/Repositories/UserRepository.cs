using Examination.Domain.AggregateModels.UserAggregate;
using Examination.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(
            IMongoClient mongoClient, 
            IClientSessionHandle clientSessionHandle, 
            IOptions<ExamSettings> settings, 
            IMediator mediator, string collection)
        : base(mongoClient, clientSessionHandle, settings, mediator, collection)
        {
        }

        public async Task<User> GetUserByIdAsync(string externalId)
        {
            var filter = Builders<User>.Filter.Eq(s => s.ExternalId, externalId);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
