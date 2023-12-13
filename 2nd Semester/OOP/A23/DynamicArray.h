#pragma once
#include "Country.h"

typedef Country TElem;

typedef struct
{
	TElem* elements;
	int size;
	int capacity;
}dynamic_array;

dynamic_array* create_dynamic_array(int capacity);
void add_element_to_dynamic_array(dynamic_array* array, TElem element);
void destroy_dynamic_array(dynamic_array* array);
void resize_dynamic_array(dynamic_array* array);
int get_dynamic_array_size(dynamic_array* array);
int get_dynamic_array_capacity(dynamic_array* array);

typedef struct
{
	Operation* elements;
	int size;
	int capacity;
}operation_dynamic_array;

operation_dynamic_array* create_operation_dynamic_array(int capacity);
void add_element_to_operation_dynamic_array(operation_dynamic_array* array, Operation element);
void destroy_operation_dynamic_array(operation_dynamic_array* array);
void resize_operation_dynamic_array(operation_dynamic_array* array);
int get_operation_dynamic_array_size(operation_dynamic_array* array);
int get_operation_dynamic_array_capacity(operation_dynamic_array* array);

