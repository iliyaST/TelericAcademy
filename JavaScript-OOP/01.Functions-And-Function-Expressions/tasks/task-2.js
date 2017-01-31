/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve() {

    function isPrime(number) {

        for (let i = 2; i < number; i += 1) {
            if (number % i == 0) {
                return false;
            }
        }
        return true;
    }

    return function findPrimes(start, end) {

        if (start == null || end == null) {
            throw '';
        } else if (isNaN(start) || isNaN(end)) {
            throw '';
        } else {
            var array = [];

            for (let i = +start; i <= +end; i += 1) {
                if (i != 0 && i != 1) {
                    if (isPrime(i)) {
                        //console.log(i);
                        array.push(i);
                    }
                }
            }

            return array;
        }
    }
}

console.log(solve()(1, 5));
module.exports = solve;