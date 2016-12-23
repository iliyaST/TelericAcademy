function solve(args) {
    var i,
        j,
        n = +args,
        primes = new Array(n + 1),
        lengthPrimes = primes.length;

    for (i = 0; i < lengthPrimes; i += 1) {
        primes[i] = true; // array of boolean
    }

    // Find all prime numbers in the range [1...n]
    for (i = 2; i < Math.sqrt(lengthPrimes); i += 1) {
        // Skip those numbers that are not prime
        if (primes[i]) {
            for (j = i * i; j < lengthPrimes; j += i) {
                primes[j] = false;
            }
        }
    }

    for (i = lengthPrimes - 1; i >= 2; i -= 1) {
        if (primes[i]) {
            console.log(i);
            break;
        }
    }
}