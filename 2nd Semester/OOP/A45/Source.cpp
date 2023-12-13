#include "DynamicArray.h"
#include "Repo.h"
#include "Service.h"
#include "UI.h"
#include "Tests.h"
#include "Movie.h"

#include <stdlib.h>
#define _CRTDBG_MAP_ALLOC
#include <crtdbg.h>

int main()
{
	auto* dynamic_array = new DynamicArray<Movie>(10);
	auto* repo = new Repo(dynamic_array);
	repo->initialise_repo();
	auto* service = new Service(repo);
	auto* ui = new UI(service);
	
	test_all();

	ui->administrator_menu();
	return 0;
}