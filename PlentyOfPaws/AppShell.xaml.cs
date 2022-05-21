using PlentyOfPaws.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlentyOfPaws
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        // Initializes main app startup and hold some dedicated direct routes we can create more in this area as pages are needed. 
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("registration", typeof(RegistrationModal));
            Routing.RegisterRoute("RegisterDog", typeof(RegisterDog));
        }
    }

    public class HiddenItem : ShellItem
    {
    }
}
