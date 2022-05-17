using PlentyOfPaws.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlentyOfPaws
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("registration", typeof(RegistrationModal));

            Routing.RegisterRoute("Dogregistration", typeof(AddDog));

        }
    }

    public class HiddenItem : ShellItem
    {

    }
}
