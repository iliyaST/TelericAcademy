function solve(args) {

    let initialVariable = 0,
        arrayOfTitles = [],
        i = 0,
        j = 0,
        len = args.length,
        propArray = [],
        arrayOfArrays = [],
        someCounter = 1,
        someIndex = 0,
        start = 0,
        startA = 0,
        resultArray = [];

    //logic for values @
    let logicIndexA = 0,
        logicArrayValuesA = [],
        logicCounterA = 0;

    //values
    while (logicIndexA < len) {

        let currentLine = args[logicIndexA].trim();

        if (currentLine.indexOf('@') > -1) {
            logicIndexA += 1;
            while (args[logicIndexA].trim() != '</>') {
                currentLine = args[logicIndexA].trim();
                if (currentLine.indexOf('=') > -1) {
                    let iI = currentLine.indexOf('=');

                    for (let f = iI; f < currentLine.length; f += 1) {
                        if (currentLine[f] <= '9' && currentLine[f] >= '0') {
                            let number = '';
                            while (true) {
                                if (isNaN(currentLine[f])) {
                                    logicArrayValuesA.push(+number);
                                    break;
                                }
                                number += currentLine[f];
                                f += 1;
                            }
                        }
                    }
                }
                logicIndexA += 1;
            }

        }
        logicIndexA += 1;

    }


    //check if char is letter function just in case :)
    function isLetter(str) {
        return str.length === 1 && str.match(/[a-z]/i);
    }

    while (i < args.length) {
        let currentLine = args[i].trim();
        let indexOfI = i + 1;
        //if @
        if (currentLine.indexOf('<@') > -1) {

            let currentTitle = '';
            for (j = 2; j < currentLine.length; j += 1) {
                if (currentLine[j] === '>') {
                    break;
                }
                currentTitle += currentLine[j];
            }

            arrayOfTitles.push(currentTitle);

            while (args[indexOfI].trim() !== '</>') {
                let currentLineProperty = args[indexOfI].trim();
                let cLine = '';

                if (currentLineProperty.indexOf('=') > -1) {
                    for (let t = 0; t <= currentLineProperty.length; t += 1) {
                        if (currentLineProperty[t] === '=' || currentLineProperty[t] === ' ') {
                            break;
                        }

                        cLine += currentLineProperty[t];
                    }
                    cLine += ' = ';

                    let gIndex = currentLineProperty.indexOf('=');
                    let gNumber = '';

                    for (let w = gIndex; w < currentLineProperty.length; w += 1) {
                        if (currentLineProperty[w] <= '9' && currentLineProperty[w] >= '0') {
                            gNumber = '';

                            while ((currentLineProperty[w] <= '9' && currentLineProperty[w] >= '0')) {
                                gNumber += currentLineProperty[w];
                                w += 1;
                            }
                        }
                    }

                    cLine += gNumber;

                    cLine += ' :: ' + currentTitle + ';';
                } else {
                    for (let t = 0; t <= currentLineProperty.length; t += 1) {
                        if (currentLineProperty[t] === ';' || currentLineProperty[t] === ' ') {
                            break;
                        }

                        cLine += currentLineProperty[t];
                    }

                    cLine += ' = ';

                    logicArrayValuesA.sort();

                    for (let g = 0; g < logicArrayValuesA.length; g += 1) {
                        if (startA === logicArrayValuesA[g]) {
                            startA += 1;
                        }
                    }

                    cLine += startA + ' :: ' + currentTitle + ';';
                    startA += 1;
                }

                propArray.push(cLine);
                resultArray.push(cLine);

                indexOfI += 1;
            }
            i = indexOfI + 1;

        } else if ((currentLine.indexOf('<') > -1) && (currentLine[1] != '/')) {
            let currentTitle = '';
            let indexOfI = i + 1;
            let copyStart = 0;

            for (j = 1; j < currentLine.length; j += 1) {
                if (currentLine[j] === '>') {
                    break;
                }

                currentTitle += currentLine[j];
            }

            arrayOfTitles.push(currentTitle);

            //loggic for values
            let logicIndex = indexOfI,
                logicArrayValues = [],
                logicCounter = 0;

            //values
            while (args[logicIndex].trim() != '</>') {
                let currentLine = args[logicIndex].trim();

                if (currentLine.indexOf('=') > -1) {
                    let iI = currentLine.indexOf('=');

                    for (let f = iI; f < currentLine.length; f += 1) {
                        if (currentLine[f] <= '9' && currentLine[f] >= '0') {
                            let number = '';
                            while (true) {
                                if (!(currentLine[f] <= '9' && currentLine[f] >= '0')) {
                                    logicArrayValues.push(+number);
                                    break;
                                }
                                number += currentLine[f];
                                f += 1;
                            }
                        }
                    }
                }

                logicIndex += 1;
            }

            while (args[indexOfI].trim() !== '</>') {
                let currentLineProperty = args[indexOfI].trim();
                let cLine = '';

                if (currentLineProperty.indexOf('=') > -1) {
                    for (let t = 0; t <= currentLineProperty.length; t += 1) {
                        if (currentLineProperty[t] === ';' || currentLineProperty[t] === ' ') {
                            break;
                        }

                        cLine += currentLineProperty[t];
                    }

                    cLine += ' = ';

                    let gIndex = currentLineProperty.indexOf('=');
                    let gNumber = '';

                    for (let w = gIndex; w < currentLineProperty.length; w += 1) {
                        if (currentLineProperty[w] <= '9' && currentLineProperty[w] >= '0') {
                            gNumber = '';

                            while ((currentLineProperty[w] <= '9' && currentLineProperty[w] >= '0')) {
                                gNumber += currentLineProperty[w];
                                w += 1;
                            }
                        }
                    }

                    cLine += gNumber;

                    cLine += ' :: ' + currentTitle + ';';
                } else {
                    for (let t = 0; t <= currentLineProperty.length; t += 1) {
                        if (currentLineProperty[t] === ';' || currentLineProperty[t] === ' ') {
                            break;
                        }

                        cLine += currentLineProperty[t];
                    }

                    cLine += ' = ';

                    //logic for smallest values

                    logicArrayValues.sort();

                    for (let g = 0; g < logicArrayValues.length; g += 1) {
                        if (copyStart === logicArrayValues[g]) {
                            copyStart += 1;
                        }
                    }

                    cLine += copyStart + ' :: ' + currentTitle + ';';
                    copyStart += 1;
                }

                propArray.push(cLine);
                resultArray.push(cLine);

                indexOfI += 1;
            }
            i = indexOfI + 1;
        }

        arrayOfArrays.push(propArray);
        propArray = [];

    }

    resultArray.sort();

    for (i = 0; i < resultArray.length; i += 1) {
        console.log(resultArray[i]);
    }
}

