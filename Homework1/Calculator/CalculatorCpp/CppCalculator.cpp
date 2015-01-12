// CppCalculator.cpp
#include "pch.h"
#include "CppCalculator.h"

using namespace CalculatorCpp;
using namespace Platform;

CppCalculator::CppCalculator()
{
	outputValue = 0;
}

void CppCalculator::add(double value)
{
	outputValue += value;
}

void CppCalculator::subtract(double value)
{
	outputValue -= value;
}

void CppCalculator::multiply(double value)
{
	outputValue *= value;
}

void CppCalculator::divide(double value)
{
	outputValue /= value;

}

double CppCalculator::getOutputValue()
{
	return outputValue;
}