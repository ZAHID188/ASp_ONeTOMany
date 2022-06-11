namespace relationshipAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } 


        //one user can have many charecters <<>> means can have many 
        public List<Charecter> Charecters { get; set; }

        
    }
}
