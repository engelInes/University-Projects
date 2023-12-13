#include <stdio.h>
#include <crtdbg.h>
#include "UI.h"
#include "Tests.h"

int main()
{
	test_all();
	run_menu();
	_CrtDumpMemoryLeaks();
	return 0;
}