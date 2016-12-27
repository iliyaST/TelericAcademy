function solve(args) {

    var expression = args[0],
        index = 0,
        counter = 0,
        counterClose = 0;

    while (true) {
        index = expression.indexOf('(', index);

        if (index >= 0) {
            index += 1;
            counter += 1;
        } else {
            break;
        }
    }

    index = 0;

    while (true) {
        index = expression.indexOf(')', index);

        if (index >= 0) {
            index += 1;
            counterClose += 1;
        } else {
            break;
        }
    }

    if (counter === counterClose) {
        console.log('Correct');
    } else {
        console.log('Incorrect');
    }
}
solve(['((a+b)/5-d)']);