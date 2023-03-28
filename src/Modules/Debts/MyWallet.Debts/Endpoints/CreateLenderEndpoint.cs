using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using MyWallet.Debts.DAL;
using MyWallet.Debts.DTO;
using MyWallet.Debts.Entities;

namespace MyWallet.Debts.Endpoints;

internal class CreateLenderEndpoint : Endpoint<CreateLenderRequest, CreateLenderResponse>
{
    private readonly DebtsDbContext _context;

    public CreateLenderEndpoint(DebtsDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/lenders");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CreateLenderRequest req, CancellationToken ct)
    {
        var companyName = req.CompanyName.ToLower();
        
        var lenderExists = await _context.Lenders.AnyAsync(
            l => l.CompanyName.ToLower() == companyName, cancellationToken: ct);

        if (lenderExists)
        {
            ThrowError(r => r.CompanyName, "This company name is already in use!");
        }
        
        var lender = new Lender(req.CompanyName);
        _context.Lenders.Add(lender);
        await _context.SaveChangesAsync(ct);

        var response = new CreateLenderResponse(lender.Id, lender.CompanyName);
        await SendAsync(response, cancellation: ct);
    }
}