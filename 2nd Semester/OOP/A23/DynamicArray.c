#include <stdlib.h>
#include "DynamicArray.h"

dynamic_array* create_dynamic_array(int capacity)
{
	dynamic_array* new_dynamic_array = malloc(sizeof(dynamic_array));
	if (new_dynamic_array == NULL)
		return NULL;
	new_dynamic_array->capacity = capacity;
	new_dynamic_array->size = 0;
	new_dynamic_array->elements = malloc(capacity * sizeof(TElem));
	if (new_dynamic_array->elements == NULL)
		return NULL;
	return new_dynamic_array;
}

void add_element_to_dynamic_array(dynamic_array* array, TElem element)
{
	if (array->size == array->capacity)
		resize_dynamic_array(array);
	array->elements[array->size] = element;
	array->size++;
}

void destroy_dynamic_array(dynamic_array* array)
{
	if (array == NULL)
		return;
	free(array->elements);
	free(array);
}

void resize_dynamic_array(dynamic_array* array)
{
	if (array == NULL)
		return;
	int array_capacity = array->capacity * 2;
	array->capacity = array->capacity * 2;
	TElem* auxiliary_array = realloc(array->elements, array_capacity * sizeof(TElem));
	if (auxiliary_array == NULL)
		return;
	array->capacity = array_capacity;
	array->elements = auxiliary_array;
}

int get_dynamic_array_size(dynamic_array* array)
{
	return array->size;
}

int get_dynamic_array_capacity(dynamic_array* array)
{
	return array->capacity;
}

operation_dynamic_array* create_operation_dynamic_array(int capacity)
{
	operation_dynamic_array* new_dynamic_array = malloc(sizeof(operation_dynamic_array));
	if (new_dynamic_array == NULL)
		return NULL;
	new_dynamic_array->capacity = capacity;
	new_dynamic_array->size = 0;
	new_dynamic_array->elements = malloc(capacity * sizeof(Operation));
	if (new_dynamic_array->elements == NULL)
		return NULL;
	return new_dynamic_array;
}

void add_element_to_operation_dynamic_array(operation_dynamic_array* array, Operation element)
{
	if (array->size == array->capacity)
		resize_operation_dynamic_array(array);
	array->elements[array->size] = element;
	array->size++;
}

void destroy_operation_dynamic_array(operation_dynamic_array* array)
{
	if (array == NULL)
		return;
	free(array->elements);
	free(array);
}

void resize_operation_dynamic_array(operation_dynamic_array* array)
{
	if (array == NULL)
		return;
	int array_capacity = array->capacity * 2;
	array->capacity = array->capacity * 2;
	void** auxiliary_array = realloc(array->elements, array_capacity * sizeof(Operation));
	if (auxiliary_array == NULL)
		return;
	array->capacity = array_capacity;
	array->elements = auxiliary_array;
}

int get_operation_dynamic_array_size(operation_dynamic_array* array)
{
	return array->size;
}

int get_operation_dynamic_array_capacity(operation_dynamic_array* array)
{
	return array->capacity;
}