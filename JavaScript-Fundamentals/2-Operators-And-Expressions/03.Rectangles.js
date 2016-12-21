function solve(args) {

    var width = args[0],
        heigth = args[1],
        area = width * heigth,
        parameter = 2 * width + 2 * heigth;

    console.log(area.toFixed(2) + ' ' + parameter.toFixed(2));
}