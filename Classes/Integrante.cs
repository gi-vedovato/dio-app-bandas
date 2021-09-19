namespace DIO.Musicas
{
    public class Integrante
    {
        public Integrante(string nome)
        {
            Nome = nome;
        }

        private string Nome { get; set; }

        public string NomeIntegrante => Nome;
    }
}
