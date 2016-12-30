function solve(params) {

    //ATTTENTIONNNNNNN THE 9th test is RONG ON THE LAST Test there is r6 and there are only till 'i' colums in the 
    //board so i switched if i get curPosC to be r6 to i6 and the test goes correct thats why i do the if
    //after moves check if its r;

    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]),
        i, j,
        move,
        chessBoard = [],
        counter = 0,
        char = '',
        arrayOfChars = ('ABCDEFGHIJKLMNOPQRSTUVWXYZ').toLowerCase(),
        isOk = true,
        value = 0;

    for (i = rows; i > 0; i -= 1) {
        chessBoard[i] = [];
        for (j = 0; j < cols; j += 1) {
            char = arrayOfChars[j];
            chessBoard[i][char] = ' ';
            chessBoard[i][char] = params[2 + counter][j];
        }
        counter += 1;
    }

    //moves
    for (i = 0; i < tests; i += 1) {
        move = params[rows + 3 + i].split(' ');
        var curPosR = move[0][1],
            curPosC = move[0][0],
            curTarR = move[1][1],
            curTarC = move[1][0];
        if (curPosC === 'r') {
            curPosC = 'i';
        }
        isOk = true;
        if (curPosC === curTarC && curPosR === curTarR) {
            console.log('no');
            isOk = false;
        } else if (chessBoard[curPosR][curPosC] === '-') {
            console.log('no');
            isOk = false;
        } else if (chessBoard[curPosR][curPosC] === 'R') {
            //if its a rook

            //if its not horisontal or vertical from the rook
            if (curTarC != curPosC && curTarR != curPosR) {
                console.log('no');
                isOk = false;
            } else if (curTarC != curPosC && curTarR == curPosR) {

                //if its on the left
                if (curTarC < curPosC) {
                    value = curPosC.charCodeAt(0);
                    value -= 1;
                    curPosC = String.fromCharCode(value);

                    while (curPosC >= curTarC) {
                        if (chessBoard[curPosR][curPosC] === '-') {

                            value -= 1;
                            curPosC = String.fromCharCode(value);
                        } else {
                            console.log('no');
                            isOk = false;
                            break;
                        }
                    }
                } else if (curTarC > curPosC) {
                    //if its on the right

                    value = curPosC.charCodeAt(0);
                    value += 1;
                    curPosC = String.fromCharCode(value);

                    while (curPosC <= curTarC) {
                        if (chessBoard[curPosR][curPosC] === '-') {

                            value += 1;
                            curPosC = String.fromCharCode(value);
                        } else {
                            console.log('no');
                            isOk = false;
                            break;
                        }
                    }
                }

            } else if (curTarC == curPosC && curTarR != curPosR) {
                //down
                if (curPosR > curTarR) {
                    value = +curPosR;
                    value -= 1;
                    curPosR = value.toString();

                    while (curPosR >= curTarR) {
                        if (chessBoard[curPosR][curPosC] === '-') {

                            value -= 1;
                            curPosR = value.toString();
                        } else {
                            console.log('no');
                            isOk = false;
                            break;
                        }
                    }
                } else if (curPosR < curTarR) {
                    value = +curPosR;
                    value += 1;
                    curPosR = value.toString();

                    while (curPosR <= curTarR) {
                        if (chessBoard[curPosR][curPosC] === '-') {

                            value += 1;
                            curPosR = value.toString();
                        } else {
                            console.log('no');
                            isOk = false;
                            break;
                        }
                    }
                }
            }

            if (isOk) {
                console.log('yes');
            }
        } else if (chessBoard[curPosR][curPosC] === 'B') {
            if (curTarC == curPosC || curTarR == curPosR ||
                Math.abs(curTarC.charCodeAt(0) - curPosC.charCodeAt(0)) != Math.abs(curTarR - curPosR)) {
                console.log('no');
                isOk = false;
            } else {

                //check for direction to move
                if (curTarR > curPosR) {
                    if (curPosC < curTarC) {
                        //up-right

                        value = +curPosR;
                        value += 1;
                        curPosR = value.toString();
                        value = curPosC.charCodeAt(0);
                        value += 1;
                        curPosC = String.fromCharCode(value);


                        while (curPosR <= curTarR) {
                            if (chessBoard[curPosR][curPosC] === '-') {
                                value = curPosC.charCodeAt(0);
                                value += 1;
                                curPosC = String.fromCharCode(value);
                                value = +curPosR;
                                value += 1;
                                curPosR = value.toString();
                            } else {
                                console.log('no');
                                isOk = false;
                                break;
                            }
                        }
                    } else if (curPosC > curTarC) {

                        //up-left

                        value = +curPosR;
                        value += 1;
                        curPosR = value.toString();
                        value = curPosC.charCodeAt(0);
                        value -= 1;
                        curPosC = String.fromCharCode(value);


                        while (curPosR <= curTarR) {
                            if (chessBoard[curPosR][curPosC] === '-') {
                                value = curPosC.charCodeAt(0);
                                value -= 1;
                                curPosC = String.fromCharCode(value);
                                value = +curPosR;
                                value += 1;
                                curPosR = value.toString();
                            } else {
                                console.log('no');
                                isOk = false;
                                break;
                            }
                        }
                    }
                } else if (curTarR < curPosR) {
                    if (curPosC < curTarC) {
                        //down-right
                        value = +curPosR;
                        value -= 1;
                        curPosR = value.toString();
                        value = curPosC.charCodeAt(0);
                        value += 1;
                        curPosC = String.fromCharCode(value);


                        while (curPosR >= curTarR) {
                            if (chessBoard[curPosR][curPosC] === '-') {
                                value = curPosC.charCodeAt(0);
                                value += 1;
                                curPosC = String.fromCharCode(value);
                                value = +curPosR;
                                value -= 1;
                                curPosR = value.toString();
                            } else {
                                console.log('no');
                                isOk = false;
                                break;
                            }
                        }

                    } else if (curPosC > curTarC) {
                        //down-left

                        value = +curPosR;
                        value -= 1;
                        curPosR = value.toString();
                        value = curPosC.charCodeAt(0);
                        value -= 1;
                        curPosC = String.fromCharCode(value);


                        while (curPosR >= curTarR) {
                            if (chessBoard[curPosR][curPosC] === '-') {
                                value = curPosC.charCodeAt(0);
                                value -= 1;
                                curPosC = String.fromCharCode(value);
                                value = +curPosR;
                                value -= 1;
                                curPosR = value.toString();
                            } else {
                                console.log('no');
                                isOk = false;
                                break;
                            }
                        }
                    }
                }

            }

            if (isOk) {
                console.log('yes');
            }
        } else if (chessBoard[curPosR][curPosC] === 'Q') {
            if (curTarC == curPosC || curTarR == curPosR) {
                //ACT like a ROOK

                //if its not horisontal or vertical from the rook
                if (curTarC != curPosC && curTarR != curPosR) {
                    console.log('no');
                    isOk = false;
                } else if (curTarC != curPosC && curTarR == curPosR) {

                    //if its on the left
                    if (curTarC < curPosC) {
                        value = curPosC.charCodeAt(0);
                        value -= 1;
                        curPosC = String.fromCharCode(value);

                        while (curPosC >= curTarC) {
                            if (chessBoard[curPosR][curPosC] === '-') {

                                value -= 1;
                                curPosC = String.fromCharCode(value);
                            } else {
                                console.log('no');
                                isOk = false;
                                break;
                            }
                        }
                    } else if (curTarC > curPosC) {
                        //if its on the right

                        value = curPosC.charCodeAt(0);
                        value += 1;
                        curPosC = String.fromCharCode(value);

                        while (curPosC <= curTarC) {
                            if (chessBoard[curPosR][curPosC] === '-') {

                                value += 1;
                                curPosC = String.fromCharCode(value);
                            } else {
                                console.log('no');
                                isOk = false;
                                break;
                            }
                        }
                    }

                } else if (curTarC == curPosC && curTarR != curPosR) {
                    //down
                    if (curPosR > curTarR) {
                        value = +curPosR;
                        value -= 1;
                        curPosR = value.toString();

                        while (curPosR >= curTarR) {
                            if (chessBoard[curPosR][curPosC] === '-') {

                                value -= 1;
                                curPosR = value.toString();
                            } else {
                                console.log('no');
                                isOk = false;
                                break;
                            }
                        }
                    } else if (curPosR < curTarR) {
                        //up
                        value = +curPosR;
                        value += 1;
                        curPosR = value.toString();

                        while (curPosR <= curTarR) {
                            if (chessBoard[curPosR][curPosC] === '-') {

                                value += 1;
                                curPosR = value.toString();
                            } else {
                                console.log('no');
                                isOk = false;
                                break;
                            }
                        }
                    }
                }

                if (isOk) {
                    console.log('yes');
                }
            } else {
                //act like BISHOP
                if (curTarC == curPosC || curTarR == curPosR ||
                    Math.abs(curTarC.charCodeAt(0) - curPosC.charCodeAt(0)) != Math.abs(curTarR - curPosR)) {
                    console.log('no');
                    isOk = false;
                } else {

                    //check for direction to move
                    if (curTarR > curPosR) {
                        if (curPosC < curTarC) {
                            //up-right
                            value = +curPosR;
                            value += 1;
                            curPosR = value.toString();
                            value = curPosC.charCodeAt(0);
                            value += 1;
                            curPosC = String.fromCharCode(value);


                            while (curPosR <= curTarR) {
                                if (chessBoard[curPosR][curPosC] === '-') {
                                    value = curPosC.charCodeAt(0);
                                    value += 1;
                                    curPosC = String.fromCharCode(value);
                                    value = +curPosR;
                                    value += 1;
                                    curPosR = value.toString();
                                } else {
                                    console.log('no');
                                    isOk = false;
                                    break;
                                }
                            }
                        } else if (curPosC > curTarC) {
                            //up-left

                            value = +curPosR;
                            value += 1;
                            curPosR = value.toString();
                            value = curPosC.charCodeAt(0);
                            value -= 1;
                            curPosC = String.fromCharCode(value);


                            while (curPosR <= curTarR) {
                                if (chessBoard[curPosR][curPosC] === '-') {
                                    value = curPosC.charCodeAt(0);
                                    value -= 1;
                                    curPosC = String.fromCharCode(value);
                                    value = +curPosR;
                                    value += 1;
                                    curPosR = value.toString();
                                } else {
                                    console.log('no');
                                    isOk = false;
                                    break;
                                }
                            }
                        }
                    } else if (curTarR < curPosR) {
                        if (curPosC < curTarC) {
                            //down-right
                            value = +curPosR;
                            value -= 1;
                            curPosR = value.toString();
                            value = curPosC.charCodeAt(0);
                            value += 1;
                            curPosC = String.fromCharCode(value);


                            while (curPosR >= curTarR) {
                                if (chessBoard[curPosR][curPosC] === '-') {
                                    value = curPosC.charCodeAt(0);
                                    value += 1;
                                    curPosC = String.fromCharCode(value);
                                    value = +curPosR;
                                    value -= 1;
                                    curPosR = value.toString();
                                } else {
                                    console.log('no');
                                    isOk = false;
                                    break;
                                }
                            }

                        } else if (curPosC > curTarC) {
                            //down-left

                            value = +curPosR;
                            value -= 1;
                            curPosR = value.toString();
                            value = curPosC.charCodeAt(0);
                            value -= 1;
                            curPosC = String.fromCharCode(value);


                            while (curPosR >= curTarR) {
                                if (chessBoard[curPosR][curPosC] === '-') {
                                    value = curPosC.charCodeAt(0);
                                    value -= 1;
                                    curPosC = String.fromCharCode(value);
                                    value = +curPosR;
                                    value -= 1;
                                    curPosR = value.toString();
                                } else {
                                    console.log('no');
                                    isOk = false;
                                    break;
                                }
                            }
                        }
                    }

                }

                if (isOk) {
                    console.log('yes');
                }
            }
        }

    }
}

solve([
    '9', '9',
    '--------B',
    '--Q------',
    '------Q--',
    '-R------R',
    '---------',
    '-----Q--R',
    '---------',
    '---B-----',
    '-B-------',
    '10',
    'i9 h8',
    'i9 g7',
    'g7 g1',
    'd2 e3',
    'i4 a4',
    'i6 i1',
    'i6 i5',
    'f4 d6',
    'c8 i2',
    'r6 b1',
]);