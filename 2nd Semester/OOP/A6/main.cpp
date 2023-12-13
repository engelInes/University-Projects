#include <stdlib.h>
#include <crtdbg.h>
#include <iostream>
#include <string>

#include "UI.h"
#include "Test.h"
#include "AdministratorRepository.h"
#include "Service.h"


int main() {
    
    Test test;
    test.run_tests();
    {
        AdministratorRepository adminRepo = AdministratorRepository();
        UserRepository userRepo = UserRepository();
        Service service = Service{ adminRepo , userRepo };
        UI ui = UI{ service };
        ui.run_menu();
    }
    _CrtDumpMemoryLeaks();

    return 0;
}