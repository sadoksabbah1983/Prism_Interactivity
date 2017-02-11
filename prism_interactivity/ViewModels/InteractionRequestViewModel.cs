using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using prism_interactivity.Notifications;

namespace prism_interactivity.ViewModels
{
    public class InteractionRequestViewModel:BindableBase
    {
        private string resultMessage;

        public InteractionRequestViewModel()
        {
            this.ConfirmationRequest = new InteractionRequest<IConfirmation>();
            this.NotificationRequest = new InteractionRequest<INotification>();
            this.CustomPopupViewRequest = new InteractionRequest<INotification>();
            this.ItemSelectionRequest = new InteractionRequest<ItemSelectionNotification>();


            this.RaiseConfirmationCommand = new DelegateCommand(this.RaiseConfirmation);
            this.RaiseNotificationCommand = new DelegateCommand(this.RaiseNotification);
            this.RaiseCustomPopupViewRequestCommand = new DelegateCommand(this.RaiseCustomPopupView); 
            this.RaiseItemSelectionCommand = new DelegateCommand(this.RaiseItemSelection);
                
        }

        public string InteractionRusltMessage
        {
            get
            {
                return this.resultMessage;
            }
            set
            {
                this.resultMessage = value;
                this.OnPropertyChanged("InteractionRusltMessage");
            }
        }

        public InteractionRequest<IConfirmation> ConfirmationRequest { get; private set; }  // in using interactionRequest namespace definiert
        public InteractionRequest<INotification> NotificationRequest { get; private set; }
        public InteractionRequest<INotification> CustomPopupViewRequest { get; private set; }
        public InteractionRequest<ItemSelectionNotification> ItemSelectionRequest { get; private set; }


        public ICommand RaiseConfirmationCommand { get; private set; }
        public ICommand RaiseNotificationCommand { get; private set; }
        public ICommand RaiseCustomPopupViewRequestCommand { get; private set; }
        public ICommand RaiseItemSelectionCommand { get; private set; }


        private void RaiseNotification()
        {
            this.NotificationRequest.Raise(
                new Notification() {Content="Notification Message", Title="Notification"},
                c=> { InteractionRusltMessage = "The user was notified.."; });
        }

        private void RaiseConfirmation()
        {
            this.ConfirmationRequest.Raise(
                new Confirmation {Content = "Confirmation Message", Title = "Confirmation"},
                c => { InteractionRusltMessage = c.Confirmed ? "the user accepted." : "the user cancled.."; });
        }

        private void RaiseCustomPopupView()
        {
            this.InteractionRusltMessage = "";
            this.CustomPopupViewRequest.Raise(
                new Notification {Content ="Message for the CustomPopupView", Title="Custom Popup"});
        }

        private void RaiseItemSelection()
        {
            ItemSelectionNotification notification = new ItemSelectionNotification();
            notification.Items.Add("item 1");
            notification.Items.Add("item 2");
            notification.Items.Add("item 3");
            notification.Items.Add("item 4");
            notification.Items.Add("item 5");
            notification.Items.Add("item 6");

            notification.Title = "Items";

            this.InteractionRusltMessage = "";
            this.ItemSelectionRequest.Raise(notification,
            returned =>
            {
                if (returned != null && returned.Confirmed && returned.SelectedItem != null)
                {
                    this.InteractionRusltMessage = "the user selected " + returned.SelectedItem;
                }
                else
                {
                    this.InteractionRusltMessage = "the user Cancelled the Operation or didn't select an item";
                }
            });


        }
    }
} 
