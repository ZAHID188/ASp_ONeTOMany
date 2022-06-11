using System.Text.Json.Serialization;

namespace relationshipAPI.Model
{
    public class Skills
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int Damage { get; set; }
        [JsonIgnore]
        public List<Charecter> Charecters { get; set; }
    }
}
