using JokenpoGame.Enums;
using JokenpoGame.Services;
using JokenpoGame.Models;

namespace JokenpoGameTest
{
    [TestClass]
    public class JokenpoGameServiceTests
    {
        private JokenpoGameService _jokenpoGame;
        
        [TestInitialize]
        public void Setup()
        {
            _jokenpoGame = new JokenpoGameService("JogadorDeTeste");
        }

        #region Testes de Lógica do Vencedor

        [TestMethod]
        [DataRow(Jogada.Pedra, Jogada.Pedra, ResultadoJogo.Empate)]
        [DataRow(Jogada.Papel, Jogada.Papel, ResultadoJogo.Empate)]
        [DataRow(Jogada.Tesoura, Jogada.Tesoura, ResultadoJogo.Empate)]
        public void DeterminarVencedor_QuandoJogadasSaoIguais_DeveRetornarEmpate(Jogada jogadaHumano, Jogada jogadaComputador, ResultadoJogo resultadoEsperado)
        {
            var resultado = _jokenpoGame.DeterminarVencedor(jogadaHumano, jogadaComputador);
            
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        [DataRow(Jogada.Pedra, Jogada.Tesoura, ResultadoJogo.Vitoria)]
        [DataRow(Jogada.Papel, Jogada.Pedra, ResultadoJogo.Vitoria)]
        [DataRow(Jogada.Tesoura, Jogada.Papel, ResultadoJogo.Vitoria)]
        public void DeterminarVencedor_QuandoJogadorHumanoGanha_DeveRetornarVitoria(Jogada jogadaHumano, Jogada jogadaComputador, ResultadoJogo resultadoEsperado)
        {
            var resultado = _jokenpoGame.DeterminarVencedor(jogadaHumano, jogadaComputador);
            
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        [DataRow(Jogada.Tesoura, Jogada.Pedra, ResultadoJogo.Derrota)]
        [DataRow(Jogada.Pedra, Jogada.Papel, ResultadoJogo.Derrota)]
        [DataRow(Jogada.Papel, Jogada.Tesoura, ResultadoJogo.Derrota)]
        public void DeterminarVencedor_QuandoJogadorHumanoPerde_DeveRetornarDerrota(Jogada jogadaHumano, Jogada jogadaComputador, ResultadoJogo resultadoEsperado)
        {
            var resultado = _jokenpoGame.DeterminarVencedor(jogadaHumano, jogadaComputador);
            
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        #endregion

        #region Testes da Classe Jogador

        [TestMethod]
        public void ConstrutorJogador_QuandoCriado_DeveIniciarComPontuacaoZero()
        {
            var jogador = new Jogador("Novo Jogador");
            
            Assert.AreEqual(0, jogador.Pontuacao);
            Assert.AreEqual("Novo Jogador", jogador.Nome);
        }

        [TestMethod]
        public void AdicionarPonto_QuandoChamado_DeveIncrementarPontuacao()
        {
            var jogador = new Jogador("Pontuador");
            
            jogador.AdicionarPonto();

            Assert.AreEqual(1, jogador.Pontuacao);
        }

        #endregion
    }
}