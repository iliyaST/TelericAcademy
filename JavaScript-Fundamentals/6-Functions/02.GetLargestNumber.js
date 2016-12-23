function solve(args) {

    var array = args[0].split(' '),
        firstNumber = +array[0],
        secondNumber = +array[1],
        thirdNumber = +array[2];

    function getMax(firstNumber, secondNumber) {
        if (firstNumber > secondNumber) {
            return firstNumber;
        } else if (firstNumber < secondNumber) {
            return secondNumber;
        } else {
            return firstNumber;
        }
    }

    return (getMax(getMax(firstNumber, secondNumber), thirdNumber));
}



//solve('8 3 6');