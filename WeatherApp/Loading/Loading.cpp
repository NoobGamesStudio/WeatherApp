#include "pch.h"
#include "Loading.h"
#include <iostream>
#include <algorithm>

void Loading(char* str, int strlen)
{
	std::string result = "Please wait...";

	result = result.substr(0, strlen);

	std::copy(result.begin(), result.end(), str);
	str[(std::min)(strlen - 1, (int)result.size())] = 0;
}