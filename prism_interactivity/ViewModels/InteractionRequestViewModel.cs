using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace prism_interactivity.ViewModels
{
    public class InteractionRequestViewModel:BindableBase
    {
        private string resultMessage;

        public InteractionRequestViewModel()
        {
            this.ConfirmationRequest = new InteractionRequest<Confirmation>();
            this.NotificationRequest = new InteractionRequest<Notification>();
            this.CustomPopupViewRequest = new InteractionRequest<Notification>();


            this.RaiseConfirmationCommand = new DelegateCommand(this.RaiseConfirmation);
            this.RaiseNotificationCommand = new DelegateCommand(this.RaiseNotification);
            this.RaiseCustomPopupViewRequestCommand = new DelegateCommand(this.RaiseCustomPopupView); 
                
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
                this.OnPropertyChanged("InteractionResultMessage");
            }
        }

        public InteractionRequest<Confirmation> ConfirmationRequest { get; private set; }  // in using interactionRequest namespace definiert
        public InteractionRequest<Notification> NotificationRequest { get; private set; }
        public InteractionRequest<Notification> CustomPopupViewRequest { get; private set; }
       // public InteractionRequest<ItemSelectionNotification> ItemSelectionRequest { get; private set; }


        public ICommand RaiseConfirmationCommand { get; private set; }
        public ICommand RaiseNotificationCommand { get; private set; }
        public ICommand RaiseCustomPopupViewRequestCommand { get; private set; }
      //  private ICommand RaiseConfirmationCommand { get; private set; }


        private void RaiseNotification()
        {
            this.NotificationRequest.Raise(
                new Notification {Content="Notification Message", Title="Notification"},
                n=> { InteractionRusltMessage = "The user was notified.."; });
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
            
        }
    }
} 
