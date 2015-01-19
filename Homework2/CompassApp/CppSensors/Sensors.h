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
		EventRegistrationToken accToken;
		EventRegistrationToken compassToken;

		

		// Internal function that gets called by the Accelerometer thread when it has a new reading for us
		void onAccelChanged(Accelerometer ^sender, AccelerometerReadingChangedEventArgs ^args);
		void onCompassChanged(Compass ^sender, CompassReadingChangedEventArgs ^args);
		void NotifyReadingChanged();

	public:
		Sensors();
		virtual ~Sensors();

		// Event that we trigger when we have a new reading
		event sensorsChangedEvent^ ReadingChanged;

		void startMonitoringSensors();
		void stopMonitoringSensors();
	};
}