function solve(args) {

    let level = -1,
        position = -1,
        arrayOfTitles = [],
        arrayOfProperties = [],
        len = args.length,
        i = 0,
        currentPosition = 0,
        index = -1;


    function isLetter(str) {
        return str.length === 1 && str.match(/[a-z]/i);
    }

    //properties
    for (i = 0; i < len; i += 1) {
        let currentLine = args[i].trim();

        if (currentLine.indexOf('{') > -1) {
            let sBracket = 1,
                eBracket = 0,
                noFill = false,
                b = i;

            arrayOfProperties.push([]);
            index += 1;

            while (sBracket != eBracket) {
                b += 1;
                currentLine = args[b].trim();

                let transformation = '';
                for (let q = 0; q < currentLine.length; q += 1) {
                    if (currentLine[q] == '\t') {
                        continue;
                    }

                    transformation += currentLine[q];
                }

                currentLine = transformation;

                if (currentLine.indexOf('{') <= -1 && currentLine.indexOf('}') <= -1) {
                    if (noFill == false) {
                        let splited = currentLine.split(':'),
                            firstPart = splited[0],
                            secondPart = splited[1];

                        firstPart = firstPart.trim();
                        secondPart = secondPart.replace(';', '');
                        secondPart = secondPart.trim();
                        secondPart += ';';

                        currentLine = '';
                        currentLine += firstPart;
                        currentLine += ': ';
                        currentLine += secondPart;

                        arrayOfProperties[index].push(currentLine);
                    }
                }

                if (currentLine.indexOf('{') > -1) {
                    sBracket += 1;
                    noFill = true;
                } else if (currentLine.indexOf('}') > -1) {
                    eBracket += 1;
                    if (eBracket == sBracket - 1) {
                        noFill = false;
                    }
                }
            }
        }
    }

    //titles
    for (i = 0; i < len; i += 1) {
        let currentLine = args[i].trim();

        if (currentLine.indexOf('{') > -1 && level <= -1) {

            let transformed = '';
            for (let h = 0; h < currentLine.length; h += 1) {

                if (currentLine[h] == ' ' || currentLine[h] == '\t') {
                    continue;
                }

                if (currentLine[h] == '{') {
                    transformed += ' {';
                    currentLine = transformed;
                    break;
                }
                transformed += currentLine[h];
            }

            position += 1;
            arrayOfTitles.push(currentLine);
            level += 1;
            currentPosition = position;
            arrayOfProperties.push([]);
        } else if (currentLine.indexOf('{') > -1 && level > -1) {

            //remove spacec and some tabs!!! \t u must debugg this its amazing....how can they....
            let transformed = '';
            for (let h = 0; h < currentLine.length; h += 1) {

                if (currentLine[h] == ' ' || currentLine[h] == '\t') {
                    continue;
                }

                if (currentLine[h] == '{') {
                    transformed += ' {';
                    currentLine = transformed;
                    break;
                }
                transformed += currentLine[h];
            }

            position += 1;
            level += 1;
            arrayOfProperties.push([]);

            if (currentLine.indexOf('.') > -1 || currentLine.indexOf('>') > -1 ||
                currentLine.indexOf('$') > -1 || currentLine.indexOf('+') > -1 ||
                currentLine.indexOf('~') > -1 || currentLine.indexOf('#') > -1 ||
                isLetter(currentLine[0].trim())) {

                let previousSelector = arrayOfTitles[currentPosition];
                previousSelector = previousSelector.replace('{', '');

                if (currentLine.indexOf('$') > -1) {

                    currentLine = currentLine.replace('$', '');
                    previousSelector = previousSelector.substring(0, previousSelector.length - 1);

                    arrayOfTitles.push(previousSelector + currentLine);
                    currentPosition += 1;
                    continue;
                }

                arrayOfTitles.push(previousSelector + currentLine);
                currentPosition += 1;
                continue;
            }
            arrayOfTitles.push(currentLine);
        } else if (currentLine.indexOf('}') > -1) {
            currentPosition -= 1;
            level -= 1;
        }
    }

    for (i = 0; i < arrayOfTitles.length; i += 1) {
        console.log(arrayOfTitles[i]);

        for (let j = 0; j < arrayOfProperties[i].length; j += 1) {
            console.log('  ' + arrayOfProperties[i][j]);
        }

        console.log('}');
    }
}

