using System;
using NCollaborate.Session;

namespace Samples.TypePlayer.CollaborateLogic
{
    public class TypeCollector : IType
    {
        private readonly ITestSession _testSession;
        private readonly ISutSession _sutSession;

        public TypeCollector(IType originalObject, ITestSession testSession, ISutSession sutSession)
        {
            OriginalObject = originalObject;
            _testSession = testSession;
            _sutSession = sutSession;
        }

        public IType OriginalObject { get; }

        public bool Play()
        {
            var result = OriginalObject.Play();

            if (_sutSession.IsSutOperationExecuting)
            {
                var message = $"Operation '{_sutSession.CurrentlyExecutingOperationName}' called IType.Play() that returned {result}";
                Console.WriteLine(message);
            }

            return result;
        }

        public bool Rewind()
        {
            var result = OriginalObject.Rewind();

            if (_sutSession.IsSutOperationExecuting)
            {
                var message = $"Operation '{_sutSession.CurrentlyExecutingOperationName}' called IType.Rewind() that returned {result}";
                Console.WriteLine(message);
            }

            return result;
        }

        public void Stop()
        {
            OriginalObject.Stop();

            if (_sutSession.IsSutOperationExecuting)
            {
                var message = $"Operation '{_sutSession.CurrentlyExecutingOperationName}' called IType.Stop()";
                Console.WriteLine(message);
            }
        }
    }
}
