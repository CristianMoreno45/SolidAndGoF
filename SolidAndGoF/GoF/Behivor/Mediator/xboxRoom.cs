using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Behivor.Mediator
{
    public class xboxRoom
    {
        public interface IMediator
        {
            void RegisterPlayRoom(PlayRoom playRoom);
            void RegisterBoy(Boy boy);
            bool IsPlayRoomAvailable();
            void SetPlayRoomAvailability(bool status);

        }

        public class Mediator : IMediator
        {
            private PlayRoom _playRoom { get; set; }
            private Boy _boy { get; set; }
            private bool _isAvailableStatus { get; set; }
            public void RegisterPlayRoom(PlayRoom playRoom)
            {
                _playRoom = playRoom;
            }
            public void RegisterBoy(Boy boy)
            {
                _boy = boy;
            }
            public bool IsPlayRoomAvailable() => _isAvailableStatus;

            public void SetPlayRoomAvailability(bool availableStatus)
            {
                _isAvailableStatus = availableStatus;
            }
        }

        public class Boy
        {
            private IMediator _mediator;

            public Boy(IMediator mediator)
            {
                _mediator = mediator;
            }
            public bool Play() => _mediator.IsPlayRoomAvailable();
        }

        public class PlayRoom
        {
            private IMediator _mediator;

            public PlayRoom(IMediator mediator)
            {
                _mediator = mediator;
                _mediator.SetPlayRoomAvailability(false);
            }

            public void GivePermission()
            {
                _mediator.SetPlayRoomAvailability(true);
            }
        }
    }
}
