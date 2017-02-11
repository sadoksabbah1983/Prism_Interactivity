using System.Collections.Generic;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace prism_interactivity.Notifications
{
    public class ItemSelectionNotification: Confirmation
    {   
        public string SelectedItem { get; set; }
        public IList<string> Items { get; private set; }

        public ItemSelectionNotification()
        {
            this.Items = new List<string>();
            this.SelectedItem = null;

        }

        public ItemSelectionNotification(IEnumerable<string> items):this()
        {
            foreach (string item in items)
            {
                this.Items.Add(item);
            }
        }

    }
}
