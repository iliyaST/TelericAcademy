function solve(args) {

    let fieldCoordinates = args[0].split(' ').map(Number);
    let rows = fieldCoordinates[0],
        cols = fieldCoordinates[1];
    let field = [];

    for (let row = 0; row < rows; row += 1) {
        field[row] = [];
        let currentLine = args[row + 1].split(' ').map(Number);
        for (let col = 0; col < cols; col += 1) {
            field[row].push(currentLine[col]);
        }
    }

    //current coordinates
    let curR = rows / 2 | 0,
        curC = cols / 2 | 0;


    //move
    //up-right-down-left
    let p = 0;

    while (true) {

        let direction = DesideDirection(field[curR][curC]);

        if (direction == 'false') {
            console.log('No JavaScript, only rakiya ' + curR + ' ' + curC);
            break;
        } else if (direction == 'win') {
            console.log('No rakiya, only JavaScript ' + curR + ' ' + curC);
            break;
        } else if (direction == 'up') {
            field[curR][curC] = 'x';
            curR -= 1;
            if (curR < 0) {
                console.log('No rakiya, only JavaScript ' + curR + 1 + ' ' + curC);
                break;
            }
        } else if (direction == 'right') {
            field[curR][curC] = 'x';
            curC += 1;
            if (curC >= cols) {
                console.log('No rakiya, only JavaScript ' + curR + ' ' + curC - 1);
                break;
            }
        } else if (direction == 'down') {
            field[curR][curC] = 'x';
            curR += 1;
            if (curR >= rows) {
                console.log('No rakiya, only JavaScript ' + curR - 1 + ' ' + curC);
                break;
            }
        } else if (direction == 'left') {
            field[curR][curC] = 'x';
            curC -= 1;
            if (curR < 0) {
                console.log('No rakiya, only JavaScript ' + curR + ' ' + curC + 1);
                break;
            }
        }
    }

    function DesideDirection(number) {

        let p = 0;
        let mask = 1 << p;
        let nAndMask = number & mask;
        let bit = nAndMask >> p;

        if (bit == 1 && curR - 1 >= 0 && field[curR - 1][curC] != 'x') {
            return "up";
        } else if (bit == 1 && curR - 1 < 0) {
            return 'win'
        }

        p = 1;
        mask = 1 << p;
        nAndMask = number & mask;
        bit = nAndMask >> p;

        if (bit == 1 && curC + 1 < cols && field[curR][curC + 1] != 'x') {
            return "right";
        } else if (bit == 1 && curC + 1 >= cols) {
            return 'win';
        }

        p = 2;
        mask = 1 << p;
        nAndMask = number & mask;
        bit = nAndMask >> p;

        if (bit == 1 && curR + 1 < rows && field[curR + 1][curC] != 'x') {
            return "down";
        } else if (bit == 1 && curR + 1 >= rows) {
            return 'win';
        }

        p = 3;
        mask = 1 << p;
        nAndMask = number & mask;
        bit = nAndMask >> p;

        if (bit == 1 && curC - 1 < cols && field[curR][curC - 1] != 'x') {
            return "left";
        } else if (bit == 1 && curC - 1 < 0) {
            return 'win';
        }

        return "false";
    }
}

solve(
    [
        '7 5',
        '9 3 11 9 3',
        '10 12 4 6 10',
        '12 3 13 1 6',
        '9 6 11 12 3',
        '10 9 6 13 6',
        '10 12 5 5 3',
        '12 5 5 5 6'
    ]
);