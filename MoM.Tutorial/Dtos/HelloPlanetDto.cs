namespace MoM.Tutorial.Dtos
{
    public partial class HelloPlanetDto
    {
        public int helloPlanetId { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public HelloPlanetDto() { }

        public HelloPlanetDto(int HelloPlanetId, string Name, string Description)
        {
            helloPlanetId = HelloPlanetId;
            name = Name;
            description = Description;
        }
    }
}
