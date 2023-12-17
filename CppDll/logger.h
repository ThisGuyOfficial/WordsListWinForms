#pragma once
#include <iostream>
#include <fstream>
#include <ostream>
#include <string>
#include <chrono>
#include <sstream>
#include <algorithm>
#include <filesystem>
#include <format>
#include <iomanip>
#include <stdio.h>
#include <direct.h>
#include <time.h>
#include <Windows.h>
#pragma warning(disable : 4996)

class logger
{
	std::ofstream filestr;
	const std::string path = logFilePath();
	std::string savedPath;

public:
	std::string getTime();
	void log(const std::string&);
	std::string logFilePath();
	std::string sp() { return savedPath; }

	logger()
	{
		char cCurrentPath[FILENAME_MAX];
		_getcwd(cCurrentPath, sizeof(cCurrentPath));
		cCurrentPath[sizeof(cCurrentPath) - 1] = '\0';
		std::string way = cCurrentPath;
		_mkdir("logs");
		way += "\\logs\\" + path;

		filestr.open(way, std::ios::out);
		if (!filestr.good()) { return; }
		savedPath = way;
		log("Session started");
	}
	~logger()
	{
		log("Session ended");
		filestr.close();
	};
};

