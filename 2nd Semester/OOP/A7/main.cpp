#include <stdlib.h>
#include <crtdbg.h>
#include <iostream>
#include <string>

#include "UI.h"
#include "AdministratorRepository.h"
#include "Service.h"


int main() {
    {
        AdministratorRepository adminRepo = AdministratorRepository{ "C:\\Users\\Ines\\Desktop\\OOP\\A7\\user_data2.txt"};
        UserRepository userRepo = UserRepository();
        Service service = Service{ adminRepo , userRepo };
        UI ui = UI{ service };
        service.load_data();
        ui.run_menu();
        service.save_data_to_file();
    }
    _CrtDumpMemoryLeaks();

    return 0;
}