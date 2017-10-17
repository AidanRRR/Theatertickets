using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace backend.Domain
{
    public class VoorstellingEntity: TableEntity
    {
        public VoorstellingEntity(string gezelschapNaam, string voorstellingNaam)
        {
            this.PartitionKey = gezelschapNaam;
            this.RowKey = voorstellingNaam;
        }

        private string GezelschapNaam { get; set; }
        private string VoorstellingNaam { get; set; }
        private DateTime VoorstellingDatum { get; set; }
        private IEnumerable<string> BeschikbareStoelen { get; set; }
        private IEnumerable<string> GereserveerdeStoelen { get; set; }
    }
}