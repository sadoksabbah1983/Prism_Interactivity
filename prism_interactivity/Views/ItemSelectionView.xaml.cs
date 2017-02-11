using System.Windows.Controls;
using prism_interactivity.ViewModels;

namespace prism_interactivity.Views
{
    /// <summary>
    /// Interaction logic for ItemSelectionView.xaml
    /// </summary>
    public partial class ItemSelectionView : UserControl
    {
        public ItemSelectionView()
        {
            this.DataContext = new ItemSelectionViewModel();
            InitializeComponent();
        }
    }
}
