using EncurtadorDeURL;
using EncurtadorDeUrlLibrary.Models;

namespace EncurtadorDeUrlTestes
{
/*
 * Receber uma URL e retornar um objeto que cont�m:
 * [X]ID da requisi��o
 * [X]URL curta que foi gerada
 * [X]Tempo de segundos pelo ual a URL ser� v�lida
 * 
 * []Retornar a URL original ao consultar uma url curta v�lida
 * []Retornar um erro, caso n�o exista uma URL original v�lida para a URL curta consultada
 * []A �ltima parte da URL encurtada deve ter no m�ximo 7 caracteres
 */
    public class UnitTest1
    {
        [Fact]
        public void Testa_Se_A_URL_Retorna_Objeto_valido()
        {
            // Arrange
            var url = "https://www.google.com";
            var encurtador = new EncurtadorDeUrl();
            // Act
            var resultado = encurtador.Encurtar(url);
            // Assert
            Assert.NotNull(resultado);
        }
        [Fact]
        public void Testa_Se_A_URL_Encurtada_Eh_Diferente_Da_Original()
        {
            // Arrange
            var url = "https://www.google.com";
            var encurtador = new EncurtadorDeUrl();
            // Act
            var resultado = encurtador.Encurtar(url);
            // Assert
            Assert.NotEqual(url, resultado.UrlCurta);
        }
        [Fact]
        public void Testa_Se_A_URL_Encurtada_Respeita_O_Tamanho_Limite()
        {
            // Arrange
            var url = "https://www.google.com";
            var encurtador = new EncurtadorDeUrl();
            // Act
            var resultado = encurtador.Encurtar(url);
            resultado.UrlCurta = "1";
            // Assert
            Assert.True(resultado.UrlCurta.Length <= 7);
        }
    }
}