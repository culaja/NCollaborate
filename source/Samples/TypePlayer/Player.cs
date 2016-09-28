namespace Samples.TypePlayer
{
    public class Player : IPlayer
    {
        private readonly ITypeHolder _typeHolder;

        public Player(ITypeHolder typeHolder)
        {
            _typeHolder = typeHolder;
        }

        public PlayerState State { get; set; }

        public void Play()
        {
            var type = _typeHolder.GetTypeInstance();
            if (IsPlayerReadyToPlayType(type))
            {
                PlayTypeWithStateChangeToPlaying(type);
            }
            else
            {
                // If type is not ready to be played by any reason stop it
                Stop();
            }
        }

        private bool IsPlayerReadyToPlayType(IType type)
        {
            if (type == null)
            {
                return false;
            }

            if (State != PlayerState.Stopped)
            {
                return false;
            }

            return true;
        }

        private void PlayTypeWithStateChangeToPlaying(IType type)
        {
            if (type.Play())
            {
                State = PlayerState.Playing;
            }
        }

        public void Rewind()
        {
            var type = _typeHolder.GetTypeInstance();
            if (IsPlayerReadyToRewindType(type))
            {
                RewindTypeWithStateChangeToRewinding(type);
            }
            else
            {
                // If type is not ready to be rewound by any reason stop it
                Stop();
            }
        }

        private bool IsPlayerReadyToRewindType(IType type)
        {
            if (type == null)
            {
                return false;
            }

            if (State != PlayerState.Stopped)
            {
                return false;
            }

            return true;
        }

        private void RewindTypeWithStateChangeToRewinding(IType type)
        {
            if (type.Rewind())
            {
                State = PlayerState.Rewinding;
            }
        }

        public void Stop()
        {
            var type = _typeHolder.GetTypeInstance();
            type?.Stop();
            State = PlayerState.Stopped;
        }
    }
}