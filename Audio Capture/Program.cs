using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio_Capture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Enumerate audio capture devices
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDeviceCollection devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);

            // Print the attributes of the active capture device
            MMDevice activeDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Console);
            Console.WriteLine("Active device: " + activeDevice.FriendlyName);
            Console.WriteLine("Default format: " + activeDevice.AudioClient.MixFormat);
            Console.WriteLine("State: " + activeDevice.State);
            Console.WriteLine("Device ID: " + activeDevice.ID);
            //Console.WriteLine("Device interface name: " + activeDevice.DeviceInterfaceName);

            // Loop through each capture device and print its name
            foreach (MMDevice device in devices)
            {
                Console.WriteLine("Device name: " + device.FriendlyName);
            }

            Console.ReadLine();
        }
    }
}
