function solve() {
    return function sum(numbers) {

        for (let i = 0; i < numbers.length; i += 1) {
            if (isNaN(numbers[i])) {
                throw '';
            }
        }

        if (numbers.length == 0) {
            return null;
        }
        return numbers.reduce(((prV, crV) => prV + +crV), 0);
    }
}

module.exports = solve;