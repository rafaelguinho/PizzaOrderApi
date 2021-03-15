using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrderApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("Crust")]
        [Required]
        public string Crust { get; set; }

        [JsonProperty("Flavor")]
        [Required]
        public string Flavor { get; set; }

        [JsonProperty("Size")]
        [Required]
        public string Size { get; set; }

        [JsonProperty("Table_No")]
        [Required]
        public long TableNo { get; set; }

        [JsonProperty("Timestamp")]
        public DateTimeOffset Timestamp { get; set; } = DateTime.Now;
    }

}
