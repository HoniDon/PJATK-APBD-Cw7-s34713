namespace APBD_Cw7.DTOs;

public record GetPCWithComponentsDto(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PCComponentDetailDto> Components
);