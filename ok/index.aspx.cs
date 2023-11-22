using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using ok.Models;

namespace ok
{
    public partial class index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí puedes cargar las opciones de monedas para los DropDownList
                ListItem[] monedas = new ListItem[]
{
                    new ListItem("Peso Argentino", "ARS"),
                    new ListItem("Dólar Australiano", "AUD"),
                    new ListItem("Bitcoin en Efectivo", "BCH"),
                    new ListItem("Lev Búlgaro", "BGN"),
                    new ListItem("Moneda Binance", "BNB"),
                    new ListItem("Real Brasileño", "BRL"),
                    new ListItem("Bitcóin", "BTC"),
                    new ListItem("Dólar Canadiense", "CAD"),
                    new ListItem("Franco Suizo", "CHF"),
                    new ListItem("Yuan Chino", "CNY"),
                    new ListItem("Corona Checa", "CZK"),
                    new ListItem("Corona Danesa", "DKK"),
                    new ListItem("Dogecoin", "DOGE"),
                    new ListItem("Dinar Argelino", "DZD"),
                    new ListItem("Ethereum", "ETH"),
                    new ListItem("Euro", "EUR"),
                    new ListItem("Libra Esterlina Británica", "GBP"),
                    new ListItem("Dólar de Hong Kong", "HKD"),
                    new ListItem("Kuna Croata", "HRK"),
                    new ListItem("Florín Húngaro", "HUF"),
                    new ListItem("Rupia Indonesia", "IDR"),
                    new ListItem("Nuevo Shekel Israelí", "ILS"),
                    new ListItem("Rupia India", "INR"),
                    new ListItem("Corona Islandesa", "ISK"),
                    new ListItem("Yen Japonés", "JPY"),
                    new ListItem("Won Surcoreano", "KRW"),
                    
                };

                ddlMonedaOrigen.Items.AddRange(monedas);
                ddlMonedaDestino.Items.AddRange(monedas);
            }
        }

        protected async void btnConvertir_Click(object sender, EventArgs e)
        {
            string monedaOrigen = ddlMonedaOrigen.SelectedValue;
            string monedaDestino = ddlMonedaDestino.SelectedValue;

            // Intenta convertir la cantidad y verifica si la conversión fue exitosa
            if (double.TryParse(txtCantidad.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double cantidad))
            {
                Helper helper = new Helper();
                await helper.ObtenerConversionAsync(monedaOrigen, monedaDestino, cantidad);

                // Muestra el resultado de la conversión
                
                lblResultado.Text = $"El resultado de la conversión es: {helper.ConvertedAmount}";

            }
            else
            {
                // Manejar el caso en el que la conversión de la cantidad no fue exitosa
                lblResultado.Text = "Ingrese una cantidad válida.";
            }
        }



    }
}
