namespace Samples.TypePlayer.CollaborateLogic
{
    public class TypeCollector : IType
    {
        public IType OriginalObject { get; }

        public TypeCollector(IType originalObject)
        {
            OriginalObject = originalObject;
        }

        public bool Play()
        {
            return OriginalObject.Play();
        }

        public bool Rewind()
        {
            return OriginalObject.Rewind();
        }

        public void Stop()
        {
            OriginalObject.Stop();
        }
    }
}
