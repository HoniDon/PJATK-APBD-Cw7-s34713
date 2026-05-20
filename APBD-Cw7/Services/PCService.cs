using APBD_Cw7.DTOs;
using APBD_Cw7.Exceptions;
using APBD_Cw7.Infrastructure;
using APBD_Cw7.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Cw7.Services;

public class PCService(AppDbContext ctx) : IPCService
{
    public async Task<IEnumerable<GetPCDto>> GetAllPCsAsyncs(CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Select(pc => new GetPCDto(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock
            ))
            .ToListAsync();
    }

    public async Task<GetPCWithComponentsDto?> GetPCByIdAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs
            .Where(pc => pc.Id == id)
            .Select(pc => new GetPCWithComponentsDto(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,
                pc.PCComponents.Select(c => new PCComponentDetailDto(
                    c.Amount,
                    new ComponentDto(
                        c.Component.Code,
                        c.Component.Name,
                        c.Component.Description,
                        new ComponentManufacturerDto(
                            c.Component.ComponentManufacturer.Id,
                            c.Component.ComponentManufacturer.Abbreviation,
                            c.Component.ComponentManufacturer.FullName,
                            c.Component.ComponentManufacturer.FoundationDate
                        ),
                        new ComponentTypeDto(
                            c.Component.ComponentType.Id,
                            c.Component.ComponentType.Abbreviation,
                            c.Component.ComponentType.Name
                        )
                    )
                ))
            ))
            .FirstOrDefaultAsync(cancellationToken);
        
        if (pc == null) throw new NotFoundException($"PC with id {id} not found");
        
        return pc;
    }

    public async Task<GetPCDto> CreatePCAsync(CreatePCDto dto, CancellationToken cancellationToken)
    {
        var newPc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = DateTime.Now,
            Stock = dto.Stock
        };
        
        await ctx.PCs.AddAsync(newPc, cancellationToken);
        await ctx.SaveChangesAsync(cancellationToken);
        
        return new GetPCDto(
            newPc.Id,
            newPc.Name,
            newPc.Weight,
            newPc.Warranty,
            newPc.CreatedAt,
            newPc.Stock
        );
    }

    public async Task<bool> UpdatePCAsync(int id, UpdatePCDto dto, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken);
        if (pc == null) throw new NotFoundException($"PC with id {id} not found");
        
        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.Stock = dto.Stock;
        
        await ctx.SaveChangesAsync(cancellationToken);
        
        return true;
    }

    public async Task<bool> DeletePCAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken);
        if (pc == null) throw new NotFoundException($"PC with id {id} not found");
        
        ctx.PCs.Remove(pc);
        await ctx.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}