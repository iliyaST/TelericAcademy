function solve(args) {

    var number = args;
    if (number < 0) {
        return false;
    }

    if (number > 100) {
        return false;
    }

    if (number == 1 || number == 0 || number === 3) {
        return false;
    }

    for (var i = 2; i < number; i++) {
        if (number % i == 0) {
            return false;
        }
    }

    return true;
}