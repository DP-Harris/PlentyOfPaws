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
        }
    }

    public class HiddenItem : ShellItem
    {

    }
}
