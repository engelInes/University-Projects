def custom_filter(iterable, ok):
    new_list=type(iterable)()
    for i in iterable:
        if ok(i):
            new_list.append(x)
    return new_list