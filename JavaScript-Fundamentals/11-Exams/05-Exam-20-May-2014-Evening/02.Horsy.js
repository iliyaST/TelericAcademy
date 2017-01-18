function solve(args) {

    let fieldCoordinates = args[0].split(' ').map(Number);
    let rows = fieldCoordinates[0],
        cols = fieldCoordinates[1];
    let field = [],
        curPosR = rows - 1,
        curPosC = cols - 1,
        matrix = [],
        weeds = 0,
        jumps = 0;

    //fill the matrix
    for (let row = 0; row < fieldCoordinates[0]; row += 1) {
        matrix[row] = [];
        let currentLine = args[row + 1];
        for (let col = 0; col < fieldCoordinates[1]; col += 1) {
            matrix[row].push(+currentLine[col]);
        }
    }

    //fill the matrix1
    for (let row = 0; row < fieldCoordinates[0]; row += 1) {
        field[row] = [];
        let curColValue = Math.pow(2, row);
        for (let col = 0; col < fieldCoordinates[1]; col += 1) {
            field[row].push(curColValue);
            curColValue -= 1;
        }
    }

    weeds = field[curPosR][curPosC];
    field[curPosR][curPosC] = 'x';
    //start with the moves
    while (true) {
        switch (matrix[curPosR][curPosC]) {

            case 8:
                curPosR -= 2;
                curPosC -= 1;
                jumps += 1;
                break;
            case 7:
                curPosR -= 1;
                curPosC -= 2;
                jumps += 1;
                break;
            case 6:
                curPosR += 1;
                curPosC -= 2;
                jumps += 1;
                break;
            case 5:
                curPosR += 2;
                curPosC -= 1;
                jumps += 1;
                break;
            case 4:
                curPosR += 2;
                curPosC += 1;
                jumps += 1;
                break;
            case 3:
                curPosR += 1;
                curPosC += 2;
                jumps += 1;
                break;
            case 2:
                curPosR -= 1;
                curPosC += 2;
                jumps += 1;
                break;
            case 1:
                curPosR -= 2;
                curPosC += 1;
                jumps += 1;
                break;
        }

        if (curPosC >= cols || curPosC < 0 || curPosR < 0 || curPosR >= rows) {
            console.log("Go go Horsy! Collected " + weeds + " weeds");
            break;
        } else if (field[curPosR][curPosC] == 'x') {
            console.log("Sadly the horse is doomed in " + jumps + " jumps");
            break;
        }

        weeds += field[curPosR][curPosC];
        field[curPosR][curPosC] = 'x';
    }
}

solve(
    [
        '3 5',
        '54361',
        '43326',
        '52188',
    ]
);