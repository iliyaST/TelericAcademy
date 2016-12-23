function solve(args) {

    var len = args.length;
    counter = 1;
    maxSequince = 0;

    for (var i = 0; i < len - 1; i += 1) {
        if (+args[i] < +args[i + 1]) {
            counter++;
        } else {
            if (maxSequince < counter) {
                maxSequince = counter;
            }
            counter = 1;
        }
    }
    if (maxSequince < counter) {
        maxSequince = counter;
    }
    return maxSequince;
}
//solve(['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '1']);