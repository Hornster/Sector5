namespace Assets.Scripts.Common.Enums
{
    /// <summary>
    /// AvailableCommands available for the drone (actions they can make).
    /// </summary>
    public enum AvailableCommands
    {
        /// <summary>
        /// Causes the drone to move.
        /// </summary>
        Go,
        ToggleAirlock,
        ToggleDefenseSystems,
        Interface,
        NoCommand,

#region BUILD_COMMANDS
        BuildNoWall,
        BuildNormalCorner,
        BuildNormalSingle,
        BuildNormalHalfCross,
        BuildNormalCross,
        BuildNormalHalfSingle,
        BuildNormalOutsideDoor,
        BuildNormalInsideDoor,
        BuildNormalWindow,
        BuildFloor,
        BuildBasementCorner,
        BuildBasementSingle,
        BuildBasementHalfCross,
        BuildBasementCross,
        BuildBasementHalfSingle,
        BuildBasementOutsideDoor,
        BuildDumbledoor,
        BuildBasementInsideDoor,
        BuildBasementWindow,
        BuildBasementThirdSquare,
        BuildRoofTiltedNormal,
        BuildRoofTiltedCorner,
        BuildRoofTiltedWindow,
        BuildRoofStraightNormal,
        BuildRoofStraightCorner,
        BuildRoofStraightChimney,
#endregion BUILD_COMMANDS

    }
}
