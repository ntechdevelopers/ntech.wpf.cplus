// Meteo.cpp : Defines the exported functions and class for the DLL application.
//
#include "stdafx.h"
#include "Meteo.h"

IMeteo* CreateMeteo(uiCallback ub, logCallback lb) {
	return new WeatherForecast::Meteo(ub, lb);
}

void Send(IMeteo* im) {
	im->Send();
}

void DestroyMeteo(IMeteo* im) {
	delete im;
}

namespace WeatherForecast {
	MeteoInfo m_infos[] = {
			{ L"Ntech 1", L"123-123-123", 25, 60.3 },
			{ L"Ntech 2", L"456-456-456", 27, 81.25 },
			{ L"Ntech 3", L"789-789-789", 33, 36.7 }
	};

	void Meteo::Send() {
		m_lcb(L"Ntech has started running.");
		m_ucb(m_infos, 3);
	}
}

