using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MickeMuster
{
 
    public partial class Normal : ContentPage
    {
        Osoba b = new Osoba();
        public Normal(Osoba o)
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

            var plan = new NormalPlan(b);
            await Navigation.PushAsync(plan);
        }
    }
}