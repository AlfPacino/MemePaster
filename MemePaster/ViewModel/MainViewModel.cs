using GalaSoft.MvvmLight;
using MemePaster.Model;

namespace MemePaster.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            WindowTitle = "Meme Paster";
        }
        public string WindowTitle { get; set; }
        public Settings Settings { get; set; }
    }
}