function solve(args) {
    var i,
        j,
        minNumber = Math.min(),
        n = args.length; // numbers.length


    for (i = 0; i < n - 1; i += 1) {
        for (j = i + 1; j < n; j += 1) {
            if (+args[i] > +args[j]) {
                minNumber = args[j];
                args[j] = args[i];
                args[i] = minNumber;
            }
        }
    }

    for (i = 0; i < args.length; i += 1) {
        var temp = args[i];
        for (j = i + 1; j < args.length; j += 1) {
            if (temp === args[j]) {
                args.splice(j, 1);
                j -= 1;
            }
        }
    }

    for (i = 0; i < args.length; i += 1) {
        console.log(args[i]);
    }
}

//solve(['6', '3', '4', '1', '5', '2', '6']);
//solve(['10', '36', '10', '1', '34', '28', '38', '31', '27', '30', '20', '10', '34', '34', '34']);