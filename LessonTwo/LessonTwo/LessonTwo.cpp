// LessonTwo.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
using namespace std;

int main()
{
    int age = 70;
    string name1 = "George";
    string name2 = "John";
    string sAge = to_string(age);

    cout << "There once was a man named " << name1 << "." << endl;
    cout << "He was " << sAge << " years old." << endl;
    cout << "He liked the name John." << endl;
    cout << "But he did not like being " << sAge << "." << endl;

}
