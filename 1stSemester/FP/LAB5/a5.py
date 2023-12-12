import cmath

def create_dictionary(l1):
    list_real = []
    for i in range(len(l1)):
        r = get_real_from_index(l1, i)
        if int(r) == r:
            r = int(r)
        list_real.append(r)
    list_imag = []
    for i in range(len(l1)):
        im = get_img_from_index(l1, i)
        if int(im) == im:
            im = int(im)
        list_imag.append(im)
    dictionary = {"real part": list_real, "imaginary part": list_imag}
    return dictionary


def set_real_and_img(a, b):
    z = complex(a, b)
    return z

def get_real_from_index(l1, index):
    if index <len(l1):
        return (l1[index]).real
    return 0


def get_img_from_index(l1, index):
    if index <len(l1):
        return l1[index].imag
    return 0

def get_real(a, b):
    return (complex(a or 0, b or 0)).real


def get_img(a, b):
    return (complex(a or 0, b or 0)).imag


def modulus(a, b):
    from math import sqrt
    return sqrt(get_real(a, b) ** 2 + get_img(a, b) ** 2)

#{"real": 20, "imaginary": 15}, [20, 15]
def convert_to_string(x):
    converted_number = str(x)
    return converted_number


def display_list(l1):
    for i in range(len(l1)):
        l2 =[]
        r = get_img_from_index(l1, i)
        if r == int(r):
            r = int(r)
        if r != 0:
            l2.append(r)#= l2 + str(r)
        im = get_img_from_index(l1, i)
        if im == int(im):
            im = int(im)
        if im != 0:
            if l2 == []:
                if im == 1:
                    l2.append(("i"))
                elif im == -1:
                    l2.append(("-i"))
                else:
                    l2.append(im)
                    l2.append("i")
            elif im > 0:
                if im == 1:
                    l2.append("i")
                else:
                    l2.append(im)
                    l2.append(("i"))
            else:
                if im == -1:
                    l2.append(("-i"))
                else:
                    l2.append(im)
                    l2.append("-i")
        if l2 == []:
            l2 = [0]
    return l2


def property_one_list(l1):
    '''
    :param l1: the list of complex numbers
    :return: returns a new list that contains the longest subarray of numbers having increasing modulus and its lenght
    '''
    lmax = [l1[0]]
    l=1
    max_len = len(lmax)
    for i in range(1, len(l1)):
        if modulus(get_real_from_index(l1, i), get_img_from_index(l1, i)) > modulus(get_real_from_index(lmax, i - 1),get_img_from_index(lmax, i - 1)):
            lmax.append(l1[i])
            l=l+1
        else:
            lmax.clear()
            lmax = [l1[i]]
            l=1
        if l > max_len:
            max_len = l
    return max_len, lmax


def property_one_dict(dictionary):
    '''
        :param dictionary: the dictionary containing complex numbers
        :return: returns a new dictionary that contains the longest subarray of numbers having increasing modulus, as well as its lenght
        '''
    real = dictionary["real part"]
    imaginary = dictionary["imaginary part"]
    d_real = [0] * len(dictionary)
    d_im = [0] * len(dictionary)
    d_real[0] = real[0]
    d_im[0] = imaginary[0]
    max_len = 1
    l = 1
    if len(dictionary) > 1:
        for i in range(1, len(dictionary)):
            if modulus(dictionary["real part"][i], dictionary["imaginary part"][i]) > modulus(real[i - 1],imaginary[i - 1]):
                d_real.append(real[i])
                d_im.append(imaginary[i])
                l = l + 1
            else:
                d_real = real[i]
                d_im = imaginary[i]
                l = 1
            if l > max_len:
                max_len = l
    dict2 = {"real part": d_real, "imaginary part": d_im}
    return max_len, dict2

def property_two_list(l1):
    '''
    :param l1: the list of complex numbers
    :return: returns a new list that contains longest increasing subsequence, when considering each number's real part, as well as its lenght
    '''
    lis = [1] * len(l1)
    index = [0] * len(l1)
    max_len = 1
    max_pos = 0
    t = []
    for i in range(0, len(l1)):
        index[i] = i
    for i in range(1, len(l1)):
        for j in range(0, i):
            if get_real_from_index(l1, i) > get_real_from_index(l1, j) and lis[i] < lis[j] + 1:
                if lis[j] + 1 > max_len:
                    max_len = lis[i]
                    max_pos = i
                    for k in range(0, i + 1):
                        if index[k] == j:
                            index[k] = i
                lis[i] = lis[j] + 1

    for i in range(0, len(l1)):
        if index[i] == max_pos:
            t.append(int(get_real_from_index(l1, i)))
    for i in range(len(l1)):
        if max_len < lis[i]:
            max_len = lis[i]
    return max_len, t


def property_two_dict(dictionary):
    '''
        :param dictionary: the dictionary of complex numbers
        :return: returns a new dictionary that contains longest increasing subsequence, when considering each number's real part and its lenght
        '''
    new_list = list(dictionary.values())
    real_list = new_list[0]
    lis = [1] * len(real_list)
    index = [0] * len(real_list)
    max_len = 1
    max_pos = 0
    t = []
    for i in range(0, len(real_list)):
        index[i] = i
    for i in range(1, len(real_list)):
        for j in range(0, i):
            if get_real_from_index(real_list, i) > get_real_from_index(real_list, j) and lis[i] < lis[j] + 1:
                if lis[j] + 1 > max_len:
                    max_len = lis[i]
                    max_pos = i
                    for k in range(0, i + 1):
                        if index[k] == j:
                            index[k] = i
                lis[i] = lis[j] + 1

    for i in range(0, len(real_list)):
        if index[i] == max_pos:
            t.append(int(get_real_from_index(real_list, i)))
    for i in range(len(real_list)):
        if max_len < lis[i]:
            max_len = lis[i]
    return max_len, t

