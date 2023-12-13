#include <stdlib.h>
#include "Country.h"
#include <stdio.h>

char* get_name(TElem* country)
{
	return country->name;
}

char* get_continent(TElem* country)
{
	return country->continent;
}

unsigned int get_population(TElem country)
{
	return country.population;
}

void set_country_name(TElem* country, char* new_name)
{
	strcpy(country->name, new_name);
}

void set_country_continent(TElem* country, char* new_continent)
{
	strcpy(country->continent, new_continent);
}

void set_country_population(TElem* country, unsigned int new_population)
{
	country->population = new_population;
}


