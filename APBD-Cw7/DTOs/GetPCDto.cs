namespace APBD_Cw7.DTOs;

public record GetPCDto(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);