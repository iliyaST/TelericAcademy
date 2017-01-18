function solve(args) {

    let currentResult = 0,
        index = 0,
        n = args[0];


    currentResult = +args[1];

    if (+args[1] % 2 == 0) {
        index = 3;
    } else {
        index = 2;
    }

    for (let i = index; i < args.length; i += 1) {

        if (+args[i] % 2 == 0) {

            currentResult += +args[i];
            i += 1;
            currentResult %= 1024;
        } else {
            currentResult *= +args[i];
            currentResult %= 1024;

        }
    }

    console.log(currentResult);
}

solve(
    [
        '10',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9',
        '0'
    ]
);