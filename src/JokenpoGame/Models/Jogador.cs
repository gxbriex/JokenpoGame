namespace JokenpoGame.Models
{
    public class Jogador
    {
        public string Nome { get; set; }
        public int Pontuacao { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Pontuacao = 0;
        }

        public void AdicionarPonto()
        {
            Pontuacao++;
        }

        public void ExibirInfo()
        {
            Console.WriteLine($"Jogador: {Nome} | Pontos: {Pontuacao}");
        }
    }
}