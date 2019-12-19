// TestProcessDemo.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "ClassPhase1.h"
#include "ClassPhase2.h"

extern "C" __declspec(dllexport) void BojayEntryFunction()
{
	// this is phase1
	ClassPhase1 A(9000000);
	A.Measurement1();
	A.Measurement2();
	A.Measurement3();
	A.Measurement4();
	A.Measurement5();

	// this is phase2
	ClassPhase2 B(9000000);
	B.Measurement1();
	B.Measurement2();
	B.Measurement3();
	B.Measurement4();
	B.Measurement5();

	// this is phase3
	/*********************


	请在这里写下你的测试项


	**********************/
}
