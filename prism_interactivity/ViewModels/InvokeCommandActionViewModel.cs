using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Converters;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace prism_interactivity.ViewModels
{
    public class InvokeCommandActionViewModel:BindableBase
    {
        private string selectetdItemText;


        #region Ctor

        public InvokeCommandActionViewModel()
        {
            this.Items = new List<string>();
            this.Items.Add("Item 1");
            this.Items.Add("Item 2");
            this.Items.Add("Item 3");
            this.Items.Add("Item 4");

            this.SelectedCommand = new DelegateCommand<object[]>(this.OnItemSelected);
        }

        #endregion

        #region Propreiete

        public string SelectedItemText
        {
            get { return this.selectetdItemText; }
            private set { this.SetProperty(ref this.selectetdItemText, value); }
        }
        public IList<string> Items { get; private set; }


        #endregion

        #region Command

        public ICommand SelectedCommand { get; private set; }

        #endregion

        #region Methoden

        private void OnItemSelected(object[] obj)
        {
            if (obj != null && obj.Count() > 0)
            {
                this.SelectedItemText = obj.FirstOrDefault().ToString();
            }
        }

        #endregion



    }
}
