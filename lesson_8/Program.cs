/* Быстрая сортировка O(log2(n)) 


array = [7, 4, 1, 3, 5, 2, 8, 6] = [] + [1] + [2] + [3] + [] + [4] + [] + [5] + [6] + [7] + [8]
pivot = 7

[4, 1, 3, 5, 2, 6] + [7] + [8]

array = [4, 1, 3, 5, 2, 6] = [] + [1] + [2] + [3] + [] + [4] + [] + [5] + [6]
pivot = 4
[1, 3, 2] + [4] + [5, 6]

array = [1, 3, 2] = [] + [1] + [2] + [3] + []
pivot = 1

[] + [1] + [3, 2]


array = [3, 2]
pivot = 3
[2] + [3] + []


array = [5, 6]
pivot = 5
[] + [5] + [6]
*/

// ф-ция concat - это спец ф-ция, которую мы будем прописывать непосредственно для объединения данных 

T[] Concat<T>(params T[][] arrays){ // {1, 2, 3} {4, 5} {6, 7}
    var result = new T[arrays.Sum(a => a.Length)]; // 7 элементов    // var потому что мы не знаем какой тип данных будет, поэтому будет любой т.е. var
    int offset = 0;
    foreach (T[] array in arrays){
        array.CopyTo(result, offset); // result = {1, 2, 3, 4, 5, 6, 7}
        offset += array.Length; // offset = 5
    }
    return result;
}

int[] quickSort(int[] array){
    if (array.Length < 2){
        return array;
    }
    else{
        int pivot = array[0];
        int count = 0;
        foreach (int element in array){
            if (element < pivot)
                count++;
        }
        int[] less = new int[count]; // элементы, которые меньше опорного
        int j = 0;
        for (int i = 0; i < array.Length; i++){
            if (array[i] < pivot){
                less[j] = array[i];
                j++;
            }
        }
        count = 0;
        foreach (int element in array){
            if (element > pivot){
                count++;
            }
        }
        int[] greater = new int[count]; // элементы, которые больше опорного 
        j = 0;
        for (int i = 0; i < array.Length; i++){
            if (array[i] > pivot){
                greater[j] = array[i];
                j++;
            }
        }
        count = 0;
        foreach (int element in array){ // считаем количество опорных элементов
            if (element == pivot){
                count++;
            }
        }
        int[] pivotArray = new int[count]; // элементы, равные опорному
        for (int i = 0; i < count; i++){
            pivotArray[i] = pivot;
        }
        int[] result = Concat(quickSort(less), pivotArray, quickSort(greater)); // объединение 
        return result;
    }
}


Console.Clear();
int[] array = {7, 4, 1, 3, 2, 5, 8, 6, 7, 7, 7};
Console.WriteLine($"Начальный массив: [{string.Join(", ", array)}]");
Console.WriteLine($"Отсортированный массив: [{string.Join(", ", quickSort(array))}]");