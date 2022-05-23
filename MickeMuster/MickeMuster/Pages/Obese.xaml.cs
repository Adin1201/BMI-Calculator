using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace MickeMuster
{
 
    public partial class Obese : ContentPage
    {
        Osoba b = new Osoba();
        public Obese(Osoba o)
        {
            InitializeComponent();
            test.Text = $"{o.bmi}";
            b.bmi = o.bmi;
            b.visina = o.visina;
            b.tezina = o.tezina;
            b.godine = o.godine;
            b.spol = o.spol;
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            
            var plan = new ObesePlan(b);
            await Navigation.PushAsync(plan);
        }
    }
}