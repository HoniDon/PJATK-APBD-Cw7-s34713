namespace APBD_Cw7.DTOs;

public record UpdatePCDto(
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);