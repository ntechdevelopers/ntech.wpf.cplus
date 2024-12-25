#pragma once

#include "MeteoInfo.h"

typedef void(*logCallback)(const wchar_t* msg);
typedef void(*uiCallback)(const WeatherForecast::MeteoInfo* info, const int size);

// Exported interface
class __declspec(dllexport) IMeteo {
public:
	virtual void Send(void) = 0;
};

// Exported methods
// Creates an IMeteo given a callback function from the PInvoke client
extern "C" __declspec(dllexport) IMeteo* CreateMeteo(uiCallback, logCallback);
// signals the Meteo object to start sending data
extern "C" __declspec(dllexport) void Send(IMeteo*);
// Destroys a meteo object
extern "C" __declspec(dllexport) void DestroyMeteo(IMeteo*);
