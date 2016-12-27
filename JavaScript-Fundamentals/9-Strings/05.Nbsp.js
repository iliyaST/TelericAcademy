function solve(args) {

    var text = args[0],
        i = 0,
        len = text.length,
        space = '&nbsp;',
        result = '';

    for (i = 0; i < len; i += 1) {
        if (text[i] === ' ') {
            result += space;
            continue;
        }
        result += text[i];
    }

    console.log(result);
}

solve(['This text contains 4 spaces!!']);