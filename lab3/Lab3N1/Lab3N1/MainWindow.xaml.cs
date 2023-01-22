using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Lab3N1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void ButtonLevel_Click(object sender, RoutedEventArgs e)
        {
            if (LevelNumber.Text == "")
            {
                return;
            }

            foreach (ListViewItem item in ExhibitionPlanLevel.Items)
            {
                if ((string)item.Content == LevelNumber.Text)
                {
                    LevelNumber.Clear();
                    return;
                }
            }
            Level level = new Level()
            {
                Number = LevelNumber.Text
            };

            ListViewItem LVI = new ListViewItem();
            LVI.Content = level.Number;
            LVI.Tag = level;

            ExhibitionPlanLevel.Items.Add(LVI);
            LevelNumber.Clear();
        }

        private void ExhibitionPlanLevel_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var currentLVI = ExhibitionPlanLevel.SelectedItem as ListViewItem;

            if (currentLVI != null)
            {
                ExhibitionPlanLevel.Visibility = Visibility.Hidden;
                ExhibitionPlanHall.Visibility = Visibility.Visible;

                CurrentLocationLabel.Visibility = Visibility.Visible;
                CurrentLocationLabel.Content = $"Этаж: {currentLVI.Content}";

                PlanLabel.Content = "План выставки: Залы";

                AddElementLevel.Visibility = Visibility.Hidden;
                AddElementHall.Visibility = Visibility.Visible;

                ExhibitionPlanHall.Items.Clear();

                var itemList = (currentLVI.Tag as Level).HallList;

                foreach (Hall el in itemList)
                {
                    ListViewItem LVI = new ListViewItem();
                    LVI.Content = el.Name;
                    LVI.Tag = el;
                    ExhibitionPlanHall.Items.Add(LVI);
                }
            }
        }

        private void ButtonHall_Click(object sender, RoutedEventArgs e)
        {
            if (HallName.Text == "")
            {
                return;
            }

            foreach (ListViewItem item in ExhibitionPlanHall.Items)
            {
                if ((string)item.Content == HallName.Text)
                {
                    HallName.Clear();
                    return;
                }
            }

            Hall hall = new Hall()
            {
                Name = HallName.Text
            };

            var currentLVI = ExhibitionPlanLevel.SelectedItem as ListViewItem;
            (currentLVI.Tag as Level).HallList.Add(hall);

            ListViewItem LVI = new ListViewItem();
            LVI.Content = hall.Name;
            LVI.Tag = hall;

            ExhibitionPlanHall.Items.Add(LVI);
            HallName.Clear();
        }

        private void ExhibitionPlanHall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ExhibitionPlanHall.Visibility = Visibility.Hidden;
            ExhibitionPlanExhibit.Visibility = Visibility.Visible;

            Clear_TextBoxes();

            var currentLVI = ExhibitionPlanHall.SelectedItem as ListViewItem;

            if (currentLVI != null)
            {

                CurrentLocationLabel.Content += $" Зал: {currentLVI.Content}";

                PlanLabel.Content = "План выставки: Экспонаты";

                AddElementHall.Visibility = Visibility.Hidden;
                AddElementExhibit.Visibility = Visibility.Visible;

                ExhibitionPlanExhibit.Items.Clear();

                var itemList = (currentLVI.Tag as Hall).ExhibitList;

                foreach (Exhibit el in itemList)
                {
                    ListViewItem LVI = new ListViewItem();
                    LVI.Content = el.Name;
                    LVI.Tag = el;
                    ExhibitionPlanExhibit.Items.Add(LVI);
                }
            }
        }

        private void ButtonExhibit_Click(object sender, RoutedEventArgs e)
        {
            if (ExhibitName.Text == "")
            {
                return;
            }

            foreach (ListViewItem item in ExhibitionPlanExhibit.Items)
            {
                if ((string)item.Content == ExhibitName.Text)
                {
                    ExhibitName.Clear();
                    return;
                }
            }

            Exhibit exhibit = new Exhibit()
            {
                Name = ExhibitName.Text,
                Description = ExhibitDescription.Text,
                Year = ExhibitYear.Text,
                Author = ExhibitAuthor.Text
            };

            var currentLVI = ExhibitionPlanHall.SelectedItem as ListViewItem;
            (currentLVI.Tag as Hall).ExhibitList.Add(exhibit);

            ListViewItem LVI = new ListViewItem();
            LVI.Content = exhibit.Name;
            LVI.Tag = exhibit;

            ExhibitionPlanExhibit.Items.Add(LVI);

            ExhibitName.Clear();
            ExhibitDescription.Clear();
            ExhibitYear.Clear();
            ExhibitAuthor.Clear();
        }

        private void ExhibitionPlanExhibit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentLVI = ExhibitionPlanExhibit.SelectedItem as ListViewItem;

            Clear_TextBoxes();

            if (currentLVI != null)
            {
                var exhibit = currentLVI.Tag as Exhibit;

                ExhibitName.Text = exhibit.Name;
                ExhibitDescription.Text = exhibit.Description;
                ExhibitYear.Text = exhibit.Year;
                ExhibitAuthor.Text = exhibit.Author;
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (ExhibitionPlanHall.Visibility == Visibility.Visible)
            {
                ExhibitionPlanHall.Items.Clear();
                ExhibitionPlanHall.Visibility = Visibility.Hidden;
                ExhibitionPlanLevel.Visibility = Visibility.Visible;
                ExhibitionPlanExhibit.Visibility = Visibility.Hidden;

                CurrentLocationLabel.Visibility = Visibility.Hidden;

                AddElementHall.Visibility = Visibility.Hidden;
                AddElementLevel.Visibility = Visibility.Visible;
                PlanLabel.Content = "План выставки: Этажи";
            }
            else if(ExhibitionPlanExhibit.Visibility == Visibility.Visible)
            {
                ExhibitionPlanExhibit.Items.Clear();
                ExhibitionPlanExhibit.Visibility = Visibility.Hidden;
                ExhibitionPlanHall.Visibility = Visibility.Visible;
                ExhibitionPlanLevel.Visibility = Visibility.Hidden;

                AddElementExhibit.Visibility = Visibility.Hidden;
                AddElementHall.Visibility = Visibility.Visible;
                PlanLabel.Content = "План выставки: Залы";
                if (ExhibitionPlanLevel.SelectedItem != null)
                {
                    CurrentLocationLabel.Content = $"Этаж: {(ExhibitionPlanLevel.SelectedItem as ListViewItem).Content}";
                }
            }
        }
        
        private void SerializeXML(Exhibition exhibition)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Exhibition));

            using (FileStream fs = new FileStream("Exhibition.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, exhibition);
            }
        }

        private void ButtonSerialize_Click(object sender, RoutedEventArgs e)
        {
            Exhibition exhibition = new Exhibition();
            foreach(ListViewItem item in ExhibitionPlanLevel.Items)
            {
                if (item.Tag != null)
                {
                    exhibition.LevelList.Add((Level)item.Tag);
                }
            }
            Clear_ToStartMenu();
            SerializeXML(exhibition);

        }

        private Exhibition DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Exhibition));

            using (FileStream fs = new FileStream("Exhibition.xml", FileMode.OpenOrCreate))
            {
                return (Exhibition)xml.Deserialize(fs);
            }
        }

        private void ButtonDeserialize_Click(object sender, RoutedEventArgs e)
        {
            Exhibition exhibition = DeserializeXML();

            Clear_ToStartMenu();

            foreach (Level item in exhibition.LevelList)
            {
                ListViewItem LVI = new ListViewItem();
                LVI.Content = item.Number;
                LVI.Tag = item;
                ExhibitionPlanLevel.Items.Add(LVI);
            }

        }

        private void Clear_ToStartMenu()
        {
            ExhibitionPlanExhibit.Items.Clear();
            ExhibitionPlanHall.Items.Clear();
            ExhibitionPlanLevel.Items.Clear();

            ExhibitionPlanLevel.Visibility = Visibility.Visible;
            AddElementLevel.Visibility = Visibility.Visible;

            ExhibitionPlanHall.Visibility = Visibility.Hidden;
            ExhibitionPlanExhibit.Visibility = Visibility.Hidden;

            AddElementExhibit.Visibility = Visibility.Hidden;
            AddElementHall.Visibility = Visibility.Hidden;

            CurrentLocationLabel.Visibility = Visibility.Hidden;
            PlanLabel.Content = "План выставки: Этажи";

            Clear_TextBoxes();
        }

        private void Clear_TextBoxes()
        {
            LevelNumber.Clear();
            HallName.Clear();
            ExhibitName.Clear();
            ExhibitDescription.Clear();
            ExhibitYear.Clear();
            ExhibitAuthor.Clear();
        }
    }
}
