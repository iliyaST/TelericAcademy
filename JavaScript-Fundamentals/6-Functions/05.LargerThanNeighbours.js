function solve(args) {

    var sizeOfArray = args[0],
        array = args[1].split(' '),
        counter = 0;

    for (var i = 1; i < sizeOfArray - 1; i += 1) {
        if (+array[i] > +array[i - 1] && +array[i] > +array[i + 1]) {
            counter++;
        }
    }

    return counter;
}