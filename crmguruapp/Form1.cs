using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using crmguruapp.DAL;
using crmguruapp.Models;

namespace crmguruapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowCountryButton_Click(object sender, EventArgs e)
        {
            CountryInfoForm infoForm = new CountryInfoForm();
            infoForm.Show();
        }

        private void getCountryFromBDbutton_Click(object sender, EventArgs e)
        {
            var dbCountries = DAL.DAL.GetCountries();
            var countries = new List<Country>(dbCountries.Count);
            foreach (var dbCountry in dbCountries)
            {
                countries.Add(new Country()
                {
                    Name = dbCountry.Name,
                    Code = dbCountry.Code,
                    Capital = dbCountry.Capital,
                    Area = dbCountry.Area,
                    Population = dbCountry.Population,
                    Region = dbCountry.Region
                });
            }
            CountryListBox.DataSource = countries;
            CountryListBox.DisplayMember = "GetInfo";
            CountryListBox.ValueMember = "Name";
        }
    }
}
