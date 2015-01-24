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
	//unregister from event
	this->accel->ReadingChanged -= accToken;
	this->compass->ReadingChanged -= compassToken;

}

void Sensors::onAccelChanged(Accelerometer ^sender, AccelerometerReadingChangedEventArgs ^args)
{
	bool isInRange = false;

	// logic to determine if the Accelerometer is in range
	if (abs(args->Reading->AccelerationX) < 0.2 && abs(args->Reading->AccelerationY) < 0.2 && args->Reading->AccelerationZ <= -0.9 && args->Reading->AccelerationZ >= -1.1)
	{
		isInRange = true;
	}

	//check for changed state - notify only on change
	if (isInRange != this->accelInRange)
	{
		this->accelInRange = isInRange;
		this->NotifyReadingChanged();
	}
		
}

void Sensors::onCompassChanged(Compass ^sender, CompassReadingChangedEventArgs ^args)
{
	bool isInRange = false;

	// logic to determine if the Compass is in range - Chose +/- 5 degrees from True North
	if (args->Reading->HeadingTrueNorth->Value <= 5 || args->Reading->HeadingTrueNorth->Value >= 355)
	{
		isInRange = true;
	}

	//check for changed state - notify only on change
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
