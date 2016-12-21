function solve(args) {

    var max = +args[0];

    for (var i = 1; i < 5; i += 1) {
        if (max < +args[i]) {
            max = +args[i];
        }
    }

    return max;
}