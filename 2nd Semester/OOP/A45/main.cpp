#include <iostream>

#include "Movie.h"
#include <vector>
#include "AdministratorRepository.h"
#include "Service.h"
#include "UI.h"
#include "Tests.h"
#include <crtdbg.h>

int main()
{
	{
		Tests tests;
		tests.run_tests();

		AdministratorRepository adminRepo = AdministratorRepository();
		UserRepository userRepo = UserRepository();
		Service service = Service{ adminRepo , userRepo };
		UI ui = UI{ service };
		ui.start_menu();
	}
 
	_CrtDumpMemoryLeaks();
	return 0;
}