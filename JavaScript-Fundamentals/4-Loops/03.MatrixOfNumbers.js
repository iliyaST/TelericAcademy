function solve(args) {

    var n = args;
    var currentLine = '';
    var counter = 1;
    var helpCounter = 1;

    for (var i = 1; i <= n * n; i++) {
        currentLine += counter + ' ';
        counter++;
        if (i % n == 0) {
            console.log(currentLine);
            currentLine = ' ';
            helpCounter++;
            counter = helpCounter;
        }
    }
}
//solve(['3']);