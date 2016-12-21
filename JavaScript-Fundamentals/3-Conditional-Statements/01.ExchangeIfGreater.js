function solve(args) {

    var firstNumber = +args[0],
        secondNumber = +args[1];

    if (firstNumber > secondNumber) {
        console.log(secondNumber + ' ' + firstNumber)
    } else {
        console.log(firstNumber + ' ' + secondNumber)
    }
}