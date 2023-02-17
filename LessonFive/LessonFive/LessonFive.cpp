// LessonFive.cpp : Working with Numbers
//

//video playlist link https://youtube.com/playlist?list=PLLAZ4kZ9dFpOSzRXG05goZMgsvXwDDL6g
//lesson 9

#include <iostream>
using namespace std;

int main()
{
	//Whole numbers = ints
	//floats, doubles
	//unsigned numbers as well

	//math operations
	// Addition +
	// Subtraction -
	// Multiplication *
	// Division /
	// Modulus % - gets the remainder of dividing two numbers

	int numberA = 10;
	int numberB = 3;
	int numberC = 15;
	long total = 0;
	long totalMod = 0;
	total = (numberA + numberB) * numberC;
	totalMod = numberA % numberB;

	cout << "Sum: " << total << endl; //should be 13
	cout << "Mod result of A and B: " << totalMod++ << endl;
	return 0;
}

