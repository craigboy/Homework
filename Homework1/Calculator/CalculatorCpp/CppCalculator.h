#pragma once

namespace CalculatorCpp
{
    public ref class CppCalculator sealed
    {
	private:
		double outputValue;
	public:
		CppCalculator();
		void add(double value);
		void subtract(double value);
		void multiply(double value);
		void divide(double value);
		double getOutputValue();
    };
}