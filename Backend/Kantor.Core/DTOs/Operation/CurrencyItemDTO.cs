namespace Kantor.Core.DTOs.Operation
{
    public class CurrencyItemDTO
    {
        public string Name { get; set; }
        public decimal Purchase { get; set; }
        public decimal Sale { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int SecurityCode { get; set; }

        public void SetHash()
        {
            string data = string.Join('@', [Name, Math.Round(Purchase * 1.0000M, 4), Math.Round(Sale * 1.0000M, 4), ValidFrom, ValidTo, "qjsye"]);

            SecurityCode = data.GetHashCode();
        }

        public bool IsCorrectSecurityCode()
        {
            string data = string.Join('@', [Name,  Math.Round(Purchase * 1.0000M, 4), Math.Round(Sale * 1.0000M, 4), ValidFrom, ValidTo, "qjsye"]);

            return SecurityCode == data.GetHashCode();
        }
    }
}
