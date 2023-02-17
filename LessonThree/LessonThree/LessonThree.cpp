// LessonThree.cpp : C++ datatypes.
//

#include <iostream>
using namespace std;

int main()
{

	char myChar = 'A';
	string myStr = "Bunch of different characters";
	int signedInt = 0;
	float myFloat = 1.1;
	double myDouble = 10.5;
	make_unsigned<int>::type unSignInt = 0; //can only use positive numbers
	make_unsigned<long>::type unSignLong = 0; //can only use positive numbers

	cout << "doing something different here" << endl; 
	cout << "Break the code" << endl;
}
