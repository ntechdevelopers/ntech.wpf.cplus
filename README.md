# POC Ntech.WPF.CPlus

This project demonstrates integrating a WPF (Windows Presentation Foundation) application with a native C++ DLL using P/Invoke.

## Project Structure

- **WpfGuiClient/**: Main WPF application (C#)
- **Meteo/**: C++ DLL project providing weather data
- **Ntech.WPFToolkit/**: WPF Toolkit/DataGrid sample library
- **_External/**: Compiled binaries (DLL, EXE, etc.)

## How It Works

- The WPF app (`WpfGuiClient`) loads the C++ DLL (`Meteo.dll`) and calls its functions using P/Invoke.
- The main window has a button to trigger data retrieval from the DLL, displaying weather info (name, ID, temperature, humidity) in a list.
- The C++ DLL (`Meteo`) provides hardcoded weather data and sends it back to the UI via callbacks.
- Logging and UI updates are handled through delegates and marshaling between managed and unmanaged code.

## Build & Run

1. Open `Ntech.WPF.CPlus.sln` in Visual Studio.
2. Build the solution (ensure the C++ DLL is built and available to the WPF app).
3. Run the WPF app. Click "Run" to fetch and display weather data from the DLL.

## Credits
- WPF Toolkit/DataGrid sample code is from [smoura.com](http://smoura.com/introducing-the-wpf-toolkit-datagrid/)
