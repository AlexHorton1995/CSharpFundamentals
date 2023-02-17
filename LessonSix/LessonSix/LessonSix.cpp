// LessonSix.cpp : Getting user input
//

#include <iostream>
using namespace std;
using std::cout;
using std::cin;
using std::endl;
using std::string;

//forward function declarations
bool checkNumber(std::string s);


int main()
{
    string age = "0";

    cout << "Enter your age: ";
    cin >> age;

    if (checkNumber(age)) {
        cout << "You are " << age << " years old!" << endl;
    }
    else {
        cout << "You did not enter a numeric value!" << endl;
    }

    return 0;
}

//Function declaration
bool checkNumber(std::string s) {

    for (size_t i = 0; i < s.length(); i++)
    {
        if (!isdigit(s[i])) {
            return false;
        }
    }

    return true;
}


