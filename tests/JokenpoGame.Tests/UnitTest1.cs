using Xunit;
using JokenpoGame.Models;
using JokenpoGame.Services;
using JokenpoGame.Enums;

namespace JokenpoGame.Test
{
    public class JokenpoGameTests
    {
        private readonly JokenpoGameService _jokenpoService;

        public JokenpoGameTests()
        {
            _jokenpoService = new JokenpoGameService("TestPlayer");
        }

        [Fact]
        public void Teste1_Pedra_Deve_Vencer_Tesoura()
        {
            var jogadaHumano = Jogada.Pedra;
            var jogadaComputador = Jogada.Tesoura;

            var resultado = ChamarDeterminarVencedor(jogadaHumano, jogadaComputador);

            Assert.Equal(ResultadoJogo.Vitoria, resultado);
        }

        [Fact]
        public void Teste2_Papel_Deve_Vencer_Pedra()
        {
            var jogadaHumano = Jogada.Papel;
            var jogadaComputador = Jogada.Pedra;

            var resultado = ChamarDeterminarVencedor(jogadaHumano, jogadaComputador);

            Assert.Equal(ResultadoJogo.Vitoria, resultado);
        }

        [Fact]
        public void Teste3_Tesoura_Deve_Vencer_Papel()
        {
            var jogadaHumano = Jogada.Tesoura;
            var jogadaComputador = Jogada.Papel;

            var resultado = ChamarDeterminarVencedor(jogadaHumano, jogadaComputador);

            Assert.Equal(ResultadoJogo.Vitoria, resultado);
        }

        [Fact]
        public void Teste4_Jogadas_Iguais_Devem_Resultar_Em_Empate()
        {
            var jogadaHumano = Jogada.Pedra;
            var jogadaComputador = Jogada.Pedra;

            var resultado = ChamarDeterminarVencedor(jogadaHumano, jogadaComputador);

            Assert.Equal(ResultadoJogo.Empate, resultado);
        }

        [Fact]
        public void Teste5_Computador_Deve_Vencer_Quando_Joga_Papel_Contra_Pedra()
        {
            var jogadaHumano = Jogada.Pedra;
            var jogadaComputador = Jogada.Papel;

            var resultado = ChamarDeterminarVencedor(jogadaHumano, jogadaComputador);

            Assert.Equal(ResultadoJogo.Derrota, resultado);
        }

        [Theory]
        [InlineData(Jogada.Pedra, Jogada.Tesoura, ResultadoJogo.Vitoria)]
        [InlineData(Jogada.Papel, Jogada.Pedra, ResultadoJogo.Vitoria)]
        [InlineData(Jogada.Tesoura, Jogada.Papel, ResultadoJogo.Vitoria)]
        [InlineData(Jogada.Tesoura, Jogada.Pedra, ResultadoJogo.Derrota)]
        [InlineData(Jogada.Pedra, Jogada.Papel, ResultadoJogo.Derrota)]
        [InlineData(Jogada.Papel, Jogada.Tesoura, ResultadoJogo.Derrota)]
        [InlineData(Jogada.Pedra, Jogada.Pedra, ResultadoJogo.Empate)]
        [InlineData(Jogada.Papel, Jogada.Papel, ResultadoJogo.Empate)]
        [InlineData(Jogada.Tesoura, Jogada.Tesoura, ResultadoJogo.Empate)]
        public void Teste_Bonus_Todos_Cenarios_Possiveis(Jogada jogadaHumano, Jogada jogadaComputador, ResultadoJogo resultadoEsperado)
        {
            var resultado = ChamarDeterminarVencedor(jogadaHumano, jogadaComputador);

            Assert.Equal(resultadoEsperado, resultado);
        }

        private ResultadoJogo ChamarDeterminarVencedor(Jogada jogadaHumano, Jogada jogadaComputador)
        {
            var metodo = typeof(JokenpoGameService).GetMethod("DeterminarVencedor",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            return (ResultadoJogo)metodo.Invoke(_jokenpoService, new object[] { jogadaHumano, jogadaComputador });
        }
    }
}