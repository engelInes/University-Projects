#pragma once

typedef struct
{
	char name[50];
	char continent[50];
	unsigned int population;
} Country;

typedef Country TElem;

char* get_name(TElem* country);

char* get_continent(TElem* country);

unsigned int get_population(TElem country);

void set_country_name(TElem* country, char* new_name);
void set_country_continent(TElem* country, char* new_continent);
void set_country_population(TElem* country, unsigned int new_population);

