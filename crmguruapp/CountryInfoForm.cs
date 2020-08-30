using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using crmguruapp.Models;

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
                DAL.DAL.logger.Info($"Страна {country.Name} добавлена в БД");
            }
            else
            {
                MessageBox.Show("Ошибка сохранения");
                DAL.DAL.logger.Warn($"Не получилось добавить {country.Name} в БД");
            }
        }

        private async Task<Country> SendQueryToApi(string field)
        {
            try
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
            catch (HttpRequestException ex)
            {
                DAL.DAL.logger.Error(ex, "Ошибка при обращении к API");
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
