function solve(args) {

    var text = args;
    inTag = false,
        lenText = text.length,
        index = 0,
        i = 0,
        output = "";

    for (index = 0; index < lenText; index += 1) {

        var currentWord = text[index].trim(),
            len = currentWord.length;

        for (i = 0; i < len; i += 1) {
            if (currentWord[i] === "<") {
                inTag = true;
            }
            if (currentWord[i] === ">") {
                inTag = false;
                continue;
            }
            if (inTag) {
                continue;
            } else {
                output += currentWord[i];
            }
        }
    }
    return output;
}

solve([
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]);