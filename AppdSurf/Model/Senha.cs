namespace AppdSurf.Model
{
    public class Senha
    {
        public Guid Id { get; set; }
        public string? Letra { get; set;}
        
        public Senha() { 
            Id = Guid.NewGuid();
        }
    }
}
