function solve(args) {
    let heights = args[0].split(' ').map(Number),
        peaks = [],
        bestSum = 0,
        currentSum = 0;

    peaks.push(0);
    for (let i = 2; i <= heights.length - 3; i += 1) {
        if (heights[i] > heights[i + 1] && heights[i] > heights[i - 1]) {
            peaks.push(i);
        }
    }
    peaks.push(heights.length - 1);

    let index = 1;

    for (let i = 0; i < heights.length; i += 1) {
        if (i <= peaks[index]) {
            currentSum += heights[i];
        } else {
            if (currentSum > bestSum) {
                bestSum = currentSum;
                currentSum = 0;
                i -= 2;
            } else {
                currentSum = 0;
                i -= 2;
            }
            index += 1;
        }
    }

    if (currentSum > bestSum) {
        bestSum = currentSum;
    }

    console.log(bestSum);
}

solve(
    [
        "32 31 80 50 29 89 42 16 82 36 27 28 40 31 55 67 6 26 78 84 44 93 97 20 79 80 69 7 10 13 85 73 88 1 36 35 2 62 48 46 85 86"
    ]
);