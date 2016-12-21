function solve(args) {

    var a = +args[0],
        b = +args[1],
        c = +args[2];
    disciminant = parseFloat(b * b - 4 * a * c);

    if (disciminant == 0) {
        root = -b / (2 * a);
        console.log('x1=x2=' + root.toFixed(2));
    } else if (disciminant < 0) {
        console.log('no real roots');
    } else {
        var firstRoot = (-b - Math.sqrt(disciminant)) / (2 * a);
        var secondROot = (-b + Math.sqrt(disciminant)) / (2 * a);

        console.log('x1=' + firstRoot.toFixed(2) + '; x2=' + secondROot.toFixed(2));
    }
}
//solve(['-0.5', '4', '-8']);
//solve(['-1', '3', '0']);