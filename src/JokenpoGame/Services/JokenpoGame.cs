using JokenpoGame.Models;
using JokenpoGame.Enums;

namespace JokenpoGame.Services
{
    public class JokenpoGameService
    {
        private Jogador _jogadorHumano;
        private Jogador _jogadorComputador;
        private Random _random;

        public JokenpoGameService(string nomeJogador)
        {
            _jogadorHumano = new Jogador(nomeJogador);
            _jogadorComputador = new Jogador("Computador");
            _random = new Random();
        }

        public void IniciarJogo()
        {
            Console.WriteLine("=== JOGO JOKENPO ===");
            Console.WriteLine("Bem-vindo(a) ao Jokenpo!");
            Console.WriteLine();

            bool continuarJogando = true;

            while (continuarJogando)
            {
                JogarRodada();
                
                Console.WriteLine("\nDeseja jogar novamente? (s/n)");
                string resposta = Console.ReadLine()?.ToLower();
                continuarJogando = resposta == "s" || resposta == "sim";
                
                Console.WriteLine();
            }

            ExibirResultadoFinal();
        }
        
        private void JogarRodada()
        {
            Console.WriteLine("--- NOVA RODADA ---");
            
            Jogada jogadaHumano = ObterJogadaHumano();
            Jogada jogadaComputador = ObterJogadaComputador();
            
            ExibirJogadas(jogadaHumano, jogadaComputador);
            
            ResultadoJogo resultado = DeterminarVencedor(jogadaHumano, jogadaComputador);
            ExibirResultado(resultado);
            
            AtualizarPontuacao(resultado);
            
            ExibirPontuacao();
        }

        private Jogada ObterJogadaHumano()
        {
            Console.WriteLine("Escolha sua jogada:");
            Console.WriteLine("1 - Pedra");
            Console.WriteLine("2 - Papel");
            Console.WriteLine("3 - Tesoura");
            Console.Write("Digite sua opção (1-3): ");

            int opcao;
            
            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 3)
            {
                Console.Write("Opção inválida! Digite 1, 2 ou 3: ");
            }

            return (Jogada)opcao;
        }

        private Jogada ObterJogadaComputador()
        {
            int numeroAleatorio = _random.Next(1, 4);
            return (Jogada)numeroAleatorio;
        }

        private void ExibirJogadas(Jogada jogadaHumano, Jogada jogadaComputador)
        {
            Console.WriteLine($"\n{_jogadorHumano.Nome} jogou: {jogadaHumano}");
            Console.WriteLine($"{_jogadorComputador.Nome} jogou: {jogadaComputador}");
        }

        private ResultadoJogo DeterminarVencedor(Jogada jogadaHumano, Jogada jogadaComputador)
        {
            if (jogadaHumano == jogadaComputador)
            {
                return ResultadoJogo.Empate;
            }
            
            bool jogadorVenceu = (jogadaHumano == Jogada.Pedra && jogadaComputador == Jogada.Tesoura) ||
                                (jogadaHumano == Jogada.Papel && jogadaComputador == Jogada.Pedra) ||
                                (jogadaHumano == Jogada.Tesoura && jogadaComputador == Jogada.Papel);
            return jogadorVenceu ? ResultadoJogo.Vitoria : ResultadoJogo.Derrota;
        }
        
        private void ExibirResultado(ResultadoJogo resultado)
        {
            switch (resultado)
            {
                case ResultadoJogo.Vitoria:
                    Console.WriteLine($"{_jogadorHumano.Nome} venceu esta rodada!");
                    break;
                case ResultadoJogo.Derrota:
                    Console.WriteLine($"{_jogadorComputador.Nome} venceu esta rodada!");
                    break;
                case ResultadoJogo.Empate:
                    Console.WriteLine("Empate! Ninguém ganhou esta rodada.");
                    break;
            }
        }

        private void AtualizarPontuacao(ResultadoJogo resultado)
        {
            if (resultado == ResultadoJogo.Vitoria)
            {
                _jogadorHumano.AdicionarPonto();
            }
            else if (resultado == ResultadoJogo.Derrota)
            {
                _jogadorComputador.AdicionarPonto();
            }
        }

        private void ExibirPontuacao()
        {
            Console.WriteLine("\n--- PLACAR ATUAL ---");
            _jogadorHumano.ExibirInfo();
            _jogadorComputador.ExibirInfo();
        }

        private void ExibirResultadoFinal()
        {
            Console.WriteLine("\n RESULTADO FINAL ");
            ExibirPontuacao();
            
            if (_jogadorHumano.Pontuacao > _jogadorComputador.Pontuacao)
            {
                Console.WriteLine($"\nParabéns {_jogadorHumano.Nome}! Você foi o grande vencedor!");
            }
            else if (_jogadorComputador.Pontuacao > _jogadorHumano.Pontuacao)
            {
                Console.WriteLine($"O {_jogadorComputador.Nome} foi o grande vencedor!");
            }
            else
            {
                Console.WriteLine("O jogo terminou empatado!");
            }
            
            Console.WriteLine("Obrigado por jogar!");
        }
    }
}