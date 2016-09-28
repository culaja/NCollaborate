using NCollaborate.Session;

namespace Samples.TypePlayer.CollaborateLogic
{
    public class PlayerSutController : IPlayer
    {
        private readonly IPlayer _originalObject;
        private readonly ISutSession _sutSession;

        public PlayerSutController(IPlayer originalObject, ISutSession sutSession)
        {
            _originalObject = originalObject;
            _sutSession = sutSession;
        }

        public PlayerState State
        {
            get
            {
                _sutSession.IsSutOperationExecuting = true;
                _sutSession.CurrentlyExecutingOperationName = "GetState";

                try
                {
                    var result = _originalObject.State;
                    return result;
                }
                finally
                {
                    _sutSession.IsSutOperationExecuting = false;
                }
            }

            set
            {
                _sutSession.IsSutOperationExecuting = true;
                _sutSession.CurrentlyExecutingOperationName = "SetState";

                try
                {
                    _originalObject.State = value;
                }
                finally
                {
                    _sutSession.IsSutOperationExecuting = false;
                }
            }
        }
        public void Play()
        {
            _sutSession.IsSutOperationExecuting = true;
            _sutSession.CurrentlyExecutingOperationName = "Play";

            try
            {
                _originalObject.Play();
            }
            finally
            {
                _sutSession.IsSutOperationExecuting = false;
            }
        }

        public void Rewind()
        {
            _sutSession.IsSutOperationExecuting = true;
            _sutSession.CurrentlyExecutingOperationName = "Rewind";

            try
            {
                _originalObject.Rewind();
            }
            finally
            {
                _sutSession.IsSutOperationExecuting = false;
            }
        }

        public void Stop()
        {
            _sutSession.IsSutOperationExecuting = true;
            _sutSession.CurrentlyExecutingOperationName = "Stop";

            try
            {
                _originalObject.Stop();
            }
            finally
            {
                _sutSession.IsSutOperationExecuting = false;
            }
        }
    }
}
