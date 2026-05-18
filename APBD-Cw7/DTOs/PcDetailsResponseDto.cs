namespace APBD_Cw7.DTOs;

public record PcDetailsResponseDto(
    int Id,
    string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    List<PcComponentDto> Components
);

public record PcComponentDto(
    int Amount,
    ComponentDto Component
);

public record ComponentDto(
    string Code,
    string Name,
    string Description,
    ManufacturerDto Manufacturer,
    ComponentTypeDto Type
);

public record ManufacturerDto(
    int Id,
    string Abbreviation,
    string FullName,
    DateTime FoundationDate
);

public record ComponentTypeDto(
    int Id,
    string Abbreviation,
    string Name
);