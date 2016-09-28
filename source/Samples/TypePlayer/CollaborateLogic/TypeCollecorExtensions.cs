using NSubstitute;

namespace Samples.TypePlayer.CollaborateLogic
{
    public static class TypeCollecorExtensions
    {
        public static IType DidNotReceive(this IType substitute)
        {
            var typeCollector = substitute as TypeCollector;
            if (typeCollector != null)
            {
                return typeCollector.OriginalObject.DidNotReceive<IType>();
            }

            return substitute;
        }

        public static IType Received(this IType substitute)
        {
            var typeCollector = substitute as TypeCollector;
            if (typeCollector != null)
            {
                return typeCollector.OriginalObject.Received<IType>();
            }

            return substitute;
        }

        public static IType Received(this IType substitute, int requiredNumberOfCalls)
        {
            var typeCollector = substitute as TypeCollector;
            if (typeCollector != null)
            {
                return typeCollector.OriginalObject.Received<IType>(requiredNumberOfCalls);
            }

            return substitute;
        }
    }
}
