using Grpc.Core;
using HealthCare.Documents.Api.Protos;

namespace HealthCare.Documents.Api.Services
{
    public class DocumentsService : DocumentService.DocumentServiceBase
    {
        public override Task<Document> Get(DocumentId request, ServerCallContext context)
        {
            return base.Get(request, context);
        }

        public override Task<DocumentList> GetAll(Empty request, ServerCallContext context)
        {
            return base.GetAll(request, context);
        }
    }
}
