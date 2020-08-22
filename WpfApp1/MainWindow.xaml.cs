using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int PositiveScore { set; get; }
        private int NegativeScore { set; get; }
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        private void ChoiceWord()
        {
            using (var file = new FileStream("dict.json", FileMode.Open))
            {
                dictionary = JsonSerializer.DeserializeAsync<Dictionary<string, string>>(file).Result;
            }

            Label_Word.Text = dictionary.First().Key;
            Button_Variant1.Content = dictionary.First().Value;
            Button_Variant2.Content = "опасность";
            Button_Variant3.Content = "забыл";
            Button_Variant4.Content = "ого";

        }
        public MainWindow()
        {
            InitializeComponent();
            ChoiceWord();
        }

        private void Button_Variant_OnClick(object sender, RoutedEventArgs e)
        {
            var temp = (Button)sender;
            var word = dictionary.First().Value;
            if (word == temp.Content.ToString())
            {
                Label_ScorePositive.Text = "Верно - 1";
            }
            else
            {
                Label_ScoreNegative.Text = "Неверно - 1";
            }
        }
    }
}
