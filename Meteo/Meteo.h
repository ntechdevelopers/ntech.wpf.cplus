#pragma once

#include "IMeteo.h"

namespace WeatherForecast
{
	class Meteo : public IMeteo
	{
		uiCallback m_ucb;
		logCallback m_lcb;

	public:
		Meteo(uiCallback ub, logCallback lb) : m_ucb(ub),m_lcb(lb) {}

		void Send(void);
	};
}