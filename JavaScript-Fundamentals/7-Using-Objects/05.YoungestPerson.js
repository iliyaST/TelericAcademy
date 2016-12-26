function solve(args) {

    var array = args,
        i = 0,
        len = array.length,
        min = Math.min(),
        minIndex = 0;

    for (i = 2; i < len; i += 3) {
        if (+array[i] < min) {
            min = +array[i];
            minIndex = i;
        }
    }

    console.log(array[minIndex - 2], array[minIndex - 1]);
}

// solve([
//     'Gosho', 'Petrov', '32',
//     'Bay', 'Ivan', '81',
//     'John', 'Doe', '42'
// ]);