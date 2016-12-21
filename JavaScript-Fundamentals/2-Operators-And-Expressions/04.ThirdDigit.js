function solve(args) {
    var number = args;
    var thirdDigit = parseInt((number / 100) % 10);

    if (thirdDigit == 7) {
        console.log('true');
    } else {
        console.log('false ' + thirdDigit);
    }
}