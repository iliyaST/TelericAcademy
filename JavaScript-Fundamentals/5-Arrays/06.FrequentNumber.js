function solve(args) {

    var arrayValues = [],
        arrayIndexes = [],
        counter = 0,
        i = 0,
        j = 0;
    len = args.length;
    temp = 0;

    for (i = 0; i < args.length; i += 1) {
        temp = args[i];
        arrayValues.push(temp);
        for (j = 0; j < args.length; j += 1) {
            if (temp == args[j]) {
                counter++;
                args.splice(j, 1);
                j = -1;
            }
        }
        arrayIndexes.push(counter);
        counter = 0;
        i = -1;
    }

    var max = Math.max();
    var maxValue = 0;

    for (i = 0; i <= arrayIndexes.length; i += 1) {
        if (max < arrayIndexes[i]) {
            max = arrayIndexes[i];
            maxValue = arrayValues[i];
        }
    }
    //4 (5 times)
    console.log(maxValue + ' (' + max + ' times)');
}
//solve(['4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3']);