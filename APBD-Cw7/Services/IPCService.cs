using APBD_Cw7.DTOs;

namespace APBD_Cw7.Services;

public interface IPCService
{
    Task<IEnumerable<GetPCDto>> GetAllPCsAsyncs(CancellationToken cancellationToken);
    Task<GetPCWithComponentsDto?> GetPCByIdAsync(int id, CancellationToken cancellationToken);
    Task<GetPCDto> CreatePCAsync(CreatePCDto dto, CancellationToken cancellationToken);
    Task<bool> UpdatePCAsync(int id, UpdatePCDto dto, CancellationToken cancellationToken);
    Task<bool> DeletePCAsync(int id, CancellationToken cancellationToken);
}