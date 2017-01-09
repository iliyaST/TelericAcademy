function solve(params) {

    var nk = params[0].split(' ').map(Number),
        array = params[1].split(' ').map(Number),
        result = 0,
        len = nk[0],
        transformations = nk[1],
        i = 0,
        k = 0,
        transformedArray = [];

    //get min
    function getMin(firstNumber, secondNumber) {

        var min = 0;

        if (firstNumber >= secondNumber) {
            min = secondNumber;
        } else {
            min = firstNumber;
        }

        return min;
    }

    //get max
    function getMax(firstNumber, secondNumber) {

        var max = 0;

        if (firstNumber >= secondNumber) {
            max = firstNumber;
        } else {
            max = secondNumber;
        }

        return max;
    }

    //function for absolute difference
    function difference(firstNumber, secondNumber) {

        const diff = Math.abs(firstNumber - secondNumber);

        return diff;
    }

    function sumNumbers(firstNumber, secondNumber) {

        const sum = firstNumber + secondNumber;

        return sum;
    }

    while (k < transformations) {
        transformedArray = [];
        for (i = 0; i <= len; i += 1) {
            if (i === len) {
                array = transformedArray;
                break;
            }
            if (array[i] === 0) {
                if (i === 0) {
                    transformedArray[i] = difference(array[len - 1], array[i + 1]);
                } else if (i === len - 1) {
                    transformedArray[i] = difference(array[i - 1], array[0]);
                } else {
                    transformedArray[i] = difference(array[i - 1], array[i + 1]);
                }
            } else if (array[i] % 2 === 0) {
                if (i === 0) {
                    transformedArray[i] = getMax(array[len - 1], array[i + 1]);
                } else if (i === len - 1) {
                    transformedArray[i] = getMax(array[i - 1], array[0]);
                } else {
                    transformedArray[i] = getMax(array[i - 1], array[i + 1]);
                }
            } else if (array[i] === 1) {
                if (i === 0) {
                    transformedArray[i] = sumNumbers(array[len - 1], array[i + 1]);
                } else if (i === len - 1) {
                    transformedArray[i] = sumNumbers(array[i - 1], array[0]);
                } else {
                    transformedArray[i] = sumNumbers(array[i - 1], array[i + 1]);
                }
            } else if (array[i] % 2 !== 0) {
                if (i === 0) {
                    transformedArray[i] = getMin(array[len - 1], array[i + 1]);
                } else if (i === len - 1) {
                    transformedArray[i] = getMin(array[i - 1], array[0]);
                } else {
                    transformedArray[i] = getMin(array[i - 1], array[i + 1]);
                }
            }
        }
        k += 1;
    }
    //conditions
    /*
	each 1 - with the sum of its neighboring numbers
	all other odd numbers - with the minimum of its neighboring numbers
        */

    //caluclate result 
    if (k != 0) {
        for (i = 0; i < len; i += 1) {
            result += transformedArray[i];
        }
    } else {
        for (i = 0; i < len; i += 1) {
            result += array[i];
        }
    }

    console.log(result);
}
//solve(['10 3', '1 9 1 9 1 9 1 9 1 9']);
//solve(['5 1', '9 0 2 4 1']);
//solve(['65 0', '2 2 6 0 1 3 6 3 7 7 0 6 3 3 1 1 2 0 4 4 1 0 4 1 1 3 2 0 8 1 9 0 9 3 5 7 4 5 6 4 3 9 6 1 1 0 9 6 0 0 7 5 5 8 4 8 0 0 0 1 0 7 0 1 0']);