using System.Text.Json.Serialization;

namespace relationshipAPI.Model
{
    public class Charecter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string  rpgClass { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
