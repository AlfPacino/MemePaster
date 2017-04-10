using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using MemePaster.Model;
using System.IO;
using MemePaster.Util;
using Microsoft.Win32;

namespace MemePaster.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings settings;
        const string settingsFileName = "Settings.xml";
        //const int defaultMemeSize = 100;
        private void ApplySettings()
        {
            this.Height = settings.WindowHeight;
            this.Width = settings.WindowWidth;
        }
        private void CollectSettings()
        {
            settings.WindowHeight = this.Height;
            settings.WindowWidth = this.Width;
        }
        private void ReorganizeMemeCells()
        {
            wrapPanel.Children.Clear();
            foreach (var meme in settings.MemeCells)
            {
                var img = new Image();
                img.Source = Converter.BytesToImage(meme.Image);
                var button = new MemeButton();
                var res = (ResourceDictionary)Application.LoadComponent(new Uri("ResourceDictionaries/ResourceDictionary.xaml", UriKind.Relative));
                button.Style = (Style)res["MemeButtonStyle"];
                button.MemeCell = new MemeCell(meme.Image);
                button.Click += MemeClick;
                var imgBrush = new ImageBrush();
                imgBrush.ImageSource = Converter.BytesToImage(meme.Image);
                button.Background = imgBrush;
                wrapPanel.Children.Add(button);
            }
        }

        private void MemeClick(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                foreach (var item in settings.MemeCells)
                {
                    if (item.Image == (sender as MemeButton).MemeCell.Image)
                    {
                        settings.MemeCells.Remove(item);
                        break;
                    }
                }
                ReorganizeMemeCells();
            }
            Clipboard.SetImage(Converter.BytesToImage(((sender as MemeButton).MemeCell.Image)));
        }
        // Event handlers
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(settingsFileName))
            {
                try
                {
                    settings = Serealizer.OpenSettings(settingsFileName);
                }
                catch (Exception exep)
                {
                    MessageBox.Show("Error while decoding settings ... ");
                    settings = new Settings();
                }
            }
            else
            {
                settings = new Settings();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ApplySettings();
            ReorganizeMemeCells();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            CollectSettings();
            Serealizer.SaveSettings(settings, settingsFileName);
        }

        private void buttonAddMeme_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Open Meme";
            dialog.Filter = "jpg images (*.jpg)|*.jpg|png images (*.png)|*.png|bmp images (*.bmp)|*.bmp";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == true)
            {
                foreach (var memeImage in dialog.FileNames)
                {
                    // get meme image
                    var bmImage = new BitmapImage(new Uri(memeImage));
                    // change it`s size
                    bmImage = ImageManager.ChangeImageSize(settings.MemeImageWidth, settings.MemeImageHeight, bmImage);
                    // save as MemeCell
                    settings.MemeCells.Add(new MemeCell(Converter.ImageToBytes(bmImage)));
                }
                ReorganizeMemeCells();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ReorganizeMemeCells();
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left)
                //this.DragMove();
        }
    }
}
