#pragma once
#include "Service.h"

class UI
{
private:
	Service* service_array;
public:
	UI(Service* service_array);

	void add_ui();
	void delete_ui();
	void update_ui();
	void print_all();
	void print_administrator_options();
	void administrator_menu();
	~UI();
};
