
namespace Web.Utilities
{
    using System;
    using System.ServiceModel;
    using System.Threading;
    using System.Web.Services.Description;
    using Extentions;

    public class ServiceClientWrapper<TClient, TIService> : IDisposable
              where TClient : ClientBase<TIService>, TIService
              where TIService : class
    {
        private TClient _serviceClient;
        private readonly Binding _binding;
        private readonly EndpointAddress _endpoint;
        private const int RetryCoolDownInSeconds = 1;

        public ServiceClientWrapper() { }
        public ServiceClientWrapper(Binding binding, EndpointAddress endpointAddress)
        {
            _binding = binding;
            _endpoint = endpointAddress;
        }

        public TClient ServiceClient
        {
            get
            {
                return this._serviceClient = this._serviceClient ?? this.CreateClient();
            }
        }

        public void Excecute(
            Action<TIService> serviceCall,
            int retryAttempts = 1,
            Action<CommunicationException> exceptionHandler = null)
        {
            Excecute<object>(
                service => { serviceCall.Invoke(service); return null; },
                retryAttempts,
                exceptionHandler);
        }

        private void OnException(string errorMessage, string originalMethodName, ref int errors, ref int retryAttempts)
        {
            errors++;
            var logErrorMessage = $"WCF Operation Failure: Service [{typeof(TClient)}].[{originalMethodName}] Failed ({errors} out of {retryAttempts}). Exception [{errorMessage}]";
            //TODO: Log Message

            if (retryAttempts <= 1) return;

            var logSleepMessage = $"Retry cooldown initiated ({RetryCoolDownInSeconds}s)";
            //TODO: Log Message

            Thread.Sleep(RetryCoolDownInSeconds * 1000);
        }

        public TResult Excecute<TResult>(
            Func<TIService, TResult> serviceCall,
            int retryAttempts = 1,
            Action<CommunicationException> exceptionHandler = null)
        {
            var errors = 0;
            var completed = false;
            CommunicationException exception = null;
            var response = default(TResult);

            while (!completed && errors < retryAttempts)
            {
                try
                {
                    if (!this.ServiceClient.State.IsReady())
                    {
                        this.DisposeClient();

                        if (!this.ServiceClient.State.IsReady())
                        {
                            throw new CommunicationObjectFaultedException($"WCF Client state is not valid. Connection Status [{this.ServiceClient.State}]");
                        }
                    }

                    response = serviceCall.Invoke(this.ServiceClient);
                    completed = true;

                    if (errors > 1)
                    {
                        //TODO: Log Message
                    }
                }
                catch (CommunicationException comsException)
                {
                    if (exceptionHandler != null)
                    {
                        try
                        {
                            exceptionHandler.Invoke(exception);
                        }
                        catch (CommunicationException reThrowException)
                        {
                            exception = reThrowException;
                        }
                    }

                    OnException(comsException.Message, serviceCall.Method.Name, ref errors, ref retryAttempts);
                }
                catch (Exception ex)
                {
                    OnException(ex.Message, serviceCall.Method.Name, ref errors, ref retryAttempts);
                }
                finally
                {
                    if (!completed)
                    {
                        this.DisposeClient();
                    }
                    else
                    {
                        this.ServiceClient.Close();
                    }
                }
            }

            if (!completed)
            {
                throw exception ?? new CommunicationException($"WCF Operation Failure: Service [{typeof(TClient)}].[{serviceCall.Method.Name}]");
            }

            return response;
        }

        public void Dispose()
        {
            this.DisposeClient();
        }

        protected virtual TClient CreateClient()
        {
            if (_binding != null && _endpoint != null)
            {
                return (TClient)Activator.CreateInstance(typeof(TClient), _binding, _endpoint);
            }

            return (TClient)Activator.CreateInstance(typeof(TClient));
        }

        private void DisposeClient()
        {
            if (this._serviceClient == null)
            {
                return;
            }
            try
            {
                switch (this._serviceClient.State)
                {
                    case CommunicationState.Closing:
                    case CommunicationState.Faulted:
                        this._serviceClient.Abort();
                        break;
                    case CommunicationState.Closed:
                        break;
                    default:
                        this._serviceClient.Close();
                        break;
                }
            }
            catch
            {
                this._serviceClient.Abort();
            }
            finally
            {
                this._serviceClient = null;
            }
        }
    }
}