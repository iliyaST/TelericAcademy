function solve(args) {
    let heights = args[0].split(' ').map(Number),
        peaks = [],
        pocketsSum = 0;

    for (let i = 1; i < heights.length - 1; i += 1) {
        if (heights[i] > heights[i - 1] && heights[i] > heights[i + 1]) {
            peaks.push(i);
        }
    }

    for (let i = 0; i < peaks.length; i += 1) {
        if (peaks[i] + 2 == peaks[i + 1]) {
            if (heights[peaks[i] + 1] != undefined) {
                pocketsSum += heights[peaks[i] + 1];
            }
        }
    }

    console.log(pocketsSum);
}

solve(
    [
        "53 20 1 30 2 40 3 3 10 1"
    ]
);