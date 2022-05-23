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
    public partial class NormalPlan : ContentPage
    {
        double index = 0;
        Osoba a = new Osoba();
        public NormalPlan(Osoba o)
        {
            a.bmi = o.bmi;
            a.visina = o.visina;
            a.tezina = o.tezina;
            a.spol = o.spol;
            a.godine = o.godine;
            InitializeComponent();
            bmi.Text = $"{Math.Round(o.bmi)}";
            visina.Text = $"{Math.Round(o.visina)}";
            tezina.Text = $"{Math.Round(o.tezina)}";
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {

            double bmr = 0;
            if (picker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Odaberite nivo aktivnosti prvo.", "OK");
                return;
            }
            else
            {
                if (a.spol.Equals("m"))
                {
                    // BMR for Men = 66.47 + (13.75 * weight[kg]) + (5.003 * size[cm]) − (6.755 * age[years])
                    bmr = Math.Round(66.4 + (13.7 * a.tezina) + (5 * a.visina) - (6.7 * a.godine));

                }
                else
                {
                    bmr = Math.Round(655 + (9.5 * a.tezina) + (1.8 * a.visina) - (4.6 * a.godine));
                }
                if (picker.SelectedIndex == 0)
                {
                    bmr *= 1.2;
                }
                else if (picker.SelectedIndex == 1)
                {
                    bmr *= 1.4;
                }
                else if (picker.SelectedIndex == 2)
                {
                    bmr *= 1.6;
                }
                else if (picker.SelectedIndex == 3)
                {
                    bmr *= 1.9;
                }
                String bmrt = Convert.ToString(bmr);
                promijena.Text = $"Vas dnevni unos kalorija za održavanje trenutne kilaže je: {bmrt}. Naša preporuka je da povećate fizičke aktivnosti kao i unos proteina u toku dana za što optimalnije zdravlje.";
                odrzavanje.IsVisible = !odrzavanje.IsVisible;
                gubitak.IsVisible = !gubitak.IsVisible;
                debljanje.IsVisible = !debljanje.IsVisible;
                lbl1.IsVisible = !lbl1.IsVisible;
                lbl2.IsVisible = !lbl2.IsVisible;
                lbl3.IsVisible = !lbl3.IsVisible;
                poruka.IsVisible = !poruka.IsVisible;
                odrzavanje.Text = $"{Math.Round(bmr)} kCal";
                gubitak.Text = $"{Math.Round(bmr) - 300} kCal";
                debljanje.Text = $"{Math.Round(bmr) + 300} kCal";
            }
        }
    }
}