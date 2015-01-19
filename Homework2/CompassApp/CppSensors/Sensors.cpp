// Class1.cpp
#include "pch.h"
#include "Sensors.h"
#include <math.h>

using namespace CppSensors;
using namespace Platform;

Sensors::Sensors()
{
	this->accelInRange = false;
	this->compassInRange = false;
	
	this->accel = Accelerometer::GetDefault();
	this->accel->ReportInterval = this->accel->MinimumReportInterval;

	this->compass = Compass::GetDefault();
	this->compass->ReportInterval = this->compass->MinimumReportInterval;
}

Sensors::~Sensors()
{
	this->stopMonitoringSensors();
}

void Sensors::startMonitoringSensors()
{
	this->accToken = this->accel->ReadingChanged += ref new TypedEventHandler<Accelerometer ^, AccelerometerReadingChangedEventArgs ^>(this, &Sensors::onAccelChanged);
	this->compassToken = this->compass->ReadingChanged += ref new TypedEventHandler<Compass ^, CompassReadingChangedEventArgs ^>(this, &Sensors::onCompassChanged);
}

void Sensors::stopMonitoringSensors()
{

	this->accel->ReadingChanged -= accToken;
	this->compass->ReadingChanged -= compassToken;

}

void Sensors::onAccelChanged(Accelerometer ^sender, AccelerometerReadingChangedEventArgs ^args)
{
	bool isInRange = false;

	if (abs(args->Reading->AccelerationX) < 0.2 && abs(args->Reading->AccelerationY) < 0.2 && args->Reading->AccelerationZ <= -0.95)
	{
		isInRange = true;
	}

	// logic to determine if the sensors are in range
	if (isInRange != this->accelInRange)
	{
		this->accelInRange = isInRange;
		this->NotifyReadingChanged();
	}
		
}

void Sensors::onCompassChanged(Compass ^sender, CompassReadingChangedEventArgs ^args)
{
	bool isInRange = false;

	if (args->Reading->HeadingTrueNorth->Value <= 5 || args->Reading->HeadingTrueNorth->Value >= 355)
	{
		isInRange = true;
	}

	if (isInRange != this->compassInRange)
	{
		this->compassInRange = isInRange;
		this->NotifyReadingChanged();
	}
}

void Sensors::NotifyReadingChanged()
{
	this->ReadingChanged(this->accelInRange, this->compassInRange);
}
