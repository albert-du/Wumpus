namespace WumpusJones
{
    public record Hazard(HazardType Type, Room location)
    {
        public string Message => Type switch
        {
            HazardType.Wumpus => "Boulder message",
            HazardType.SuperBats => "Snakes message",
            HazardType.Pit => "pit message ",
            _ => string.Empty
        };
    }
}