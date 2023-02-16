// LessonFour.cpp : string functions
//

#include <iostream>
using namespace std;

int main()
{
	int wordIndx = 0;
	string somePhrase = "How much wood would a woodchuck chuck if a woodchuck would chuck wood?";
	wordIndx = somePhrase.find("woodchuck");
	string firstWord = somePhrase.substr(wordIndx, 9);
	cout << somePhrase.find("woodchuck", 0) << endl;
	cout << firstWord << endl;

}
