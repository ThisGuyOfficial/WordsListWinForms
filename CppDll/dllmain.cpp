// dllmain.cpp : Определяет точку входа для приложения DLL.
#include "pch.h"
#include "logger.h"
#define MyFunctions _declspec(dllexport)
#pragma warning(disable : 4996)

void logger::log(const std::string& msg)
{
	filestr << "[" + getTime() + "] " + msg << '\n';
}

std::string logger::getTime()
{
	auto now = std::chrono::system_clock::now();
	
	auto in_time_t = std::chrono::system_clock::to_time_t(now);

	//std::duration_cast<seconds>(end - start).count() << "\n"
	//	<< duration_cast<milliseconds>(end - start).count() << "\n"
	//	<< duration_cast<microseconds>(end - start).count() << "\n"
	//	<< duration_cast<nanoseconds>(end - start).count()

	std::stringstream ss;
	ss << std::put_time(localtime(&in_time_t), "%Y-%m-%d %H %M %S");
	return ss.str();
}

std::string logger::logFilePath()
{
	return getTime() + "_f.log";
}

struct Node
{
	int ct;
	std::string val;
	Node* next;
	Node(int count, std::string& value) : ct(count), val(value), next(nullptr) {}
};


class mainTask
{

	Node* head;
	Node* end;
	logger W;

	std::string allowedSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
	std::string line;
	std::vector<std::string> storedWords;
	std::vector<std::pair<int, std::string>>  result;
	std::string pathtowl = "WordsList.txt";

	int mode = 0;

public:

	mainTask() : head(nullptr), end(nullptr) {}
	bool empty() { return head == nullptr; }
	void push_back(int, std::string&);
	bool read();
	void setMode(int a) { mode = a; }
	int getMode() { return mode; }
	void createList();
	bool countMatches();
	bool save();
	bool changePath(std::string&);
	std::string& getPath() { return pathtowl; }
	//std::string getLogPath() { return W.logFilePath(); }
	~mainTask()
	{
		Node* current = head;
		while (current != nullptr)
		{
			Node* temp = current;
			current = current->next;
			delete temp;
		}
	}



};
void mainTask::push_back(int count, std::string& value)
{
	W.log("Called mainTask::push_back - adding new node to list with value " + value);
	Node* p = new Node(count, value);
	if (empty()) { head = p; end = p; return; }
	end->next = p;
	end = p;
}

bool mainTask::read()
{
	W.log("Called  mainTask::read()");
	std::ifstream in(pathtowl);
	int i = 0;
	std::string res;

	int count = 0;
	if (in.is_open()) {
		while (!in.eof())
		{

			line.clear();
			getline(in, line);
			if (!mode) std::transform(line.begin(), line.end(), line.begin(), [](unsigned char const& c) {return ::tolower(c); });

			size_t start{ line.find_first_of(allowedSymbols) };

			while (start != std::string::npos)
			{
				size_t end = line.find_first_not_of(allowedSymbols, start + 1);
				if (end == std::string::npos)
				{
					end = line.size();
				}
				if (!line.empty())
				{
					switch (getMode())
					{
					case 0:
					{
						count = 0;
						storedWords.push_back(line.substr(start, end - start));
						break;
					}
					case 1:
					{
						count = 0;
						if (isupper(static_cast<unsigned char>(line[start])))
							for (size_t i = start + 1; i < end; i++)
								if (islower(static_cast<unsigned char>(line[i])))
									count++;
						if (count && count == end - start - 1) storedWords.push_back(line.substr(start, end - start));
						break;
					}
					case 2:
					{
						count = 0;
						if (islower(static_cast<unsigned char>(line[start])))
							for (size_t i = start + 1; i < end; i++)
								if (isupper(static_cast<unsigned char>(line[i])))
									count++;
						if (count && count == end - start - 1) storedWords.push_back(line.substr(start, end - start));
						break;
					}
					case 3:
					{
						count = 0;
						for (size_t i = start; i < end; i++)
							if (isupper(static_cast<unsigned char>(line[i])))
								count++;
						if (count == end - start) storedWords.push_back(line.substr(start, end - start));
						break;
					}
					case 4:
					{
						count = 0;
						for (size_t i = start; i < end; i++)
							if (islower(static_cast<unsigned char>(line[i])))
								count++;
						if (count == end - start) storedWords.push_back(line.substr(start, end - start));
						break;
					}
					}
				}
				start = line.find_first_of(allowedSymbols, end + 1);
			}
		}
	}

	if (!in.eof() && in.fail())
	{
		W.log("mainTask::read() exit with error: cannot open ifstream to WordsList.txt");
		in.close();
		return false;
	}
	in.close();
	W.log("mainTask::read() data sucessfully readed from file and parsed");
	std::sort(storedWords.begin(), storedWords.end());
	return true;
}

void mainTask::createList()
{
	W.log("Called mainTask::createList");
	if (result.empty()) { W.log("mainTask::createList exit with error: cannot create list - load data from file first"); return; }
	for (std::pair<int, std::string>& a : result)
		push_back(a.first, a.second);
	std::sort(result.begin(), result.end());
		W.log("mainTask::createList list sucessfully created");
}

bool mainTask::countMatches()
{
	W.log("Called mainTask::countMatches");
	auto first_m = storedWords.begin();
	while (first_m != storedWords.end())
	{
		auto next_word_m = std::find_if_not(first_m, storedWords.end(), [&first_m](const auto& val)
			{
				return val == *first_m;
			}
		);
		std::string expectsString{ *first_m };
		W.log("mainTask::countMatches founded match at " + expectsString);
		result.push_back({ std::distance(first_m, next_word_m), expectsString });
		first_m = next_word_m;
	}
	W.log("mainTask::countMatches data processed sucessfylly");
	createList();
	return true;
}

bool mainTask::save()
{
	W.log("Called mainTask::save");
	if (result.empty()) { W.log("mainTask::save exit with error: no data to save"); return false; }
	std::ofstream out;
	out.open("ResultPairs.txt");
	if (out.is_open())
	{
		for (std::pair<int, std::string>& a : result)
			out << a.first << " " << a.second << '\n';
	}
	else { W.log("mainTask::save exit with error: cannot open oftream to ResultPairs.txt"); out.close(); return false; }
	W.log("mainTask::save all data sucessfully saved in file");
	out.close();
}

bool mainTask::changePath(std::string& val)
{
	if (val.empty()) return false;
	pathtowl = val + "\\WordsList.txt";
	return true;
}




extern "C"
{
	MyFunctions void* mainTaskCreate()
	{
		return (void*) new mainTask();
	}
	MyFunctions bool mainTaskRead(mainTask* A)
	{
		return A->read();
	}
	MyFunctions bool mainTaskCountMatches(mainTask* A)
	{
		return A->countMatches();
	}
	MyFunctions bool mainTaskSave(mainTask* A)
	{
		return A->save();
	}

}

//
//BOOL APIENTRY DllMain( HMODULE hModule,
//                       DWORD  ul_reason_for_call,
//                       LPVOID lpReserved
//                     )
//{
//    switch (ul_reason_for_call)
//    {
//    case DLL_PROCESS_ATTACH:
//    case DLL_THREAD_ATTACH:
//    case DLL_THREAD_DETACH:
//    case DLL_PROCESS_DETACH:
//        break;
//    }
//    return TRUE;
//}

