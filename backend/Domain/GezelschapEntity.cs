using Microsoft.WindowsAzure.Storage.Table;

namespace backend.Domain
{
    public class GezelschapEntity: TableEntity
    {
        public GezelschapEntity()
        {
        }

        public GezelschapEntity(string gezelschapNaam, string gezelschapEmail)
        {
            this.PartitionKey = gezelschapNaam;
            this.RowKey = gezelschapEmail;
        }

        public string GezelschapNaam { get; set; }
        public string GezelschapEmail { get; set; }
    }
}