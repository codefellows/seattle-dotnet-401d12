using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XDemo.ViewModels;
using XDemo.Views;

namespace XDemo
{
  public partial class AppShell : Xamarin.Forms.Shell
  {
    public AppShell()
    {
      InitializeComponent();
      Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
      Routing.RegisterRoute(nameof(MotionPage), typeof(MotionPage));
    }

  }
}
