using BryceResortPatrol.Common.Extensions;
using BryceResortPatrol.Common.Models;
using BryceResortPatrol.Common.Models.Enums;
using BryceResortPatrol.Common.Repositories.Interfaces;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceResortPatrol.Common.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IDatabaseClient databaseClient;

        public UserRepository(DocumentClient documentClient)
        {
            this.databaseClient = new DatabaseClient(documentClient, DocumentCollection.User.ToDocumentCollectionUri());
        }

        public User GetUser(string username)
        {
            var sql = $"select * from c where c.username = '{username}'";
            return this.databaseClient.SingleOrDefault<Models.User>(sql);
        }
    }
}
