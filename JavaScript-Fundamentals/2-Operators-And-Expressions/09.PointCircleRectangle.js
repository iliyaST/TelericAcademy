function solve(args) {

    var x = args[0],
        y = args[1];

    if ((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) <= 1.5 * 1.5) {
        if ((x >= -1 && x <= 5) && (y >= -1 && y <= 1)) {
            console.log('inside circle inside rectangle');
        } else {
            console.log('inside circle outside rectangle');
        }

    } else {
        if ((x >= -1 && x <= 5) && (y >= -1 && y <= 1)) {
            console.log('outside circle inside rectangle');
        } else {
            console.log('outside circle outside rectangle');
        }
    }
}