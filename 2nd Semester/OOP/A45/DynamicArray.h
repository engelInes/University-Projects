#pragma once
#include "Movie.h"

template <typename TElem>
class DynamicArray
{
private:
	TElem* elements;
	int capacity;
	int size;

	void resize_dynamic_array();

public:
	DynamicArray(int capacity=10);
	DynamicArray(const DynamicArray& v);
	void add_element(TElem element);
	void delete_element(int index_of_deleted_element);
	void update_element(int index_of_updated_element, TElem element);

	TElem* get_element();
	int get_capacity() const;
	int get_size() const;

	~DynamicArray();
};

template <typename TElem>
DynamicArray<TElem>::DynamicArray(int capacity)
{
	if (capacity <= 0)
		throw "The capacity of the array must be at least 1";
	this->capacity = capacity;
	this->size = 0;
	this->elements = new TElem[capacity];
}

template <typename TElem>
void DynamicArray<TElem>::add_element(TElem element)
{
	if (this->capacity == this->size)
		this->resize_dynamic_array();
	this->elements[this->size] = element;
	this->size++;
}

template <typename TElem>
void DynamicArray<TElem>::resize_dynamic_array()
{
	auto* new_elements_array = new TElem[this->capacity * 2];
	for (int i = 0; i < this->size; i++)
	{
		new_elements_array[i] = this->elements[i];
	}
	delete[] this->elements;
	this->elements = new_elements_array;
	this->capacity = this->capacity * 2;

}

template <typename TElem>
void DynamicArray<TElem>::delete_element(int index_of_deleted_element)
{
	for (int i = index_of_deleted_element; i < this->size - 1; i++)
	{
		this->elements[i] = this->elements[i + 1];
	}
	this->size--;
}

template <typename TElem>
void DynamicArray<TElem>::update_element(int index_of_updated_element, TElem updated_element)
{
	this->elements[index_of_updated_element] = updated_element;
}

template <typename TElem>
TElem* DynamicArray<TElem>::get_element()
{
	return this->elements;
}

template <typename TElem>
int DynamicArray<TElem>::get_capacity() const
{
	return this->capacity;
}

template <typename TElem>
int DynamicArray<TElem>::get_size() const
{
	return this->size;
}

template <typename TElem>
DynamicArray<TElem>::~DynamicArray()
{
	delete[] this->elements;
}