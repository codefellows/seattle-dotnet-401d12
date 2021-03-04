using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Essentials;

namespace XDemo.ViewModels
{
  class MotionViewModel : BaseViewModel
  {

    private float x;
    private float y;
    private float z;
    private bool shaking;

    public bool isShaking
    {
      get => shaking;
      set => SetProperty(ref shaking, value);
    }
    public float X
    {
      get => x;
      set => SetProperty(ref x, value);
    }

    public float Y
    {
      get => y;
      set => SetProperty(ref y, value);
    }

    public float Z
    {
      get => z;
      set => SetProperty(ref z, value);
    }

    // Set speed delay for monitoring changes.
    SensorSpeed speed = SensorSpeed.UI;

    public MotionViewModel()
    {
      // Register for reading changes, be sure to unsubscribe when finished
      Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
      Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;

      // Crossing of Streams ... why did John do contacts and accelerometer in the same file???
      GetContacts();

    }

    public async void GetContacts()
    {
      // cancellationToken parameter is optional
      var cancellationToken = default(CancellationToken);
      var contacts = await Contacts.GetAllAsync(cancellationToken);
    }

    void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
      // Process Acceleration X, Y, and Z
      var data = e.Reading;
      X = data.Acceleration.X;
      Y = data.Acceleration.Y;
      Z = data.Acceleration.Z;
      Console.WriteLine($"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}");
    }

    void Accelerometer_ShakeDetected(object sender, EventArgs e)
    {
      isShaking = true;
    }

    public void ToggleAccelerometer()
    {
      try
      {
        if (Accelerometer.IsMonitoring)
          Accelerometer.Stop();
        else
          Accelerometer.Start(speed);
      }
      catch (FeatureNotSupportedException fnsEx)
      {
        // Feature not supported on device
      }
      catch (Exception ex)
      {
        // Other error has occurred.
      }
    }


  }
}
