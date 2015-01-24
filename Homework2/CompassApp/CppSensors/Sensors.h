#pragma once
using namespace Windows::Devices::Sensors;
using namespace Windows::Foundation;

namespace CppSensors
{
	public delegate void sensorsChangedEvent(bool accelerometer, bool compass);

	public ref class Sensors sealed
	{
	private:
		Accelerometer ^accel;
		Compass ^compass;
		bool accelInRange;
		bool compassInRange;

		//registration tokens so we can unregester from an event
		EventRegistrationToken accToken;
		EventRegistrationToken compassToken;

		// Internal function that gets called by the Accelerometer thread when it has a new reading for us
		void onAccelChanged(Accelerometer ^sender, AccelerometerReadingChangedEventArgs ^args);

		// Internal function that gets called by the Compass thread when it has a new reading for us
		void onCompassChanged(Compass ^sender, CompassReadingChangedEventArgs ^args);
		void NotifyReadingChanged();

	public:
		Sensors();
		virtual ~Sensors();

		// Event that we trigger when we have a status change
		event sensorsChangedEvent^ ReadingChanged;

		void startMonitoringSensors();
		void stopMonitoringSensors();
	};
}