function solve(args) {
    let text = args[0],
        inTag = false,
        currentTag = '',
        tags = [],
        result = [];

    for (var i = 0; i < text.length; i++) {
        if (text[i] === '<') {
            inTag = true;
        } else if (text[i] === '>' && inTag) {
            inTag = false;
            currentTag += text[i];
            tags.push(currentTag);
            currentTag = '';
        } else if (!inTag) {
            if (tags.length === 0) {
                result.push(text[i]);
            } else if (tags[tags.length - 1].indexOf('upcase') !== -1) {
                result.push(text[i].toUpperCase());
            } else if (tags[tags.length - 1].indexOf('lowcase') !== -1) {
                result.push(text[i].toLowerCase());
            } else {
                result.push(text[i]);
            }
        }

        if (inTag) {
            currentTag += text[i];
        }

        if (tags.length !== 0 && tags[tags.length - 1].indexOf('</') !== -1) {
            tags.pop();
            tags.pop();
        }
    }

    console.log(result.join(''));
    //console.log(tags);
}
// function solve(args) {
//     var text = args[0],
//         lowercase = false,
//         upcase = false,
//         orgcase = false,
//         stringArray = [], //we use this array as stack in which we fill nested tags
//         output = "",
//         i = 0;

//     for (i = 0; i < text.length; i += 1) {
//         if (text.substr(i, 9) === "<orgcase>") {
//             orgcase = true;
//             stringArray.push("org");
//             i += 8;
//             continue;
//         }
//         if (text.substr(i, 10) === "</orgcase>") {
//             orgcase = false;
//             stringArray.pop();
//             i += 9;
//             continue;
//         }
//         if (text.substr(i, 8) === "<upcase>") {
//             upcase = true;
//             stringArray.push("up");
//             i += 7;
//             continue;
//         }
//         if (text.substr(i, 9) === "</upcase>") {
//             upcase = false;
//             stringArray.pop();
//             i += 8;
//             continue;
//         }
//         if (text.substr(i, 9) === "<lowcase>") {
//             lowercase = true;
//             stringArray.push("low");
//             i += 8;
//             continue;
//         }
//         if (text.substr(i, 10) === "</lowcase>") {
//             lowercase = false;
//             stringArray.pop();
//             i += 9;
//             continue;
//         }
//         //if last in stack is low and lower is true
//         if (lowercase && stringArray[stringArray.length - 1] === "low") {
//             output += String(text[i]).toLowerCase();
//             continue;
//         }
//         //if last in stack is upcase and upcase is true
//         if (upcase && stringArray[stringArray.length - 1] === "up") {
//             output += String(text[i]).toUpperCase();
//             continue;
//         }
//         //if last in stack is mixcase and mixcase is true
//         if (orgcase && stringArray[stringArray.length - 1] === "org") {
//             output += String(text[i]);
//             continue;
//         }
//         output += String(text[i]);
//     }
//     return output;
// }


// solve([
//     'We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.'
// ]);
solve(['<upcase>yellow <orgcase>sub</orgcase>mar</upcase>']);