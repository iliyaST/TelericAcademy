function solve(args) {

    var substring = args[0].toLowerCase(),
        counter = 0,
        index = 0,
        text = args[1].toLowerCase();

    while (true) {

        index = text.indexOf(substring, index);

        if (index >= 0) {
            index += substring.length;
            counter += 1;
        } else {
            break;
        }
    }

    console.log(counter);
}

solve([
    'in',
    'We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'
]);