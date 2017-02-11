using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using prism_interactivity.Notifications;

namespace prism_interactivity.ViewModels
{
    public class ItemSelectionViewModel:BindableBase,IInteractionRequestAware
    {
        private ItemSelectionNotification notification;



        #region Propriete

        public string SelectedItem { get; set; }
        public Action FinishInteraction { get; set; }

        public INotification Notification
        {
            get { return this.notification; }
            set
            {
                if (value is ItemSelectionNotification)
                {
                    this.notification = value as ItemSelectionNotification;
                    this.OnPropertyChanged(() => this.Notification);
                }
            }
        }

        #endregion

        #region Ctor
        public ItemSelectionViewModel()
        {
            this.SelectedItemCommand = new DelegateCommand(this.AcceptSelectedItem);
            this.CancelCommand = new DelegateCommand(this.CancelInteraction);

        }


        #endregion

        #region Icommand 

        public ICommand SelectedItemCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        #endregion

  

        #region Methoden 

        public void AcceptSelectedItem()
        {
            if (this.notification != null)
            {
                this.notification.SelectedItem = this.SelectedItem;
                this.notification.Confirmed = true;
            }
            this.FinishInteraction();

        }

        public void CancelInteraction()
        {
            if (this.notification!= null)
            {
                this.notification.SelectedItem = null;
                this.notification.Confirmed = false;
            }
            this.FinishInteraction();
        }

        #endregion

    





    }
}
