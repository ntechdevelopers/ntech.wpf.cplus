using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;

namespace WpfGuiClient
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public delegate void LogDelegate(IntPtr value);

    // Managed MeteoInfo struct
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MMeteoInfo
    {
        // Properties, not fields to serve data binding
        public string DisplayName { get; private set; }
        public string UniqueID { get; private set; }
        public int Temp { get; private set; }
        public double Humidity { get; private set; }
    }

    // Callback for the UI update event
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void GuiUpdateDelegate(IntPtr infoArray, int size);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable, INotifyPropertyChanged
    {
        // DLL methods

        //These are the functions exported from the DLL that we call.
        [DllImport(@"Meteo.dll")]
        private static extern IntPtr CreateMeteo(
            [MarshalAs(UnmanagedType.FunctionPtr)] GuiUpdateDelegate gu,
            [MarshalAs(UnmanagedType.FunctionPtr)] LogDelegate ld);

        [DllImport(@"Meteo.dll")]
        private static extern void DestroyMeteo(IntPtr instance);
        //Signals the DLL to send data
        [DllImport(@"Meteo.dll")]
        private static extern void Send(IntPtr instance);

        // Meta Level Logging

        public event PropertyChangedEventHandler PropertyChanged;

        private LogDelegate ld;

        public void LogUpdate(IntPtr msg)
        {
            LogString = Marshal.PtrToStringUni(msg);
        }

        private string logString;
        public string LogString
        {
            get { return logString; }
            set 
            { 
                logString = logString + "\n" + value;
                OnPropertyChanged("LogString");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
       
        // (Periodic) GUI updates

        private MMeteoInfo[] infos;
        private int offset = Marshal.SizeOf<MMeteoInfo>();

        public void GuiUpdate(IntPtr infoArray, int size)
        {
            if (infos == null || infos.Length != size)
                infos = new MMeteoInfo[size];

            for (int i = 0; i < size; i++)
                infos[i] = (MMeteoInfo)Marshal.PtrToStructure(infoArray + i * offset, typeof(MMeteoInfo));

            // Crude but simple. Alternatively, use INotifyPropertyChanged.
            InfoList.ItemsSource = infos;
        }

        private GuiUpdateDelegate gud;
        private IntPtr _this = IntPtr.Zero;

        // Constructor
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = this;

            ld = new LogDelegate(LogUpdate);

            LogString = "No messages yet.";

            gud = new GuiUpdateDelegate(GuiUpdate);
            _this = CreateMeteo(gud, ld);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Send(_this);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_this != IntPtr.Zero)
            {
                //Call the DLL Export to delete this class
                DestroyMeteo(_this);
                _this = IntPtr.Zero;
            }
            if (disposing)
            {
                //No need to call the finalizer since we've now cleaned
                //up the unmanaged memory
                GC.SuppressFinalize(this);
            }
        }

        //This finalizer is called when Garbage collection occurs, but only if
        //the IDisposable.Dispose method wasn't already called.
        ~MainWindow()
        {
            Dispose(false);
        }
    }
}
