function solve(args) {

    var len = +args;
    array = [];

    for (var i = 0; i < len; i += 1) {
        array.push(i * 5);
    }

    for (var i = 0; i < len; i += 1) {
        console.log(array[i]);
    }

}
//solve(20);