solve(
    [
        '#frameset25 {',
        '  teenagers: SIG;',
        '  tr11 {',
        '    amazement: echo;',
        '    fearfully: terms;',
        '    compound: s;',
        '  }',
        '  cocoonos: Jython;',
        '  .title72 {',
        '    herring: quietly;',
        '    #center49 {',
        '      silkworm: Prevent;',
        '      erickson: ImportError;',
        '      strategic: 4;',
        '      jet: under;',
        '      wanted: dump;',
        '      colgroup-8 {',
        '        submit: SIGINT;',
        '        idler: python3;',
        '        maxims: nExiting;',
        '        unevaluated: ignored;',
        '        speechts: the;',
        '        pioneered: pdb;',
        '        illegitimate: PermissionDenied;',
        '        barbarities: pdb;',
        '      }',
        '      accustomed: stderr;',
        '      perceives: write;',
        '      strange: information;',
        '      breadboxes: finalize;',
        '      testifies: exception;',
        '      mappable: Permission;',
        '      #div-22 {',
        '        actuate: try;',
        '        antibiotic: SIGUSR1;',
        '        #b13 {',
        '          secretariat: def;',
        '          continentally: block;',
        '          advantage: bin;',
        '          reprinting: then;',
        '          .div61 {',
        '            anatomical: signal;',
        '            poverty: portage;',
        '            fixates: ParseError;',
        '            .option96 {',
        '              thermionic: mod;',
        '            }',
        '            gangos: trace;',
        '            table-42 {',
        '              greased: IGN;',
        '              sorrowful: ImportError;',
        '              contiguously: caller;',
        '              seer: globals;',
        '              maturing: quietly;',
        '              displacement: Errno;',
        '              tuscan: output;',
        '            }',
        '            exchanged: but;',
        '            .style25 {',
        '              reexamined: bin;',
        '              #legend-77 {',
        '                lots: pass;',
        '                contained: ensures;',
        '                dilapidate: try;',
        '                questers: dump;',
        '                facetious: Permission;',
        '                cirmcumferential: frame;',
        '                #tt-74 {',
        '                  audiotape: Gentoo;',
        '                  mountaings: 0;',
        '                  .blink48 {',
        '                    xavier: errno;',
        '                    unidirectionally: under;',
        '                    stinking: quietly;',
        '                    spinoff: DFL;',
        '                    .i-44 {',
        '                      attempts: before;',
        '                      .b68 {',
        '                        capella: See;',
        '                        pomona: this;',
        '                        poorer: raise;',
        '                        adjudging: retval;',
        '                        babyish: emerge;',
        '                        mimetic: True;',
        '                        tularemia: 4;',
        '                        #dfn-58 {',
        '                          lacquer: 0;',
        '                          #code-97 {',
        '                            convocate: if;',
        '                            quitters: ParseError;',
        '                            info: don;',
        '                            preposition: import;',
        '                            #p-64 {',
        '                              gosling: installing;',
        '                              flaws: echo;',
        '                              precious: are;',
        '                              propulsions: IGN;',
        '                              conceited: unexpected;',
        '                              possums: DFL;',
        '                            }',
        '                            razorqs: in;',
        '                            smelly: obscure;',
        '                            artificialness: signum;',
        '                            ventilate: stderr;',
        '                            exorbitant: signum;',
        '                            manicure: This;',
        '                            object: may;',
        '                            caption-6 {',
        '                              approximates: remove;',
        '                              suggestively: information;',
        '                              syndicated: See;',
        '                              hardness: License;',
        '                              daunted: nExiting;',
        '                              screenings: insert;',
        '                            }',
        '                            heir: tb;',
        '                            ginsburg: be;',
        '                            maritime: sys;',
        '                            encrypts: SIGPIPE;',
        '                            statisticianhs: when;',
        '                            drunker: path;',
        '                            .blockquote92 {',
        '                              addicted: Jython;',
        '                              endeavored: not;',
        '                              recline: which;',
        '                              scytheus: ImportError;',
        '                              overjoy: causes;',
        '                              #b-2 {',
        '                                radiations: on;',
        '                                renamed: directories;',
        '                                bladderwort: legacy;',
        '                                crusading: 130;',
        '                                #dt-35 {',
        '                                  pierre: insert;',
        '                                  span-56 {',
        '                                    plummeting: Errno;',
        '                                    enrollment: message;',
        '                                    obscure: files;',
        '                                    liqueur: PermissionDenied;',
        '                                    dirichlet: ensures;',
        '                                    immovably: dump;',
        '                                    failures: isfile;',
        '                                  }',
        '                                  curate: debug;',
        '                                  aloe: KeyboardInterrupt;',
        '                                  ascensions: ImportError;',
        '                                  perusal: IsADirectory;',
        '                                  listener: errno;',
        '                                  announcements: 0x7fd2146c1320;',
        '                                  sliver: an;',
        '                                  #kbd-62 {',
        '                                    tusk: str;',
        '                                    mothered: signum;',
        '                                    handbag: 128;',
        '                                  }',
        '                                  shoving: man;',
        '                                  exclusiveness: stderr;',
        '                                  maldive: 0x7fd2146c1320;',
        '                                  believable: information;',
        '                                  lavoisier: on;',
        '                                  mast: n;',
        '                                  districts: quietly;',
        '                                  dfn-47 {',
        '                                    vail: We;',
        '                                    fitch: installed;',
        '                                    singling: directory;',
        '                                    nautilus: output;',
        '                                    appointee: the;',
        '                                  }',
        '                                  binuclear: 4;',
        '                                  standpoints: IsADirectory;',
        '                                  awnings: on;',
        '                                  teen: elog;',
        '                                  #textarea74 {',
        '                                    dubious: SIGTERM;',
        '                                    open: n;',
        '                                    vouchers: installing;',
        '                                    easily: bug;',
        '                                    spelled: n;',
        '                                  }',
        '                                  mop: v2;',
        '                                  footstep: directories;',
        '                                  dice: insert;',
        '                                  anesthetic: trace;',
        '                                  embassy: unexpected;',
        '                                  brigantine: installed;',
        '                                  elution: directories;',
        '                                  nods: internal;',
        '                                  tt-88 {',
        '                                    goodman: main;',
        '                                    jim: print;',
        '                                    rippling: exithandler;',
        '                                    smucker: terms;',
        '                                    wondrous: flush;',
        '                                    jeweler: v2;',
        '                                    doubling: installing;',
        '                                    syndrome: handler;',
        '                                    metallic: with;',
        '                                    dt-74 {',
        '                                      rustication: globals;',
        '                                      sulks: to;',
        '                                      blushing: flush;',
        '                                      yard: tb;',
        '                                      allegrettos: def;',
        '                                      converting: os;',
        '                                      dissociate: bin;',
        '                                      stiffens: of;',
        '                                      cranked: exithandler;',
        '                                      professorns: but;',
        '                                    }',
        '                                    chenille: exiting;',
        '                                    neonate: pipe;',
        '                                    bylaws: function;',
        '                                    deflate: else;',
        '                                    troublesomely: since;',
        '                                    freethink: before;',
        '                                    .del-94 {',
        '                                      caviar: installed;',
        '                                    }',
        '                                    collectively: str;',
        '                                    .embed-92 {',
        '                                      recent: e;',
        '                                      indomitable: Gentoo;',
        '                                      twisted: 130;',
        '                                      mules: is;',
        '                                      altruist: pass;',
        '                                      buckles: osp;',
        '                                      wrist: block;',
        '                                      unraveling: try;',
        '                                      representational: but;',
        '                                      veterans: Errno;',
        '                                      logarithms: not;',
        '                                      freckles: when;',
        '                                      #thead30 {',
        '                                        hubbell: in;',
        '                                        ritual: frame;',
        '                                        em-15 {',
        '                                          subscription: 0;',
        '                                          barbarity: KeyboardInterrupt;',
        '                                          parameterized: handlers;',
        '                                          prevents: C;',
        '                                          .sup37 {',
        '                                            inapproachable: 1;',
        '                                            snapdragon: General;',
        '                                            woe: print;',
        '                                            lander: portage;',
        '                                            bedding: Gentoo;',
        '                                            casual: function;',
        '                                          }',
        '                                          conquerors: handlers;',
        '                                          #menu-4 {',
        '                                            grievancecs: 424259;',
        '                                            seasonally: This;',
        '                                            taped: name;',
        '                                            dregs: write;',
        '                                            electronically: True;',
        '                                            perception: obscure;',
        '                                            sun: elog;',
        '                                            autos: See;',
        '                                            oration: then;',
        '                                            yapping: join;',
        '                                            ul78 {',
        '                                              concentrator: when;',
        '                                              picnicker: sys;',
        '                                              paulus: want;',
        '                                              subdivided: internal;',
        '                                              expanders: 4;',
        '                                              possums: if;',
        '                                              .button21 {',
        '                                                accretion: if;',
        '                                                atmospheres: usr;',
        '                                                .head-95 {',
        '                                                  propound: portage;',
        '                                                  ringlet: exc;',
        '                                                  .td15 {',
        '                                                    pilers: should;',
        '                                                    latterly: file;',
        '                                                    vicksburg: os;',
        '                                                  }',
        '                                                  vii: ignore;',
        '                                                  doped: Errno;',
        '                                                  modified: name;',
        '                                                  mired: directory;',
        '                                                  shortagess: SIGUSR2;',
        '                                                  involute: License;',
        '                                                  drinkers: Gentoo;',
        '                                                  uncanny: on;',
        '                                                  #noframe28 {',
        '                                                    jimmy: handlers;',
        '                                                    negotiating: IsADirectory;',
        '                                                    impudent: quietly;',
        '                                                    reliant: retval;',
        '                                                    prison: terms;',
        '                                                    used: signal;',
        '                                                    setting: Broken;',
        '                                                    courage: Permission;',
        '                                                    bullets: as;',
        '                                                    intersecting: 1;',
        '                                                  }',
        '                                                  yielded: showing;',
        '                                                  lisle: PermissionDenied;',
        '                                                  dane: implementation;',
        '                                                  lightning: the;',
        '                                                  congressmen: man;',
        '                                                  clamps: SIGTERM;',
        '                                                  piloting: with;',
        '                                                }',
        '                                                hatch: disable;',
        '                                                coons: ignore;',
        '                                                incidentms: signum;',
        '                                                antislavery: exit;',
        '                                              }',
        '                                              excrescent: 130;',
        '                                              flashlights: sys;',
        '                                              sammy: Jython;',
        '                                              lollipop: DFL;',
        '                                              exasperating: SIGPIPE;',
        '                                              abbott: n;',
        '                                              subsumes: exiting;',
        '                                              sifting: is;',
        '                                              haplology: print;',
        '                                            }',
        '                                            dickcissel: not;',
        '                                            fileas: that;',
        '                                            irresponsible: this;',
        '                                            classical: exc;',
        '                                            inhabitants: SIGUSR2;',
        '                                            coinage: to;',
        '                                            softened: write;',
        '                                            cynthia: for;',
        '                                            continuance: installed;',
        '                                            coordination: join;',
        '                                            caption52 {',
        '                                              alms: Copyright;',
        '                                              nne: files;',
        '                                              natures: Distributed;',
        '                                              coronary: Errno;',
        '                                              distracts: exc;',
        '                                              demons: signum;',
        '                                              .h169 {',
        '                                                bales: then;',
        '                                                teletypes: write;',
        '                                                militant: 1;',
        '                                                picasso: under;',
        '                                                irruption: IGN;',
        '                                                .base-58 {',
        '                                                  lofty: Public;',
        '                                                  shrewdly: main;',
        '                                                  leroy: not;',
        '                                                  project: def;',
        '                                                  .input-41 {',
        '                                                    brandish: denied;',
        '                                                    brookhaven: print;',
        '                                                    center31 {',
        '                                                      drifter: trace;',
        '                                                      embellishments: writing;',
        '                                                      sang: directory;',
        '                                                      mutterer: under;',
        '                                                      howled: 130;',
        '                                                      aspirin: with;',
        '                                                      .b27 {',
        '                                                        familism: See;',
        '                                                        apothegm: General;',
        '                                                        stygian: isfile;',
        '                                                        lacked: stderr;',
        '                                                        chao: write;',
        '                                                        simulations: ParseError;',
        '                                                        disastrous: globals;',
        '                                                        hordens: We;',
        '                                                        cistern: Foundation;',
        '                                                        #link-13 {',
        '                                                          chunk: General;',
        '                                                          dfn80 {',
        '                                                            scooped: block;',
        '                                                          }',
        '                                                          strengthening: like;',
        '                                                          quartetls: See;',
        '                                                          briefing: pass;',
        '                                                          guides: retval;',
        '                                                          refugeegs: installing;',
        '                                                          bottoms: C;',
        '                                                          label-94 {',
        '                                                            octahedron: of;',
        '                                                            yellowknife: globals;',
        '                                                            metricms: ignore;',
        '                                                            eagerness: isfile;',
        '                                                            inflicted: -b;',
        '                                                            protestations: occurs;',
        '                                                            restrainers: ensures;',
        '                                                            administrate: name;',
        '                                                            gratuitous: since;',
        '                                                            .frameset-14 {',
        '                                                              disillusioning: pass;',
        '                                                              gabardine: occurs;',
        '                                                              uncovered: usr;',
        '                                                              needlers: SIGUSR2;',
        '                                                              ridding: are;',
        '                                                              neath: bug;',
        '                                                              producers: v2;',
        '                                                              episodes: osp;',
        '                                                              rerouted: that;',
        '                                                            }',
        '                                                            turmoil: n;',
        '                                                            lares: globals;',
        '                                                            stipulates: then;',
        '                                                            crusaders: unexpected;',
        '                                                            hung: ensures;',
        '                                                          }',
        '                                                          adjoining: exit;',
        '                                                        }',
        '                                                        ridgeis: Permission;',
        '                                                      }',
        '                                                      possible: unexpected;',
        '                                                      concocter: IGN;',
        '                                                      regionally: exiting;',
        '                                                      humaneness: def;',
        '                                                      improperly: unexpected;',
        '                                                    }',
        '                                                    crowning: installing;',
        '                                                    brink: exception;',
        '                                                    mildred: t;',
        '                                                    shabby: intermittently;',
        '                                                    panks: echo;',
        '                                                    supervene: pym;',
        '                                                    diffusions: information;',
        '                                                    unexpected: but;',
        '                                                  }',
        '                                                  fur: exceptions;',
        '                                                }',
        '                                                adjustors: echo;',
        '                                                recapitulation: bin;',
        '                                                sofais: since;',
        '                                                stoppable: ensures;',
        '                                                aprons: SIGUSR1;',
        '                                                aching: This;',
        '                                              }',
        '                                              coffer: may;',
        '                                              natty: If;',
        '                                              quadrangular: SIGUSR1;',
        '                                              start: with;',
        '                                              impurityas: obscure;',
        '                                              berryls: which;',
        '                                              adorable: frame;',
        '                                              collar: interrupts;',
        '                                              usurer: join;',
        '                                              horus: portage;',
        '                                              mason: since;',
        '                                            }',
        '                                            ministers: else;',
        '                                            heraclitus: pipe;',
        '                                            punts: so;',
        '                                            pap: output;',
        '                                            opaqueness: occurs;',
        '                                            grottocs: v2;',
        '                                            seattle: pdb;',
        '                                            brocade: osp;',
        '                                            cylindric: join;',
        '                                            senatorls: causes;',
        '                                            scientistxs: denied;',
        '                                            regresses: from;',
        '                                          }',
        '                                          dutch: GNU;',
        '                                          disburse: before;',
        '                                          tailored: Foundation;',
        '                                          conflagrate: 4;',
        '                                        }',
        '                                        pontificate: this;',
        '                                        semanticist: directories;',
        '                                        libraries: dirname;',
        '                                        rabble: then;',
        '                                        sinking: os;',
        '                                        typic: KeyboardInterrupt;',
        '                                      }',
        '                                      dialectic: else;',
        '                                      peripherals: See;',
        '                                    }',
        '                                    enlist: realpath;',
        '                                    autonavigators: emerge;',
        '                                    lionts: may;',
        '                                    muscled: def;',
        '                                    adoption: IGN;',
        '                                    ma: finalize;',
        '                                    pardoned: 2006-2014;',
        '                                  }',
        '                                  unequally: handlers;',
        '                                  symmetric: DFL;',
        '                                  schooling: unexpected;',
        '                                  anhydrously: Prevent;',
        '                                  contrasting: in;',
        '                                  cores: elog;',
        '                                }',
        '                                wreak: bin;',
        '                              }',
        '                              poplar: 130;',
        '                              ladylike: realpath;',
        '                              activator: trace;',
        '                              alias: portage;',
        '                              marino: import;',
        '                            }',
        '                            awningts: function;',
        '                          }',
        '                          allocation: handlers;',
        '                          brigadiers: unexpected;',
        '                        }',
        '                        pistol: debug;',
        '                        glendale: retval;',
        '                        apportion: bug;',
        '                        ccny: 4;',
        '                      }',
        '                      clothesman: path;',
        '                    }',
        '                    prophesy: when;',
        '                    biopsy: this;',
        '                    spiteful: since;',
        '                    flagpole: unexpected;',
        '                    raze: handled;',
        '                    magnifier: obscure;',
        '                    eschewed: mod;',
        '                  }',
        '                  nitpick: emerge;',
        '                  paperwork: exiting;',
        '                  mcpherson: interrupts;',
        '                  positive: causes;',
        '                }',
        '                abrasion: page;',
        '                slug: Errno;',
        '                pain: Gentoo;',
        '                defied: may;',
        '              }',
        '              expressly: this;',
        '            }',
        '            subproblemhs: python3;',
        '            difficultycs: realpath;',
        '            inadequacies: when;',
        '            presser: import;',
        '            ingot: usr;',
        '            sugarings: interrupts;',
        '            silo: caller;',
        '          }',
        '          expected: traceback;',
        '          arctan: platform;',
        '          triangular: interrupts;',
        '          division: under;',
        '          lutess: try;',
        '          cheapness: 2006-2014;',
        '          restarted: DFL;',
        '          bela: file;',
        '        }',
        '        ultra: this;',
        '      }',
        '      maxine: set;',
        '    }',
        '    throughout: C;',
        '    adjuncts: file;',
        '    kankakee: handle;',
        '    transplant: 0;',
        '    osteopathic: pdb;',
        '  }',
        '  keats: SIG;',
        '  mustached: installed;',
        '  atchison: See;',
        '  ceylon: are;',
        '}'
    ]
);