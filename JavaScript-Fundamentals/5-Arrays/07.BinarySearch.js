function solve(args) {

    var middle = -1,
        n = +args[0],
        array = [],
        searchedNumber = args[args.length - 1],
        startSearch = 0,
        endSearch = args.length - 1,
        check = false;

    for (var index = 1; index <= n; index++) {
        array.push(args[index]);
    }

    while (startSearch <= endSearch) {
        middle = parseInt((startSearch + endSearch) / 2);
        if (array[middle] == searchedNumber) {
            console.log(middle);
            check = true;
            break;
        } else if (+array[middle] < +searchedNumber) {
            startSearch = middle + 1;
        } else if (+array[middle] > +searchedNumber) {
            endSearch = middle - 1;
        }
    }
    if(check===false){
        console.log(-1);
    }
}

//solve(['10', '-99943', '-99930', '-99832', '-97774', '-96990', '-96744', '-96689', '-96381', '-96325', '-96150', '-99943', '1']);