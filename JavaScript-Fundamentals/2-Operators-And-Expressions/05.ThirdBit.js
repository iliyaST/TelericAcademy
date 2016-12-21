function solve(args) {

    var number = args;

    var mask = 1 << 3; //100
    var nAndMask = number & mask; //1111
    var bit = nAndMask >> 3; //& 100
    //  0100
    //  0001
    console.log(bit);
}