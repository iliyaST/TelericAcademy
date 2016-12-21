function solve(args) {

    for (var i = 0; i < 2; i += 1) {
        for (var j = i + 1; j < 3; j += 1) {
            if (+args[i] < +args[j]) {
                var temp = +args[i];
                args[i] = args[j];
                args[j] = temp;
            }
        }
    }

    var temp = '';
    for (var i = 0; i < 3; i += 1) {
        temp += args[i] + ' ';
    }
    console.log(temp);
}