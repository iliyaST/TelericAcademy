function solve(args) {

    var x = args[0],
        y = args[1];

    var distance = Math.sqrt((x - 0) * (x - 0) + (y - 0) * (y - 0));

    if ((((x - 0) * (x - 0)) + ((y - 0) * (y - 0))) <= 2 * 2) {
        console.log('yes ' + distance.toFixed(2));
    } else {
        console.log('no ' + distance.toFixed(2));
    }
}