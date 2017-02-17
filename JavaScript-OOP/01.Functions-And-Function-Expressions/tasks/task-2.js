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
module.exports = solve;