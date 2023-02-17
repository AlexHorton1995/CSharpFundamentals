// Calculator.cpp : Created a basic calculator :)
/*
	This app is a simple calculator that allows you to display integer or double returned numbers.
	It only does small numbers. Anything too big will give you the answer back in scientific notation.
*/

#include <iostream>
#include <cmath>
#include <ctype.h>
#include <string>
#include <cstring>
#include <iomanip>

using namespace std;
using std::string;

#pragma region Top Level Function Declarations

bool isValidNumber(string usrValue1, string usrValue2, char operType);
double doMath(string usrValue1, string usrValue2, char operType);
bool is_whole(double d);

#pragma endregion

int main()
{
	long num1, num2;
	double num3;
	string usrInput, usrInput2, usrInput3 = "";
	bool exitFlag = true;
	char operType;
	

	while (exitFlag)
	{
		cout << "Enter First Number: " << endl;
		cin >> usrInput;
		cout << "Enter Second Number: " << endl;
		cin >> usrInput2;
		cout << "What do you want to do?" << endl;
		cout << "1 = Add, 2 = Subtract, 3 = Multiply, 4 = Divide: ";
		cin >> operType;

		if (isValidNumber(usrInput, usrInput2, operType)) {	
			num3 = doMath(usrInput, usrInput2, operType);

			if (!is_whole(num3)) {
				cout << "Value is " << setprecision(7) << doMath(usrInput, usrInput2, operType) << endl;
			}
			else {
				cout << "Value is " << doMath(usrInput, usrInput2, operType) << endl;
			}

			cout << "Do you wish to Continue? (Y/N) ";
			cin >> usrInput3;

			if (usrInput3 != "Y" && usrInput3 != "y") {
				exitFlag = false;
			}

			//Clear the screen!
			system("CLS");
		}
		else {
			cout << "Invalid Operation or incomplete information." << endl;
			exitFlag = false;
		}

	}
}

#pragma region IsValidNumber
//Checks whether the inputed value is actually numeric or not
bool isValidNumber(string usrValue1, string usrValue2, char operType) {

	for (size_t i = 0; i < usrValue1.length(); i++)
	{
		if (!isdigit(usrValue1[i]) && usrValue1[i] != '.') {
			return false;
		}
	}

	for (size_t i = 0; i < usrValue2.length(); i++)
	{
		if (!isdigit(usrValue2[i]) && usrValue2[i] != '.') {
			return false;
		}
	}

	return true;
}
#pragma endregion

#pragma region Math Worker Function

//this is our worker function - it does the actual math and returns the value to the main method.
double doMath(string usrValue1, string usrValue2, char operType) {
	string outputVal = "";
	double dOut = 0;


	switch (operType)
	{
	case '1': //add
		dOut = stod(usrValue1) + stod(usrValue2);
		break;
	case '2': //subtract
		dOut = stod(usrValue1) - stod(usrValue2);
		break;
	case '3': //multiply
		dOut = stod(usrValue1) * stod(usrValue2);
		break;
	case '4': //divide
		dOut = stod(usrValue1) / stod(usrValue2);
		break;
	default:
		return 0;
		break;
	}

	return dOut;
}

#pragma endregion

#pragma region IsWhole

//this function checks to see if the number is a whole number or not
bool is_whole(double d) {
	return d == floor(d);
}
#pragma endregion

