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
using System.Threading;

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
            if (string.IsNullOrWhiteSpace(CountryNameField.Text))
            {
                MessageBox.Show("Введите название страны");
                return;
            }
            var country = await SendQueryToApi(CountryNameField.Text);
            if (country == null)
            {
                MessageBox.Show("Страна не найдена");
                return;
            }
            var dialogResult = MessageBox.Show(country.GetInfo, "Сохранить в БД?", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            if (AddToBD(country))
            {
                MessageBox.Show("Страна сохранена");
            }
            else
                MessageBox.Show("Ошибка сохранения");
        }

        private async Task<Country> SendQueryToApi(string field)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string request = $"https://restcountries.eu/rest/v2/name/{field}";
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(request);
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

                    List<Country> country = JsonConvert.DeserializeObject<List<Country>>(responseBody);
                    return country?.FirstOrDefault();
                }
                return null;
            }
        }
        private bool AddToBD(Country c)
        {
            var success = DAL.DAL.InsertCity(c.Name, c.Code,
                        c.Capital, c.Area,
                        c.Population, c.Region);
            return success;
        }

    }
}
