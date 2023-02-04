#pragma once
#pragma once
#include <string>

#ifdef LOADING_EXPORTS
#define LOADING_API __declspec(dllexport)
#else
#define LOADING_API __declspec(dllimport)
#endif

extern "C" LOADING_API void Loading(char* str, int strlen);