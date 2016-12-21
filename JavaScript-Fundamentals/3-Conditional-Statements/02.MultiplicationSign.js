function solve(args) {
    if (args[0] * args[1] * args[2] > 0) {
        console.log('+');
    } else if (args[0] * args[1] * args[2] == 0) {
        console.log(0);
    } else {
        console.log('-');
    }
}