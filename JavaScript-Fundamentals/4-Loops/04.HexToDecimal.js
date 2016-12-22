function solve(args) {

    var number = args[0];
    var result = 0;
    var pow = number.length - 1;

    for (var i = 0; i < number.length; i++) {
        var digit = 0;

        switch (number[i]) {
            case '0':
                ditgit = 0;
                break;
            case '1':
                ditgit = 1;
                break;
            case '2':
                ditgit = 2;
                break;
            case '3':
                ditgit = 3;
                break;
            case '4':
                ditgit = 4;
                break;
            case '5':
                ditgit = 5;
                break;
            case '6':
                ditgit = 6;
                break;
            case '7':
                ditgit = 7;
                break;
            case '8':
                ditgit = 8;
                break;
            case '9':
                ditgit = 9;
                break;
            case 'A':
                ditgit = 10;
                break;
            case 'B':
                ditgit = 11;
                break;
            case 'C':
                ditgit = 12;
                break;
            case 'D':
                ditgit = 13;
                break;
            case 'E':
                ditgit = 14;
                break;
            case 'F':
                ditgit = 15;
                break;
        }

        result += ditgit * Math.pow(16, pow);
        pow--;
    }

    return result;
}
//solve(['FE']);