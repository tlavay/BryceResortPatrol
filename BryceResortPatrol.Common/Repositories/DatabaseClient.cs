using BryceResortPatrol.Common.Repositories.Interfaces;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Linq;

namespace BryceResortPatrol.Common.Repositories
{
    public sealed class DatabaseClient : IDatabaseClient
    {
        private readonly IDocumentClient documentClient;
        private readonly Uri collectionLink;
        private readonly FeedOptions feedOptions = new FeedOptions { EnableCrossPartitionQuery = true };

        public DatabaseClient(IDocumentClient documentClient, Uri collectionLink)
        {
            this.documentClient = documentClient;
            this.collectionLink = collectionLink;
        }

        public T SingleOrDefault<T>(string sql)
        {
            return this.documentClient.CreateDocumentQuery<T>(this.collectionLink, sql, feedOptions).AsEnumerable().SingleOrDefault();
        }
    }
}
