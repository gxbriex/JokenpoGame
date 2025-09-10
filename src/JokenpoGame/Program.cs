using JokenpoGame.Services;

namespace JokenpoGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Digite seu nome: ");
            string nomeJogador = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(nomeJogador))
            {
                nomeJogador = "Jogador";
            }
            
            JokenpoGameService jogo = new JokenpoGameService(nomeJogador);
            
            jogo.IniciarJogo();
        }
    }
}