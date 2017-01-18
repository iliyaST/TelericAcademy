function solve(args) {
    let fieldCoordinates = args[0].split(' ').map(Number);
    let rows = fieldCoordinates[0],
        cols = fieldCoordinates[1];
    let field = [];

    for (let row = 0; row < fieldCoordinates[0]; row += 1) {
        field[row] = [];
        for (let col = 0; col < fieldCoordinates[1]; col += 1) {
            field[row].push('');
        }
    }

    let curCor = args[1].split(/;| /).map(Number);

    let curRw = curCor[0],
        curCw = curCor[1],
        curRn = curCor[2],
        curCn = curCor[3],
        curRl = curCor[4],
        curCl = curCor[5];

    //create object
    let model = {};
    model['Lsjtujzbo'] = [curRl, curCl];
    model['Wboup'] = [curRw, curCw];
    model['Nbslbub'] = [curRn, curCn];

    let trollWboupCaptured = false,
        trollNbslbubCaptured = false;

    for (let i = 2; i < args.length; i += 1) {
        let currentCommand = args[i].split(' ');
        if (currentCommand[0] == 'lay') {
            //lay trap on current location of the princess
            let curTR = model['Lsjtujzbo'][0],
                curTC = model['Lsjtujzbo'][1];

            field[curTR][curTC] = 't';
        } else if (currentCommand[0] == 'mv') {

            //check what move to make
            switch (currentCommand[2]) {

                case 'd':
                    if (model[currentCommand[1]][0] + 1 < rows) {
                        if (currentCommand[1] == 'Wboup' && trollWboupCaptured == true ||
                            currentCommand[1] == 'Nbslbub' && trollNbslbubCaptured == true) {
                            continue;
                        }
                        model[currentCommand[1]][0] += 1;
                    }
                    break;
                case 'u':
                    if (model[currentCommand[1]][0] - 1 >= 0) {
                        if (currentCommand[1] == 'Wboup' && trollWboupCaptured == true ||
                            currentCommand[1] == 'Nbslbub' && trollNbslbubCaptured == true) {
                            continue;
                        }
                        model[currentCommand[1]][0] -= 1;
                    }
                    break;
                case 'l':
                    if (model[currentCommand[1]][1] - 1 >= 0) {
                        if (currentCommand[1] == 'Wboup' && trollWboupCaptured == true ||
                            currentCommand[1] == 'Nbslbub' && trollNbslbubCaptured == true) {
                            continue;
                        }
                        model[currentCommand[1]][1] -= 1;
                    }
                    break;
                case 'r':
                    if (model[currentCommand[1]][1] + 1 < cols) {
                        if (currentCommand[1] == 'Wboup' && trollWboupCaptured == true ||
                            currentCommand[1] == 'Nbslbub' && trollNbslbubCaptured == true) {
                            continue;
                        }
                        model[currentCommand[1]][1] += 1;
                    }
                    break;
            }


            if ((model['Lsjtujzbo'][0] == model['Wboup'][0] &&
                    (model['Lsjtujzbo'][1] - 1 == model['Wboup'][1] ||
                        model['Lsjtujzbo'][1] == model['Wboup'][1] ||
                        model['Lsjtujzbo'][1] + 1 == model['Wboup'][1]
                    )) ||
                (model['Lsjtujzbo'][0] - 1 == model['Wboup'][0] &&
                    (model['Lsjtujzbo'][1] - 1 == model['Wboup'][1] ||
                        model['Lsjtujzbo'][1] == model['Wboup'][1] ||
                        model['Lsjtujzbo'][1] + 1 == model['Wboup'][1]
                    )) ||
                (model['Lsjtujzbo'][0] + 1 == model['Wboup'][0] &&
                    (model['Lsjtujzbo'][1] - 1 == model['Wboup'][1] ||
                        model['Lsjtujzbo'][1] == model['Wboup'][1] ||
                        model['Lsjtujzbo'][1] + 1 == model['Wboup'][1]
                    )) ||
                (model['Lsjtujzbo'][0] == model['Nbslbub'][0] &&
                    (model['Lsjtujzbo'][1] - 1 == model['Nbslbub'][1] ||
                        model['Lsjtujzbo'][1] == model['Nbslbub'][1] ||
                        model['Lsjtujzbo'][1] + 1 == model['Nbslbub'][1]
                    )) ||
                (model['Lsjtujzbo'][0] - 1 == model['Nbslbub'][0] &&
                    (model['Lsjtujzbo'][1] - 1 == model['Nbslbub'][1] ||
                        model['Lsjtujzbo'][1] == model['Nbslbub'][1] ||
                        model['Lsjtujzbo'][1] + 1 == model['Nbslbub'][1]
                    )) ||
                (model['Lsjtujzbo'][0] + 1 == model['Nbslbub'][0] &&
                    (model['Lsjtujzbo'][1] - 1 == model['Nbslbub'][1] ||
                        model['Lsjtujzbo'][1] == model['Nbslbub'][1] ||
                        model['Lsjtujzbo'][1] + 1 == model['Nbslbub'][1]
                    ))) {

                console.log('The trolls caught Lsjtujzbo at' +
                    ' ' + model['Lsjtujzbo'][0] + ' ' +
                    model['Lsjtujzbo'][1]);

                break;
            }

            if (trollWboupCaptured && trollNbslbubCaptured) {
                console.log('Lsjtujzbo is saved! ' +
                    model['Wboup'][0] + ' ' + model['Wboup'][1] + ' ' +
                    model['Nbslbub'][0] + ' ' + model['Nbslbub'][1]);
                break;
            }

            //free the trolls!!
            if (model['Wboup'][0] == model['Nbslbub'][0] &&
                model['Wboup'][1] == model['Nbslbub'][1]) {
                trollNbslbubCaptured = false;
                trollWboupCaptured = false;
            }

            //check if some troll is falled in a trap
            if (field[model['Wboup'][0]][model['Wboup'][1]] == 't') {
                trollWboupCaptured = true;
                field[model['Wboup'][0]][model['Wboup'][1]] = '';
            } else if (field[model['Nbslbub'][0]][model['Nbslbub'][1]] == 't') {
                trollNbslbubCaptured = true;
                field[model['Nbslbub'][0]][model['Nbslbub'][1]] = '';
            }
        }
        if (i == args.length - 1) {
            console.log('Lsjtujzbo is saved! ' +
                model['Wboup'][0] + ' ' + model['Wboup'][1] + ' ' +
                model['Nbslbub'][0] + ' ' + model['Nbslbub'][1]);
        }
    }
}

solve(
    [
        '7 7',
        '0 1;0 2;3 3',
        'mv Lsjtujzbo l',
        'lay trap',
        'mv Lsjtujzbo r',
        'lay trap',
        'mv Lsjtujzbo r',
        'lay trap',
        'mv Lsjtujzbo d',
        'mv Lsjtujzbo r',
        'mv Lsjtujzbo r',
        'mv Lsjtujzbo r',
        'mv Lsjtujzbo r',
        'mv Wboup d',
        'mv Wboup d',
        'mv Wboup l',
        'mv Wboup l',
        'mv Nbslbub r',
        'mv Nbslbub r',
        'mv Nbslbub r',
        'mv Nbslbub d',
        'mv Lsjtujzbo d',
        'mv Lsjtujzbo l',
        'mv Lsjtujzbo l',
        'mv Nbslbub l',
        'mv Nbslbub d',
        'mv Nbslbub d',
        'mv Wboup d',
        'mv Wboup d',
        'mv Wboup r',
        'mv Lsjtujzbo d',
        'mv Wboup d',
        'mv Wboup d',
        'mv Wboup r',
        'mv Lsjtujzbo r',
        'mv Lsjtujzbo r'
    ]
);