function solve(args) {

    let coordinates = args[0].split(' ').map(Number),
        rows = coordinates[0],
        cols = coordinates[1],
        debrisCoordinates = args[1].split(/;|\s/).map(Number),
        field = [],
        curR = 0,
        curC = 0,
        curT = '';

    for (let row = 0; row < rows; row += 1) {
        field[row] = [];
        for (let col = 0; col < cols; col += 1) {
            field[row].push('');
        }
    }

    for (let i = 0; i < debrisCoordinates.length; i += 2) {
        field[debrisCoordinates[i]][debrisCoordinates[i + 1]] = 'x';
    }

    //tank current positions
    let tanks = {};
    tanks[0] = [0, 0, 't0'];
    tanks[1] = [0, 1, 't1'];
    tanks[2] = [0, 2, 't2'];
    tanks[3] = [0, 3, 't3'];
    tanks[4] = [rows - 1, cols - 1, 't4'];
    tanks[5] = [rows - 1, cols - 2, 't5'];
    tanks[6] = [rows - 1, cols - 3, 't6'];
    tanks[7] = [rows - 1, cols - 4, 't7'];

    //mark the tanks
    field[0][0] = 't0';
    field[0][1] = 't1';
    field[0][2] = 't2';
    field[0][3] = 't3';
    field[rows - 1][cols - 1] = 't4';
    field[rows - 1][cols - 2] = 't5';
    field[rows - 1][cols - 3] = 't6';
    field[rows - 1][cols - 4] = 't7';

    let tanksKoceto = 4,
        tanksCuky = 4;

    let n = args[2];

    //commands
    for (let i = 3; i < n + 3; i += 1) {
        let currentCommand = args[i].split(' ');

        if (currentCommand[0] == 'mv') {
            //move tank

            switch (currentCommand[3]) {

                case 'u':
                    curR = tanks[currentCommand[1]][0];
                    curC = tanks[currentCommand[1]][1];
                    curT = tanks[currentCommand[1]][2];

                    field[curR][curC] = '';

                    if (tanks[currentCommand[1]][0] - 1 >= 0) {
                        let moves = 0;
                        curR = tanks[currentCommand[1]][0];
                        curC = tanks[currentCommand[1]][1];

                        while (
                            tanks[currentCommand[1]][0] - 1 >= 0 &&
                            field[curR - 1][curC] != 'x' &&
                            field[curR - 1][curC] == '' &&
                            moves < +currentCommand[2]) {
                            tanks[currentCommand[1]][0] -= 1;
                            moves += 1;
                            curR = tanks[currentCommand[1]][0];
                            curC = tanks[currentCommand[1]][1];
                        }

                        curR = tanks[currentCommand[1]][0];
                        curC = tanks[currentCommand[1]][1];
                        field[curR][curC] = curT;
                    }
                    break;
                case 'd':

                    curR = tanks[currentCommand[1]][0];
                    curC = tanks[currentCommand[1]][1];
                    curT = tanks[currentCommand[1]][2];

                    field[curR][curC] = '';

                    if (tanks[currentCommand[1]][0] - 1 < rows) {
                        let moves = 0;
                        curR = tanks[currentCommand[1]][0];
                        curC = tanks[currentCommand[1]][1];
                        while (
                            tanks[currentCommand[1]][0] + 1 < rows &&
                            field[curR + 1][curC] != 'x' &&
                            field[curR + 1][curC] == '' &&
                            moves < +currentCommand[2]) {

                            tanks[currentCommand[1]][0] += 1;
                            curR = tanks[currentCommand[1]][0];
                            curC = tanks[currentCommand[1]][1];
                            moves += 1;
                        }
                        curR = tanks[currentCommand[1]][0];
                        curC = tanks[currentCommand[1]][1];
                        field[curR][curC] = curT;
                    }
                    break;
                case 'l':
                    curR = tanks[currentCommand[1]][0];
                    curC = tanks[currentCommand[1]][1];
                    curT = tanks[currentCommand[1]][2];

                    field[curR][curC] = '';

                    if (tanks[currentCommand[1]][1] - 1 >= 0) {
                        let moves = 0;
                        curR = tanks[currentCommand[1]][0];
                        curC = tanks[currentCommand[1]][1];
                        while (
                            tanks[currentCommand[1]][1] - 1 >= 0 &&
                            field[curR][curC - 1] != 'x' &&
                            field[curR][curC - 1] == '' &&
                            moves < +currentCommand[2]) {

                            tanks[currentCommand[1]][1] -= 1;
                            curR = tanks[currentCommand[1]][0];
                            curC = tanks[currentCommand[1]][1];
                            moves += 1;
                        }

                        curR = tanks[currentCommand[1]][0];
                        curC = tanks[currentCommand[1]][1];
                        field[curR][curC] = curT;
                    }
                    break;
                case 'r':
                    curR = tanks[currentCommand[1]][0];
                    curC = tanks[currentCommand[1]][1];
                    curT = tanks[currentCommand[1]][2];

                    field[curR][curC] = '';

                    if (tanks[currentCommand[1]][1] + 1 < cols) {
                        let moves = 0;
                        curR = tanks[currentCommand[1]][0];
                        curC = tanks[currentCommand[1]][1];
                        while (
                            tanks[currentCommand[1]][1] + 1 < cols &&
                            field[curR][curC + 1] != 'x' &&
                            field[curR][curC + 1] == '' &&
                            moves < +currentCommand[2]) {
                            tanks[currentCommand[1]][1] += 1;
                            curR = tanks[currentCommand[1]][0];
                            curC = tanks[currentCommand[1]][1];
                            moves += 1;
                        }
                        curR = tanks[currentCommand[1]][0];
                        curC = tanks[currentCommand[1]][1];
                        field[curR][curC] = curT;
                    }
                    break;
            }
        } else {
            //tank shoots

            switch (currentCommand[2]) {

                case 'u':
                    curR = tanks[currentCommand[1]][0];
                    curC = tanks[currentCommand[1]][1];

                    while (curR - 1 >= 0 && field[curR - 1][curC] == '') {
                        curR -= 1;
                    }

                    if (curR - 1 >= 0 && field[curR - 1][curC] == 'x') {
                        field[curR - 1][curC] = '';
                    } else if (curR - 1 < 0 || (field[curR - 1][curC] == undefined)) {

                    } else {

                        let tankName = field[curR - 1][curC][1];
                        if (+tankName >= 0 && tankName <= 3) {
                            tanksKoceto -= 1;
                        } else {
                            tanksCuky -= 1;
                        }
                        field[curR - 1][curC] = '';
                        console.log('Tank ' + tankName + ' is gg');
                    }

                    break;
                case 'd':
                    curR = tanks[currentCommand[1]][0];
                    curC = tanks[currentCommand[1]][1];

                    while (curR + 1 < rows && field[curR + 1][curC] == '') {
                        curR += 1;
                    }

                    if (curR + 1 < rows && field[curR + 1][curC] == 'x') {
                        field[curR + 1][curC] = '';
                    } else if (curR + 1 >= rows || (field[curR + 1][curC] == undefined)) {

                    } else {

                        let tankName = field[curR + 1][curC][1];
                        field[curR + 1][curC] = '';
                        if (+tankName >= 0 && +tankName <= 3) {
                            tanksKoceto -= 1;
                        } else {
                            tanksCuky -= 1;
                        }
                        console.log('Tank ' + tankName + ' is gg');
                    }
                    break;
                case 'l':
                    curR = tanks[currentCommand[1]][0];
                    curC = tanks[currentCommand[1]][1];

                    while (curC - 1 >= 0 && field[curR][curC - 1] == '') {
                        curC -= 1;
                    }

                    if (curC - 1 >= 0 && field[curR][curC - 1] == 'x') {
                        field[curR][curC - 1] = '';
                    } else if (curC - 1 < 0 || (field[curR][curC - 1] == undefined)) {

                    } else {

                        let tankName = field[curR][curC - 1][1];
                        field[curR][curC - 1] = '';
                        if (+tankName >= 0 && tankName <= 3) {
                            tanksKoceto -= 1;
                        } else {
                            tanksCuky -= 1;
                        }
                        console.log('Tank ' + tankName + ' is gg');
                    }
                    break;
                case 'r':
                    curR = tanks[currentCommand[1]][0];
                    curC = tanks[currentCommand[1]][1];

                    while (curC + 1 < cols && field[curR][curC + 1] == '') {
                        curC += 1;
                    }

                    if (curC + 1 < cols && field[curR][curC + 1] == 'x') {
                        field[curR][curC + 1] = '';
                    } else if (curC + 1 >= cols || (field[curR][curC + 1] == undefined)) {

                    } else {

                        let tankName = field[curR][curC + 1][1];
                        field[curR][curC + 1] = '';
                        if (+tankName >= 0 && tankName <= 3) {
                            tanksKoceto -= 1;
                        } else {
                            tanksCuky -= 1;
                        }
                        console.log('Tank ' + tankName + ' is gg');
                    }
                    break;
            }
        }

        if (tanksCuky == 0) {
            console.log('Cuki is gg');
            break;
        } else if (tanksKoceto == 0) {
            console.log('Koceto is gg');
            break;
        }
    }

}

solve(
    [
        '10 5',
        '1 0;1 1;1 2;1 3;1 4;3 1;3 3;4 0;4 2;4 4',
        '43',
        'mv 6 5 r',
        'mv 0 6 d',
        'x 0 d',
        'x 0 d',
        'x 6 u',
        'x 6 u',
        'x 6 u',
        'x 6 u',
        'x 6 u',
        'x 7 u',
        'x 7 u',
        'x 7 u',
        'x 7 u',
        'x 7 u',
        'x 3 d',
        'x 3 d',
        'x 3 d',
        'x 3 d',
        'x 3 d',
        'x 4 u',
        'x 4 u',
        'x 4 u',
        'x 4 u',
        'x 4 u',
        'x 0 r',
        'mv 0 6 d',
        'mv 0 9 r',
        'x 0 d',
        'mv 0 1 l',
        'x 0 d',
        'mv 0 1 l',
        'x 0 d',
        'mv 0 1 l',
        'x 0 d',
        'mv 0 1 l',
        'x 0 d',
        'mv 0 1 l',
        'x 0 d',
        'mv 0 1 l',
        'x 0 d',
        'mv 0 1 l',
        'x 0 d',
        'mv 0 1 l',
        'x 0 d'
    ]
);