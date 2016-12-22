function solve(args) {

    var max = Math.max(),
        min = Math.min(),
        sum = 0,
        avg = 0;

    for (var i = 0; i < args.length; i++) {
        if (max < +args[i]) {
            max = +args[i];
        }
        if (min > +args[i]) {
            min = +args[i];
        }
        sum += +args[i];
    }

    avg = sum / args.length;

    console.log('min=' + min.toFixed(2))
    console.log('max=' + max.toFixed(2))
    console.log('sum=' + sum.toFixed(2))
    console.log('avg=' + avg.toFixed(2))

}

//solve(['2', '-1', '4']);