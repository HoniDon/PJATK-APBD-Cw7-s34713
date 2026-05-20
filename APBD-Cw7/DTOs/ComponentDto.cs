namespace APBD_Cw7.DTOs;

public record ComponentDto(
    string Code,
    string Name,
    string Description,
    ComponentManufacturerDto Manufacturer,
    ComponentTypeDto Type
);
