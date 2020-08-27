using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using crmguruapp.Models;
using crmguruapp.DAL;
namespace crmguruapp
{
    public partial class CountryInfoForm : Form
    {
        public CountryInfoForm()
        {
            InitializeComponent();
        }

        private async void SearchCountryButton_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            string request = $"https://restcountries.eu/rest/v2/name/{CountryNameField.Text}";
            HttpResponseMessage httpResponseMessage = (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

            List<Country> country = JsonConvert.DeserializeObject<List<Country>>(responseBody);

            DialogResult dialogResult = MessageBox.Show(country.FirstOrDefault().GetInfo, "Сохранить в БД?", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            var success = DAL.DAL.InsertCity(country.FirstOrDefault().Name, country.FirstOrDefault().Code,
                country.FirstOrDefault().Capital, country.FirstOrDefault().Area,
                country.FirstOrDefault().Population, country.FirstOrDefault().Region);
            var userMessage = success ? "Страна сохранена" : "Ошибка ";
            MessageBox.Show(userMessage);
        }
    }
}
