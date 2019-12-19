#include "stdafx.h"
#include "ClassPhase2.h"
#include <iostream>
#include <fstream>


ClassPhase2::ClassPhase2(int Times):max_times(Times)
{
}

ClassPhase2::~ClassPhase2()
{
}

int ClassPhase2::Measurement1()
{
	for (int i = 0; i < 30; i++)
	{
		for (int i = 0; i < max_times; i++)
		{
			i++;
			++i;
			--i;
			i--;
		}
	}
	for (int i = 0; i < 30; i++)
	{
		for (int i = 0; i < max_times; i++)
		{
			i++;
			++i;
			--i;
			i--;
		}
	}
	int Girl = 1, Boy = 0;
	std::ofstream out("./BojayLogB1", std::ios::app);//app表示每次操作前均定位到文件末尾
	if (out.fail()) {
		std::cout << "error\n";
	}
	out << "Girl:" << Girl << std::endl;
	out << "Boy:" << Boy << std::endl;
	out.close();
	return 0;
}

int ClassPhase2::Measurement2()
{
	for (int i = 0; i < 30; i++)
	{
		for (int i = 0; i < max_times; i++)
		{
			i++;
			++i;
			--i;
			i--;
		}
	}
	for (int i = 0; i < 30; i++)
	{
		for (int i = 0; i < max_times; i++)
		{
			i++;
			++i;
			--i;
			i--;
		}
	}
	int Girl = 1, Boy = 0;
	std::ofstream out("./BojayLogB2", std::ios::app);//app表示每次操作前均定位到文件末尾
	if (out.fail()) {
		std::cout << "error\n";
	}
	out << "Girl:" << Girl << std::endl;
	out << "Boy:" << Boy << std::endl;
	out.close();
	return 0;
}

int ClassPhase2::Measurement3()
{
	for (int i = 0; i < 30; i++)
	{
		for (int i = 0; i < max_times; i++)
		{
			i++;
			++i;
			--i;
			i--;
		}
	}
	for (int i = 0; i < 30; i++)
	{
		for (int i = 0; i < max_times; i++)
		{
			i++;
			++i;
			--i;
			i--;
		}
	}
	int Girl = 1, Boy = 0;
	std::ofstream out("./BojayLogB3", std::ios::app);//app表示每次操作前均定位到文件末尾
	if (out.fail()) {
		std::cout << "error\n";
	}
	out << "Girl:" << Girl << std::endl;
	out << "Boy:" << Boy << std::endl;
	out.close();
	return 0;
}

int ClassPhase2::Measurement4()
{
	for (int i = 0; i < 30; i++)
	{
		for (int i = 0; i < max_times; i++)
		{
			i++;
			++i;
			--i;
			i--;
		}
	}
	for (int i = 0; i < 30; i++)
	{
		for (int i = 0; i < max_times; i++)
		{
			i++;
			++i;
			--i;
			i--;
		}
	}
	int Girl = 1, Boy = 0;
	std::ofstream out("./BojayLogB4", std::ios::app);//app表示每次操作前均定位到文件末尾
	if (out.fail()) {
		std::cout << "error\n";
	}
	out << "Girl:" << Girl << std::endl;
	out << "Boy:" << Boy << std::endl;
	out.close();
	return 0;
}

int ClassPhase2::Measurement5()
{
	for (int i = 0; i < 30; i++)
	{
		for (int i = 0; i < max_times; i++)
		{
			i++;
			++i;
			--i;
			i--;
		}
	}
	for (int i = 0; i < 30; i++)
	{
		for (int i = 0; i < max_times; i++)
		{
			i++;
			++i;
			--i;
			i--;
		}
	}
	int Girl = 1, Boy = 0;
	std::ofstream out("./BojayLogB5", std::ios::app);//app表示每次操作前均定位到文件末尾
	if (out.fail()) {
		std::cout << "error\n";
	}
	out << "Girl:" << Girl << std::endl;
	out << "Boy:" << Boy << std::endl;
	out.close();
	return 0;
}
