#pragma once

namespace WeatherForecast
{
	struct MeteoInfo
	{
		wchar_t* DisplayName;
		wchar_t* UniqueID;
		int	Temp;
		double Humidity;
	};
}