using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ok.Models
{
    public class Helper
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public double Amount { get; set; }
        public double ConvertedAmount { get; set; }

        public async Task ObtenerConversionAsync(string monedaOrigen, string monedaDestino, double cantidad)
        {
            try
            {
                string apiKey = "ffd0b5621a5e473dae99384e8dffdc1d";
                string baseUri = "https://exchange-rates.abstractapi.com";

                string requestUri = $"/v1/convert?api_key={apiKey}&base={monedaOrigen}&target={monedaDestino}&base_amount={cantidad}";

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(baseUri);
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

                    HttpResponseMessage respuesta = await cliente.GetAsync(requestUri);
                    respuesta.EnsureSuccessStatusCode();

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var jsonCadena = await respuesta.Content.ReadAsStringAsync();

                        var resultadoConversion = JsonConvert.DeserializeObject<ConversionResponse>(jsonCadena);

                        ConvertedAmount = resultadoConversion.ConvertedAmount;
                    }
                    else
                    {
                        throw new Exception("Se ha producido un error al solicitar el servicio web");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error en la solicitud HTTP: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error: " + ex.Message);
            }
        }
    }
}
