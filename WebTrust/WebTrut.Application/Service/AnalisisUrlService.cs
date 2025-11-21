using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTrut.Application.DTOs;
using WebTrut.Application.Interfaces;

namespace WebTrut.Application.Service
{
     public  class AnalisisUrlService :IAnalisisUrlService
    {



        public async Task<AnalisisResultadoDto> AnalizarSitioWebAsync(string url)
        {
            var titulo = await ObtenerTituloSitioAsync(url);
            var porcentaje = await CalcularConfianzaAsync(url, titulo);
            var detalles = await GenerarDetallesAsync(url, titulo, porcentaje);

            return new AnalisisResultadoDto
            {
                Url = url,
                Titulo = titulo,
                PorcentajeConfianza = porcentaje,
                Detalles = detalles
            };
        }

        private async Task<string> ObtenerTituloSitioAsync(string url)
        {
            try
            {
                using var http = new HttpClient();
                var html = await http.GetStringAsync(url);

                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var titleNode = doc.DocumentNode.SelectSingleNode("//title");

                if (titleNode != null)
                    return titleNode.InnerText.Trim();

                return "Sin título";
            }
            catch
            {
                return "No accesible";
            }
        }


        private async Task<double> CalcularConfianzaAsync(string url, string titulo)
        {
            double score = 0;

            // 1️⃣ HTTPS (seguridad)
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                score += 25;

            // 2️⃣ Título válido
            if (!string.IsNullOrWhiteSpace(titulo) && titulo != "Sin título" && titulo != "No accesible")
                score += 20;

            // 3️⃣ Respuesta HTTP correcta
            using (var http = new HttpClient())
            {
                try
                {
                    var response = await http.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                        score += 25;
                }
                catch
                {
                    // no suma nada
                }
            }

            // 4️⃣ Presencia de meta etiquetas SEO
            if (await ContieneMetaTagsValidas(url))
                score += 20;

            // 5️⃣ Penalizar por palabras sospechosas
            if (url.Contains("gratis") || url.Contains("oferta") || url.Contains("regalo") || url.Contains("premio"))
                score -= 15;

            // Limitar entre 0 y 100
            return Math.Clamp(score, 0, 100);
        }
        private async Task<bool> ContieneMetaTagsValidas(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = await web.LoadFromWebAsync(url);

                var metaDescription = doc.DocumentNode.SelectSingleNode("//meta[@name='description']");
                var metaKeywords = doc.DocumentNode.SelectSingleNode("//meta[@name='keywords']");

                return metaDescription != null || metaKeywords != null;
            }
            catch
            {
                return false;
            }
        }
        private Task<string> GenerarDetallesAsync(string url, string titulo, double score)
        {
            var detalles = $"El sitio {url} fue analizado con éxito. ";

            if (url.StartsWith("https"))
                detalles += "Tiene certificado SSL. ";
            else
                detalles += "No utiliza HTTPS. ";

            if (!string.IsNullOrWhiteSpace(titulo) && titulo != "Sin título" && titulo != "No accesible")
                detalles += $"El título del sitio es: '{titulo}'. ";

            if (score > 80)
                detalles += "El sitio parece muy confiable.";
            else if (score > 50)
                detalles += "El sitio parece medianamente confiable.";
            else
                detalles += "El sitio presenta señales de baja confianza.";

            return Task.FromResult(detalles);
        }
    }
}


