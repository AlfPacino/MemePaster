using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MemePaster.Model;
using System.Windows;
using System;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using MemePaster.Util;
using System.Windows.Input;

namespace MemePaster.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            WindowTitle = "Meme Paster";
            AddMemeCommand = new RelayCommand(AddMemeAction);
            AboutCommand = new RelayCommand(ShowAboutWindowAction);
        }

        public RelayCommand AddMemeCommand { get; private set; }
        public RelayCommand AboutCommand { get; private set; }
        public RelayCommand CopyMemeCommand { get; private set; }
        public string WindowTitle { get; set; }
        public Settings Settings { get; set; }

        private void AddMemeAction()
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
                    bmImage = ImageManager.ChangeImageSize(Settings.MemeImageWidth, Settings.MemeImageHeight, bmImage);
                    // save as MemeCell
                    Settings.MemeCells.Add(new MemeCell(Converter.ImageToBytes(bmImage)));
                }
            }
        }
        private void ShowAboutWindowAction()
        {
            
        }
        private void CopyMemeAction()
        {
            //if (Keyboard.IsKeyDown(Key.LeftCtrl))
            //{
            //    foreach (var item in Settings.MemeCells)
            //    {
            //        if (item.Image == (sender as MemeButton).MemeCell.Image)
            //        {
            //            Settings.MemeCells.Remove(item);
            //            break;
            //        }
            //    }
            //}
            //Clipboard.SetImage(Converter.BytesToImage(((sender as MemeButton).MemeCell.Image)));
        }
    }
}