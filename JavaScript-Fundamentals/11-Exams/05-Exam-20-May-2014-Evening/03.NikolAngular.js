function solve(params) {
    let s = +params[0],
        model = {},
        allSections = {},
        currentSectionContent = '',
        currentSectionTitle = '',
        result = [],
        ifContent = '',
        isEnd = false,
        counter = 0;


    //get our input and put it into a object
    for (let i = 1; i <= s; i += 1) {
        let currentLine = params[i].split('-');

        var key = currentLine[0];
        var value = currentLine[1];

        if (value == 'true') {
            value = true;
        } else if (value == 'false') {
            value = false;
        } else if (value.indexOf(';') > -1) {
            value = value.split(';');
        }

        model[key] = value;
    }

    //console.log(model);
    let m = params[s + 1],
        len = params.length;

    for (let i = s + 2; i < len; i += 1) {
        let currentLine = params[i];

        if (currentLine.indexOf('{{') > -1) {
            currentLine = currentLine.replace('{{', '');
            currentLine = currentLine.replace('}}', '');
            result.push(currentLine);
            continue;
        } else if (currentLine.indexOf('<nk-template name="') > -1) {

            let startIndexSectionName = 0,
                endIndexSectionName = 0;

            startIndexSectionName = currentLine.indexOf('=\"', startIndexSectionName);
            endIndexSectionName = currentLine.indexOf('"', startIndexSectionName + 2);

            currentSectionTitle = currentLine.substring(startIndexSectionName + 2, endIndexSectionName);

            while (true) {
                i += 1;
                currentLine = params[i];
                if (currentLine != '</nk-template>') {
                    currentSectionContent += currentLine + "\n";
                } else {
                    break;
                }
            }

            allSections[currentSectionTitle] = currentSectionContent;
            currentSectionContent = '';
            currentSectionTitle = '';
            continue;
        } else if (currentLine.indexOf('<nk-template render="') > -1) {

            let startIndexSectionName = 0,
                endIndexSectionName = 0;

            startIndexSectionName = currentLine.indexOf('="', startIndexSectionName);
            endIndexSectionName = currentLine.indexOf('"', startIndexSectionName + 2);

            currentSectionTitle = currentLine.substring(startIndexSectionName + 2, endIndexSectionName);

            result.push(allSections[currentSectionTitle]);
            continue;
        } else if (currentLine == undefined) {
            currentLine = '';
        } else if (currentLine.indexOf('<nk-if condition="') > -1) {

            let startIndexSectionName = 0,
                endIndexSectionName = 0;

            startIndexSectionName = currentLine.indexOf('="', startIndexSectionName);
            endIndexSectionName = currentLine.indexOf('"', startIndexSectionName + 2);

            currentSectionTitle = currentLine.substring(startIndexSectionName + 2, endIndexSectionName);

            if (model[currentSectionTitle] === true) {
                i += 1;
                while (true) {
                    let currentLine = params[i].trim();
                    let tr = '    ';
                    tr += currentLine;
                    currentLine = tr;
                    if (currentLine == undefined) {
                        currentLine = '';
                    }

                    if (!(currentLine.indexOf('</nk-if>') > -1)) {
                        if (currentLine.indexOf('{{') > -1) {
                            currentLine = currentLine.replace('{{', '');
                            currentLine = currentLine.replace('}}', '');
                            ifContent += currentLine + '\n';
                            i += 1;
                        } else if (currentLine.indexOf('<nk-model>') > -1) {
                            let index = currentLine.indexOf('<nk-model>', 0);

                            while (index > -1) {

                                let startIndexSectionName = index + 9;
                                endIndexSectionName = 0,
                                    result1 = '';

                                endIndexSectionName = currentLine.indexOf('<', startIndexSectionName);

                                result1 = currentLine.substring(startIndexSectionName + 1, endIndexSectionName);

                                currentLine = currentLine.replace(result1, model[result1]);

                                // index = endIndexSectionName;
                                // index += '</nk-model>'.length;             

                                currentLine = currentLine.replace('<nk-model>', '');
                                currentLine = currentLine.replace('</nk-model>', '');

                                index = currentLine.indexOf('<nk-model>', index);
                            }

                            ifContent += currentLine;
                            i += 1;
                        }
                    } else if (currentLine.indexOf('</nk-if>') > -1) {
                        break;
                    }
                }
                result.push(ifContent);
                ifContent = '';
            } else {
                while (true) {
                    if (params[i].trim() !== '</nk-if>') {
                        i += 1;
                    } else {
                        break;
                    }
                }
            }

            continue;
        } else if (currentLine.indexOf('<nk-model>') > -1) {
            let index = currentLine.indexOf('<nk-model>', 0);

            while (index > -1) {

                let startIndexSectionName = index + 9;
                endIndexSectionName = 0,
                    result1 = '';

                endIndexSectionName = currentLine.indexOf('<', startIndexSectionName);

                result1 = currentLine.substring(startIndexSectionName + 1, endIndexSectionName);

                currentLine = currentLine.replace(result1, model[result1]);

                // index = endIndexSectionName;
                // index += '</nk-model>'.length;             

                currentLine = currentLine.replace('<nk-model>', '');
                currentLine = currentLine.replace('</nk-model>', '');

                index = currentLine.indexOf('<nk-model>', index);
            }
        } else if (currentLine.indexOf('<nk-repeat for="') > -1) {
            let index = currentLine.indexOf('="', 0);
            index += 2;
            let endIndex = currentLine.indexOf('"', index);
            let currentFor = currentLine.substring(index, endIndex);

            let curForSplited = currentFor.split(' ');

            let curP = curForSplited[0],
                curC = curForSplited[2];

            i += 1;
            counter = 0;
            let y = -1;
            //loop logic


            for (p of model[curC]) {
                y += 1;
                let b = i;
                while (true) {
                    currentLine = params[b];
                    counter += 1;

                    if (currentLine == undefined) {
                        currentLine = '';
                    }

                    if (currentLine.indexOf('<nk-model>') > -1) {
                        let lIndex = currentLine.indexOf('<nk-model>', 0),
                            lEndIndex = currentLine.indexOf('</nk-model>', 0);
                        lIndex += 10;

                        let sub = currentLine.substring(lIndex, lEndIndex);

                        if (sub == curP) {
                            currentLine = currentLine.replace(sub, p);
                            currentLine = currentLine.replace('<nk-model>', '');
                            currentLine = currentLine.replace('</nk-model>', '');
                        } else {
                            currentLine = currentLine.replace(sub, model[sub]);
                            currentLine = currentLine.replace('<nk-model>', '');
                            currentLine = currentLine.replace('</nk-model>', '');
                        }

                        result.push(currentLine);
                        b += 1;
                        continue;
                    }

                    if (currentLine.indexOf('</nk-repeat>') > -1) {
                        if (y == model[curC].length - 1) {
                            i += counter - 1;
                            break;
                        }
                        counter = 0;
                        break;
                    }
                    result.push(currentLine);
                    b += 1;
                }
            }

            if (y == model[curC].length - 1) {
                isEnd = true;
                continue;
            }
            //console.log(result);
            result.push(currentLine);
        }

        //console.log(result);
        result.push(currentLine);
    }
    for (let q = 0; q < result.length; q += 1) {
        if (result[q] == undefined) {
            result[q] = '';
        }
        console.log(result[q].trimRight());
    }
}

solve(
    [
        '0',
        '15',
        '<div>',
        '    <p>',
        '    {{<nk-if condition="pesho">}}',
        '        {{escaped}} dude',
        '    </p>',
        '    <p>',
        '    {{<nk-template render="pesho">}}',
        '    </p>',
        '    <p>',
        '    {{<nk-repeat for="pesho in peshos">}}',
        '        {{escaped}} in comment',
        '    </p>',
        '</div>'
    ]
);