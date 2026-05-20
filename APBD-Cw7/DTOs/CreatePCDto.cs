namespace APBD_Cw7.DTOs;

public record CreatePCDto(
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);