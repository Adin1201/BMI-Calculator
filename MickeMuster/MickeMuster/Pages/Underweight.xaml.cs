using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MickeMuster
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Underweight : ContentPage
    {
        Osoba b = new Osoba();
        public Underweight(Osoba o)
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

            var plan = new UnderweightPlan(b);
            await Navigation.PushAsync(plan);
        }
    }
}