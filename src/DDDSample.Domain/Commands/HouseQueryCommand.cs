using DDDSample.Domain.Core.Events;
using MediatR;

namespace DDDSample.Domain.Commands
{
    public class HouseQueryCommand : Command<House.Models.House>
    {
        public HouseQueryCommand(string houseId)
        {
            HouseId = houseId;
        }

        public string HouseId { get; private set; }
    }
}