solve(
    [
        '<@applicate>     ',
        '     deceitfulness=  186    ;   ',
        '      jstoepbavCAnd  =    15    ;  ',
        'faith=  88 ; ',
        '   strangeness  ;',
        '     sevjeovr0itsies     ;      ',
        '     kingly   =      275   ;     ',
        '     eavesdroppers   =95      ;     ',
        '      indturBitiHolns     =  105  ;      ',
        '     c59DuprHtly ;',
        '      hneVPaSzy;  ',
        '   pitVizclae9ss   ;      ',
        '  tbPolW9shIevism= 234     ;     ',
        ' minimizers   ;   ',
        '  rjersea7rHchzer     ;      ',
        '     conveyer    ;  ',
        '      UsacMcrAif8ices  =   85;     ',
        'cEoAIntenti5uons   ; ',
        ' mZuHosCliMm     =      131    ;  ',
        '  f7IBVjob      ;  ',
        '  gjHFrya2phite  =    34    ;   ',
        '  wo6Nrkhaborzse  =     38     ;     ',
        '</>  ',
        '  <@paired>',
        '  bunkmate ;',
        ' comprise    ;  ',
        ' spirit  ; ',
        '   slothful =174;   ',
        '  iTrofnXiucahlly  ;    ',
        '   grasps   ;',
        '     skyscraper   =    154     ;     ',
        '   </>   ',
        '  <@rogues> ',
        ' berlioz =     4    ; ',
        ' tell  =   317  ;   ',
        ' asls1cendcers4;      ',
        '     AliqUyuiIdatmion =320  ;  ',
        '    hyokLhadJes     ;',
        '   dabbing ;   ',
        '      </>',
        ' <scXrYatchnpdad7s>  ',
        'xanCeilinvey     =   34     ;   ',
        ' gNWraEDnulatYe;    ',
        '    efkunn40eling7    =    213     ;     ',
        '      mzil4itYeiamMen   ;  ',
        '     </>     ',
        '    <chivalrousness>     ',
        ' pillsbury  ;     ',
        '  ceerYtviZficatlion =    236 ;     ',
        'g5raRyIynQess   ;    ',
        '    </>  ',
        '    <lurking>     ',
        'homes      ; ',
        'padrI7Bt1er   ;   ',
        '      ch32UhecMkout=   291   ;  ',
        '   evades     =     151     ;      ',
        '     c8GKow0aurd     =     237    ; ',
        '  fIunPehIraGls  =    129      ;',
        ' guZABttxeured    =   215   ;     ',
        '     respite ;  ',
        '    paDa1tr3icixan  = 314;   ',
        ' reality;    ',
        '     caNllvaJ4hanA     ;',
        '  OchecLksDvc = 81  ;     ',
        '   busy =    183   ;   ',
        '   loJwU0erqinNg    ; ',
        '  shCIgewFaths   ;  ',
        '   ubncomfortabx1ElRy    ;    ',
        '0exemc2pl9ifyijng  =    11     ;',
        'mineral      =270;   ',
        '    laoqt8U2ian7 =92  ;    ',
        '   tutorial     ;  ',
        '  sudan    =   307      ;',
        '  5outf8lmOived      =   88 ;      ',
        '      </>      ',
        ' <schemes>',
        '   death666    ;     ',
        '    bigdog1 ; ',
        '     W1cawGstiWllo      ;   ',
        '  cFhyiNmKeZric    ; ',
        '     Akhea13sley     ;      ',
        '    readout      =      37 ; ',
        'writers     ;  ',
        'julie  ;      ',
        '  hamn79dful3sQ=      316   ;    ',
        '     astronomy   ; ',
        '     prjactickbaaMbly =  288      ;      ',
        '      daisies   ;  ',
        '   5cMf7oolingG   =    122      ;',
        '     m1hhiVe   = 206;',
        ' OfunecountQaboly    ;',
        '  h9andc9uVfiifing   =  217;      ',
        '   leaflet   ;    ',
        '   ZVsicx9Cakv      =  291;      ',
        '   UdesulbiTtHory    =  204  ;      ',
        '   aspAle2LnifVum    ;     ',
        '  jumble  ; ',
        '    harrowing =     90      ; ',
        '   uniforms=    202     ;  ',
        '   fch3roCniWqcled    ;      ',
        '      rdlFefuKorm    ; ',
        '      cTosndkuct6t      ;    ',
        '      </>  ',
        '   <wqYe6aOnders>  ',
        '  monotonicity      =  307 ;   ',
        '     iTnKvtvKoke      ;',
        '      Haffaliicdtio7ns  ;      ',
        ' yncjoNUl     =      170  ;',
        '      pertained=     324   ;      ',
        '      KjpinchinQOWg    ;      ',
        '      bladderwort=      175    ;  ',
        '  haughtily    =   261     ;   ',
        '      ini2Wtiali35zJation   ;      ',
        ' </>    ',
        '    <@MludewEtect>      ',
        '   demTECAi2tted      = 329 ;  ',
        '  uwrl7c=224    ;',
        '     wOagiuB6ls;',
        ' porEtr84ayljs=     46   ; ',
        'unjdejrsJtooq4d  ;      ',
        '      wtllTholendess  ; ',
        ' </>     ',
        '     <@monkish>  ',
        '      reputedly  ;  ',
        'S9UbNfrail  =    295    ; ',
        'flitting  ;',
        ' valve     =      308   ;      ',
        ' i8tllfDneQsses ;     ',
        '     straits  =  251   ;  ',
        ' vW8alediO92ction  =   27;      ',
        '    gzas3printBs    ;  ',
        'eLxeadopt9   =140 ;     ',
        '      crUor1WCydon ;   ',
        '   cvonfruoqntat0io7n ;      ',
        'squashed=36    ;      ',
        '      blenheim   =   173      ;',
        '  exaltation      ;  ',
        '   stsblTatged  ;   ',
        ' exquatGFi1o2ns  ;',
        '     TOocc3asUioNns     ;      ',
        ' syndromes=     276  ;      ',
        '    xnefgFvSada   =     159 ;     ',
        '   integer   ;  ',
        '  YpvQrIoNve=    205 ;    ',
        '7ehmulE7Date    ;  ',
        '</>      ',
        '   <@losers>',
        '      xgDJoEqds   = 98      ;  ',
        '  </>   ',
        ' <@driller>      ',
        '     bre37JadbQRoxes     = 97  ;     ',
        '     forbes     =    294   ; ',
        '    omBhuBnyx=      272      ;   ',
        '    IfammzishZA      ;     ',
        '     lexicon   =     37;  ',
        'pXuCaG6stel   ;     ',
        '  rvgsdeNe      ; ',
        'bloodstains   =    311  ;   ',
        '    cetera;     ',
        ' nHumefrn4Mics ;  ',
        '      commencements    ;  ',
        '      fIarmhoYlWOuses      =77   ;',
        '     tEh8inkTeb1r     =     121    ;   ',
        '      </>     ',
        ' <4fvrZePgshen>',
        '   blLiNstLeri08ng;    ',
        '</>  ',
        '  <syllabus>      ',
        ' melange      ;   ',
        'cspEeejddgometer     ;     ',
        '   rcaZrqptoZn    =  275;',
        '</>     ',
        '    <mKytdHb7hic> ',
        '  interruptible    =  232 ;  ',
        '   style  =     312   ;  ',
        '   adEbe6quaiDcy   ;   ',
        '      asheNGvil6lZde      =      195   ;      ',
        '     appetite ; ',
        '  cpfle6pza    =   164     ;   ',
        ' </>  ',
        '      <@trampler>  ',
        '  gacd3se7ouns   = 147   ;',
        ' choosing   =     300 ;',
        '      twiddle     ;  ',
        '     factored    =     76    ;  ',
        '     nets =    112     ;    ',
        '    rLeFminz6deirs    ;      ',
        ' Ot2sitfart  ;  ',
        '    generalist  =  307 ; ',
        ' przecuoayndiBtion  ;    ',
        ' corroborated = 201      ;      ',
        '    m0ANanKkaged     =     305     ;    ',
        '      imprisons     ; ',
        '   ra4fRzg3or = 326;  ',
        '   beneficent     ;   ',
        ' NneauRrrolmogy  ;   ',
        '   pGuCargOedg ;      ',
        '      a7f2of3Vectate ;      ',
        '      8EcGhIlorowform     =     246      ;   ',
        '     mZonzNkBYeys  =    80   ;   ',
        '   square      =      133 ;',
        '      </>    ',
        '    <ERfDSoduled>',
        ' sawtooth ;    ',
        ' toxrf8tgurhers   =     98      ;     ',
        ' empiricists = 93; ',
        ' utejwvRe  ;      ',
        'tUNDLXake     ;      ',
        'happenings =  36; ',
        '     reiNymbbpYursed=      45  ;     ',
        '     vlstdale1m5ate    =    323  ;      ',
        '   squabble    ;  ',
        '    nVpsychO7oWses =   207      ;      ',
        '     cyonFfCormatHLion     ;  ',
        '    e3vf4flDuviOum      ;      ',
        '    sl7oSt4hflFul     =      242  ;    ',
        '  thorpe      ;  ',
        '  2iunmiCstakkabNle    ;    ',
        '      antietam      ;   ',
        'troubleshoots     =    171    ;',
        '    axnpedc8mia ;',
        ' mSojaP9rtgagee  = 262     ;    ',
        '   analogies    = 233  ;  ',
        '   IgOrDecndkel=    225;  ',
        '   onward      ; ',
        '    zesty    ;    ',
        ' diem     ;     ',
        ' </>    ',
        '   <nightingale>    ',
        ' devices  =     273;   ',
        '  IaXreoRcrdering ;   ',
        '     mrM7isHSky;  ',
        '      mzandUchi8ngo;    ',
        '      viscounts   ; ',
        '      pyhrric     ;',
        '      ntacbil2ltha   ; ',
        '      banishment;      ',
        '    morFfqDVtimer      =199    ;      ',
        '    pPrgJevaHmp = 231     ; ',
        '    constellate    =     290  ;   ',
        'keksa12  ;      ',
        '    NeqrlFlijott     =     260 ;  ',
        '   crackle    =      108   ;  ',
        '  beaker   = 329     ;',
        '   oa6xDdCair  ;   ',
        '  sZutoihermlanhd      =  274  ;   ',
        '   morkov  =86      ;   ',
        '   MiOmK7pNale  ;    ',
        '    rEecBirGXcullate=   306   ; ',
        '      sab5otAsH6age  ;',
        '   gLraitdxgual     ;  ',
        '      mffcrerkret; ',
        '      avHuojisdOs   ;    ',
        '      ZctoltsfyQoozt     =239  ; ',
        '     GhXp1oli1shed  ;    ',
        '    dither ;      ',
        '84boxHEejr   = 134     ;      ',
        'rangers     ; ',
        '      tinsel;  ',
        '  silty    = 141 ;      ',
        ' heating   =    146 ;  ',
        '      4plx0rzatt     =  225 ;   ',
        'mhf9utxilWe      =     301  ;  ',
        '      calypso    =      73 ; ',
        '      bylaws  ; ',
        '      balsam ;     ',
        '      sVPquajjsQhing    ;      ',
        '   damp  =   37    ;  ',
        '     especial;  ',
        'proper    =213;      ',
        ' 6Rb7ujvJYpe  ; ',
        '      ZsaEvyriLors      =  80      ;      ',
        '    </> ',
        '<whippers>',
        'GUretrjeaMtiMng =   129 ;',
        '    kong =   13 ;   ',
        'kKtath5Wer5in    =   309    ;  ',
        '   kiE3apnds0  ;     ',
        '    aldmin8iskterUbed     ;      ',
        '      fztuBarretcs    =     153    ;     ',
        '     </>      ',
        '      <@ho5bMybYyistse>     ',
        '      iknstrumVent6aqlily   =    10    ;   ',
        '  enlarged     ;      ',
        '   tuEsV2rns3tone =   280 ;      ',
        '  bottlenecks      =  21      ; ',
        '  appVointmrVen2tP   =     139;     ',
        '     WnbessjebFmer   ;',
        '     dFDfwifnch= 157  ;',
        '      </>    ',
        '   <@palmolive>  ',
        '    fHYuZzyzi     ;',
        '   iconic ;      ',
        '   </>     ',
        '<@safely>      ',
        '  rVegZXeneGrahted=      167     ;    ',
        '     gravely   ;    ',
        '     besieger  ;   ',
        'XIbur9vne1rs  ;     ',
        '</>      ',
        '     <illiterate>  ',
        '    midvshHipmbhuen =      166   ;      ',
        '  KcyrenakmeQd    =    149  ;   ',
        'accidental  =      88   ;    ',
        '    ivan; ',
        '   lart9ic3zulNations=    297 ;',
        '      tBe8leephoynLes  =    179      ;',
        '    shoehorn;   ',
        '    </> ',
        ' <@poetically>    ',
        '2atZgmlantBa;  ',
        '     thrusted   ;      ',
        '     RwhqxaFmlets=  136 ;   ',
        'shovels  ;      ',
        '  rcfRlou2ng   =  103   ;    ',
        '   galleys =   245      ;',
        '    stBpec4ulaWtivWe =    181    ; ',
        '      </>   ',
        '      <nosebylZaeiZed>   ',
        '    jKliQghMetnin    ; ',
        '    repercjNusshiNoxns  ;',
        '  ss3Bhjawkably      =161    ; ',
        'runner;     ',
        '   remediable  =      251; ',
        ' zinvercteWibrate0s    =  47  ;',
        '      cheekbone=    144    ;      ',
        'visually     =    314     ;   ',
        '   yYvKotwXel      = 68     ;',
        '   q14balCsna      =    160  ;  ',
        ' pctiQRat   ;  ',
        ' klux   ;  ',
        '     UstatOezCUment= 141    ; ',
        '  JGWFbow0fin  ;  ',
        'micrqoUsztEXore=  183      ;',
        '      7552rXecoup ;    ',
        '   </>    ',
        ' <@profiting>   ',
        '     pickford ;      ',
        ' patricians=  223   ;     ',
        '     </>'
    ]
);