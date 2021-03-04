using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XDemo.ViewModels;

namespace XDemo.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class HomePage : ContentPage
  {
    readonly HomeViewModel _vm;
    public HomePage()
    {
      InitializeComponent();
      // Create a reference to the BindingContext (which is our view model instance)
      BindingContext = _vm = new HomeViewModel();
    }

    protected override void OnAppearing()
    {
      // This is what happens when you have a shot at 2:30 am and watcy youtube...
      Task.Run(async () => await _vm.GetAllItems()).Wait();
    }

    public void OnEnterPressed(object sender, EventArgs e)
    {
      // call a method in the view model
      _vm.Save();
    }
  }
}