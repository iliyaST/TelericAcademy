function solve(args) {


    var firstSide = parseFloat(args[0]),
        secondSide = parseFloat(args[1]),
        heigth = parseFloat(args[2]);
    area = firstSide + secondSide;

    area /= 2;

    area *= heigth;

    console.log(area.toFixed(7));
}