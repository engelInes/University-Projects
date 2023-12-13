#include <string.h>
#include <assert.h>
#include <stdlib.h>
#include "Tests.h"
#include "Country.h"
#include "Service.h"

void test_domain()
{
	Country country1;
	strcpy_s(country1.name, sizeof(country1.name), "Romania");
	strcpy_s(country1.continent, sizeof(country1.continent), "Europe");
	country1.population = 19345758;
	assert(strcmp(country1.name, "Romania") == 0);
	assert(strcmp(country1.continent, "Europe") == 0);
	assert(country1.population == 19345758);

	assert(strcmp(get_name(&country1), "Romania") == 0);
	assert(strcmp(get_continent(&country1), "Europe") == 0);
	assert(get_population(country1) == 19345758);

	set_country_name(&country1, "Poland");
	assert(strcmp(country1.name, "Poland") == 0);

	set_country_continent(&country1, "Asia");
	assert(strcmp(country1.continent, "Asia") == 0);

	set_country_population(&country1, 4572115);
	assert(country1.population== 4572115);

}
void test_add_country()
{
	Country country;
	dynamic_array* repo = create_dynamic_array(2);
	add_country_to_service(repo, "Austria", "Europe", 287429101);
	assert(strcmp(repo->elements[repo->size-1].name, "Austria") == 0);
	assert(strcmp(repo->elements[repo->size-1].continent, "Europe") == 0);
	assert(repo->elements[repo->size-1].population == 287429101);
}

void test_delete_country()
{
	Country country;
	dynamic_array* repo = create_dynamic_array(2);
	add_country_to_service(repo, "Austria", "Europe", 287429101);
	add_country_to_service(repo, "Romania", "Europe", 8573727);
	delete_country_from_service(repo, "Romania", "Europe");
	assert(strcmp(repo->elements[repo->size - 1].name, "Romania") != 0);
	assert(strcmp(repo->elements[repo->size - 1].continent, "Romania") != 0);
	assert(repo->elements[repo->size - 1].population != 8573727);
}

void test_update_country_by_name()
{
	Country country;
	dynamic_array* repo = create_dynamic_array(2);
	add_country_to_service(repo, "Germany", "Europe", 287429101);
	update_country_by_name_to_service(repo, "Germany", "Europe", "Romania");
	assert(strcmp(repo->elements[repo->size - 1].name, "Romania") == 0);
}

void test_update_country_by_continent()
{
	Country country;
	dynamic_array* repo = create_dynamic_array(2);
	add_country_to_service(repo, "Germany", "Europe", 287429101);
	update_country_by_continent_to_service(repo, "Germany", "Europe", "Asia");
	assert(strcmp(repo->elements[repo->size - 1].continent, "Asia") == 0);
}

void test_update_country_by_population()
{
	Country country;
	dynamic_array* repo = create_dynamic_array(2);
	add_country_to_service(repo, "Germany", "Europe", 287429101);
	update_country_by_population_to_service(repo, "Germany", "Europe", 287429101, 111111);
	assert(repo->elements[repo->size - 1].population == 111111);
}

void test_update_migration()
{
	Country country;
	dynamic_array* repo = create_dynamic_array(2);
	add_country_to_service(repo, "Germany", "Europe", 287429101);
	add_country_to_service(repo, "Romania", "Europe", 8573727);
	update_migration_to_service(repo, 0, 1, 1000);
	assert(repo->elements[0].population != 287429101);
	assert(repo->elements[1].population != 8573727);
}

void test_all()
{
	test_domain();
	test_add_country();
	test_delete_country();
	test_update_country_by_name();
	test_update_country_by_continent();
	test_update_country_by_population();
	test_update_migration();
}