namespace Samples.TypePlayer
{
    public interface IPlayer
    {
        PlayerState State { get; set; }

        void Play();
        void Rewind();
        void Stop();
    }
}