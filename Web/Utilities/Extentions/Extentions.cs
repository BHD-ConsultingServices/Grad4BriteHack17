
namespace Web.Utilities.Extentions
{
    using System.ServiceModel;

    public static class Extentions
    {
        public static bool IsReady(this CommunicationState original)
        {
            switch (original)
            {
                case CommunicationState.Created:
                case CommunicationState.Opened:
                case CommunicationState.Opening:
                    return true;

                default:
                    return false;
            }
        }
    }
}