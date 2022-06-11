using System.Text.Json.Serialization;

namespace relationshipAPI.Model
{
    public class weapon
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = String.Empty;
        public int damage { get; set; } =10; 
        //many to many
        [JsonIgnore]
         public Charecter Charecter { get; set; }   
        public int CharecterId { get; set; }

    }
}
