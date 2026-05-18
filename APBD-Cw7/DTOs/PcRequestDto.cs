namespace APBD_Cw7.DTOs;

public record PcRequestDto(
    string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);