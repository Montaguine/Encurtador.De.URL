using EncurtadorDeUrlLibrary.Models;

namespace EncurtadorDeUrlLibrary.Services
{
    public class EncurtadorDeUrlService
    {
        private readonly List<EncurtadorDeUrl> _encurtadorDeUrl = [];
        private int _contador = 0;
        private readonly int VALIDADE_DA_URL = 120;
        public EncurtadorDeUrl Encurtar(string url)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string urlCurta = new string(Enumerable.Repeat(chars, 7).Select(s => s[random.Next(s.Length)]).ToArray());
            var encurtador = CreateEncurtadorDeUrl();
            encurtador.UrlOriginal = url;
            encurtador.UrlCurta = urlCurta;
            return encurtador;
        }
        public EncurtadorDeUrl CreateEncurtadorDeUrl()
        {
            var encurtadorDeUrl = new EncurtadorDeUrl();
            encurtadorDeUrl.RequisicaoID = _contador+1;
            encurtadorDeUrl.TempoDeValidade = VALIDADE_DA_URL;
            return encurtadorDeUrl;
        }
        public void AddEncurtadorDeUrl(EncurtadorDeUrl encurtadorDeUrl)
        {
            _encurtadorDeUrl.Add(encurtadorDeUrl);
            _contador++;
        }
        public EncurtadorDeUrl GetEncurtadorDeUrl(string urlCurta)
        {
            return _encurtadorDeUrl.FirstOrDefault(x => x.UrlCurta == urlCurta);
        }
        public object? GetAll()
        {
            return _encurtadorDeUrl;
        }
    }
}