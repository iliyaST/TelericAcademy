function solve(args) {


    var sizeOfArray = +args[0],
        array = args[1].split(' '),
        numberX = +args[2],
        counter = 0,
        i = 0;

    for (i = 0; i < sizeOfArray; i += 1) {
        if (+array[i] === numberX) {
            counter += 1;
        }
    }

    console.log(counter);
}