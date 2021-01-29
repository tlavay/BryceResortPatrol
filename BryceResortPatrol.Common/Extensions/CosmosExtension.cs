using BryceResortPatrol.Common.Models.Enums;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;

namespace BryceResortPatrol.Common.Extensions
{
    internal static class CosmosExtension
    {
        public static Uri ToDocumentCollectionUri(this DocumentCollection documentCollection) =>
            UriFactory.CreateDocumentCollectionUri("BryceMountainPatrol", documentCollectionMap[documentCollection]);

        private static IDictionary<DocumentCollection, string> documentCollectionMap = new Dictionary<DocumentCollection, string>()
        {
            [DocumentCollection.Candidate] = "candidate",
        };
    }
}
