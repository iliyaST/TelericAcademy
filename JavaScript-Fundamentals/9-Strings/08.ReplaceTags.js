/*
 Problem 8. Replace tags
 Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="…">…</a>
 with corresponding tags [URL=…]…/URL].
 */

function solution(args) {
    var input = args[0].split(''),
        inAnchor = false,
        inURL = false,
        inText = false,
        anchorFirstSymbol,
        anchorLastSymbol,
        replaceString = '',
        url = [],
        text = [],
        index;

    // I decided to write this solution without regex, because it's more fun :P

    for (index = 0; index < input.length; index += 1) {
        if (input[index] == '<' && input[index + 1] == 'a') {
            inAnchor = true;
            anchorFirstSymbol = index;
        }

        if (inAnchor) {
            if (!inURL && input[index] == '"') {
                inURL = true;
                continue;
            }

            if (inURL) {
                if (input[index] == '"') {
                    index += 1;
                    inURL = false;
                    inText = true;
                    continue;
                }

                url.push(input[index]);
            }

            if (inText) {
                if (input[index] == "<") {
                    inText = false;
                    continue;
                }
                text.push(input[index]);
            }

            if (input[index] == 'a' && input[index + 1] == '>') {
                anchorLastSymbol = index;

                replaceString = '[URL="' + url.join("") + '"]' + text.join('') + '[\/URL]';
                input.splice(anchorFirstSymbol, anchorLastSymbol - anchorFirstSymbol + 2);

                for (var j = 0; j < replaceString.length; j += 1) {
                    input.splice(anchorFirstSymbol + j, 0, replaceString[j]);
                }

                inAnchor = false;
                inURL = false;
                inText = false;
                anchorFirstSymbol = null;
                anchorLastSymbol = null;
                replaceString = '';
                url = [];
                text = [];
            }
        }
    }

    return input.join('');
}

console.log(solution(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']));