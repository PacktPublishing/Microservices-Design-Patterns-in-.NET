using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using HealthCare.Doctors.Api.Models;
using HealthCare.Documents.Api.Protos;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Empty = HealthCare.Documents.Api.Protos.Empty;

namespace HealthCare.Documents.Api.Services;

public class DocumentsService : DocumentService.DocumentServiceBase
{
    private readonly DocumentsDbContext _context;

    public DocumentsService(DocumentsDbContext context)
    {
        this._context = context;
    }

    public override async Task<Document> Get(DocumentId request, ServerCallContext context)
    {
        var document = await _context.Documents.FindAsync(request.Id);
        return new Document { Id = document?.Id.ToString(), 
            Name = document?.Name, 
            PatientId = document?.PatientId.ToString(),
            Path = document?.Path };
    }

    public override async Task<DocumentList> GetAll(PatientId request, ServerCallContext context)
    {
        DocumentList documentList = new ();
        var docs = await _context.Documents
            .Select(q => new Document { 
                Id = q.Id.ToString(), 
                Name = q.Name, 
                PatientId = q.PatientId.ToString() })
            .Where(q => q.PatientId.ToString() == request.PatientId_)
            .ToListAsync();
        documentList.Documents.AddRange(docs);
        return documentList;
    }

    public override async Task<Empty> Insert(Document requestData, ServerCallContext context)
    {
        await _context.Documents.AddAsync(
            new Models.Document(
                Guid.NewGuid(),
                Guid.Parse(requestData.PatientId),
                requestData.Name,
                requestData.Path)
            );

        await _context.SaveChangesAsync();
        return new Empty();
    }

    public override async Task<Empty> Delete(DocumentId request, ServerCallContext context)
    {
        var document = await _context.Documents.FindAsync(request.Id);

        _context.Documents.Remove(document);
        await _context.SaveChangesAsync();
        return new Empty();
    }

    public override async Task<Empty> Update(Document request, ServerCallContext context)
    {
        var document = new Models.Document(
                Guid.Parse(request.Id),
                Guid.Parse(request.PatientId),
                request.Name,
                request.Path);

        _context.Documents.Update(document);

        await _context.SaveChangesAsync();
        return new Empty();
    }
}
