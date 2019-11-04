using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.WebApi.Models.TradeCenter
{
    public class CreateTradeRecordRequest
    {
        [Required]
        [StringLength(32)]
        public string HouseId { get; set; }

        [Required]
        [StringLength(32)]
        public string SellerId { get; set; }

        [Required]
        [StringLength(32)]
        public string BuyerId { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
