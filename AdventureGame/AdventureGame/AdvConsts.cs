namespace AdventureGame;

/// <summary>
/// AdventureConstants contains classes that
/// define any constants that might be needed
/// 'globally' throughout the game.
/// </summary>
///     

public enum RoomId
{
    GoreStreet,
    Alleyway,
    DeadEnd,
    OpiumTerrace,
    DaggerStreet,
    RipperMews,
    GardenN,
    GardenS,
    OakTree,
    VegetableGarden,
    PalmHouse,
    Balcony,
    DesertedShop,
    Basement,
    Attic,
    Bedroom,
    Kitchen,
    NOEXIT
}

public enum ObjectId
{
    Leaflet,
    SignGoreStreet,
    SignOpiumTerrace,
    Bone,
    Coin,
    Knife,
    Lamp,
    Acorn,
    Bed,
    Key,
    Bin,
    Chest
}

public enum Direction {
    NORTH,
    SOUTH,
    EAST,
    WEST,
    UP,
    DOWN
}