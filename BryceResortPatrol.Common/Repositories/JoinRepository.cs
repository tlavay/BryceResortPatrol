using BryceResortPatrol.Common.Extensions;
using BryceResortPatrol.Common.Models;
using BryceResortPatrol.Common.Models.Enums;
using BryceResortPatrol.Common.Repositories.Interfaces;
using Microsoft.Azure.Documents.Client;
using System;
using System.Threading.Tasks;

namespace BryceResortPatrol.Common.Repositories
{
    public sealed class JoinRepository : IJoinRepository
    {
        private readonly DocumentClient documentClient;
        private readonly Uri collectionLink;

        public JoinRepository(DocumentClient documentClient)
        {
            this.documentClient = documentClient;
            this.collectionLink = DocumentCollection.Candidate.ToDocumentCollectionUri();
        }

        public async Task Save(Candidate candidate)
        {
            await this.documentClient.CreateDocumentAsync(this.collectionLink, candidate);
        }
    }
}
