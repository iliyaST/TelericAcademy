function solve(args) {

    let result = '';

    for (let i = 0; i < args.length; i += 1) {
        let currentLine = args[i];

        for (let j = 0; j < currentLine.length; j += 1) {

            if (currentLine[j] == ' ') {
                continue;
            }
            result += currentLine[j];
        }
    }

    //console.log(result);
    let result1 = '';
    // console.log('##########');
    // console.log('########');

    for (let i = 0; i < result.length; i += 1) {

        let symbol = result[i];

        if (result[i] == ';' && (result[i - 1] == '{' || result[i - 1] == '}' ||
                i == 0)) {
            i += 1;
            while (result[i] == ';') {
                i += 1;
            }

            i -= 1;
            continue;
        }

        if (result[i] == ';' && (result[i + 1] == '{' || result[i + 1] == '}')) {
            continue;
        } else if (result[i] == ';') {
            i += 1;
            while (result[i] == ';') {
                i += 1;
            }

            if (result[i] != '}') {
                result1 += ';';
            }

            i -= 1;
            continue;
        }
        result1 += result[i];
    }


    //console.log(result1);

    let result2 = '';

    for (let i = 0; i < result1.length; i += 1) {

        if (result1[i] == '{' && result1[i + 1] == '}') {
            i += 1;
            continue;
        }

        result2 += result1[i];
    }

    let last = '';

    if (result2[result1.length - 1] == ';') {
        for (let i = 0; i < result2.length - 1; i += 1) {
            last += result2[i];
        }
    } else {
        last = result2;
    }

    console.log(last.length);

    function isLetter(str) {
        return str.length === 1 && str.match(/[a-z]/i);
    }


}

solve(
    [
        '; ;;;jGefn4E5Pvq    ;;  ;  ; ;',
        'tQRZ5MMj26Ov { {    {;    ;;    5OVyKBFu7o1T2 ;szDVN2dWhex1V;1gDdNdANG2',
        ';    ;    ;  ;; jGefn4E5Pvq   ;;    ;p0OWoVFZ8c;;}    ;  ; ;',
        '5OVyKBFu7o1T2   ;  szDVN2dWhex1V ;    ;tQRZ5MMj26Ov    ;  ;   };',
        '1gDdNdANG2    ;   p0OWoVFZ8c ;  jGefn4E5Pvq ;; {;Z9n;;',
        ';1gDdNdANG2;   ;;    ;   ;jGefn4E5Pvq    ;; ;;p0OWoVFZ8c;;    ;;',
        ';',
        'tQRZ5MMj26Ov  ;',
        '{    ;szDVN2dWhex1V;   ;',
        ';   jGefn4E5Pvq   ;  ;  } }}'
    ]
);