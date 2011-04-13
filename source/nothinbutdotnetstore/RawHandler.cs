using System;
using System.Web;

namespace nothinbutdotnetstore
{
    public class RawHandler : IHttpHandler
    {
        private IProcessIncomingWebRequests requestProcessor;
        private ICreateRequests requestCreator;

        public RawHandler(IProcessIncomingWebRequests requestProcessor, ICreateRequests requestCreator)
        {
            this.requestProcessor = requestProcessor;
            this.requestCreator = requestCreator;
        }

        public void ProcessRequest(HttpContext context)
        {
            requestProcessor.process(requestCreator.create_request_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }

    }
}