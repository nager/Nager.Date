using Nager.Date.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Nager.Date.Monitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();

            this.textBoxYear.Text = DateTime.Now.Year.ToString();
            this.comboBoxCountry.DataSource = Enum.GetValues(typeof(CountryCode));
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            CountryCode countryCode;
            if (!Enum.TryParse(this.comboBoxCountry.Text, true, out countryCode))
            {
                return;
            }

            int year;
            if (!int.TryParse(this.textBoxYear.Text, out year))
            {
                return;
            }

            var publicHolidays = DateSystem.GetPublicHoliday(countryCode, year);

            this.dataGridViewPublicHoliday.DataSource = publicHolidays.ToList();
        }

        private void dataGridViewPublicHoliday_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewPublicHoliday.CurrentRow == null)
            {
                return;
            }

            if (this.dataGridViewPublicHoliday.CurrentRow.DataBoundItem == null)
            {
                return;
            }

            var item = this.dataGridViewPublicHoliday.CurrentRow.DataBoundItem as PublicHoliday;
            if (item.Counties == null)
            {
                this.dataGridViewDetail.DataSource = null;
            }
            else
            {
                this.dataGridViewDetail.DataSource = item?.Counties.Select(o => new { County = o }).ToList();
            }
        }
    }
}
