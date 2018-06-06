using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeatherForecast.WeatherService;

namespace WeatherForecast
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		WeatherWebService w = new WeatherWebService();
		public int standard = 0;

		private void Form1_Load(object sender, EventArgs e)
		{			
			string[] supportProvince = w.getSupportProvince();
			foreach (string p in supportProvince)
			{
				ProvienceName.Items.Add(p);
			}			
		}

		private void ProvienceName_SelectedValueChanged(object sender, EventArgs e)
		{
			CityName.Items.Clear();
			CityName.Text = "";
			string[] supportCity = w.getSupportCity(ProvienceName.Text);
			foreach (String c in supportCity)
			{
				string[] city = c.Split(new Char[] { '(' }, StringSplitOptions.RemoveEmptyEntries);
				if (city.Length > 0)
				CityName.Items.Add(city[0]);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string[] Result = new string[23];
			string city = CityName.Text;
			Result = w.getWeatherbyCityName(city);
			//for (int i = 1; i < 32; i++)
			//{
			//	textBox1.Text = Result[i] + "\r\n";
			//}
			textBox1.Text = Result[0]+" "+ Result[1] + "\r\n" + Result[4] +"\r\n" +Result[10];
		}
	}
}
