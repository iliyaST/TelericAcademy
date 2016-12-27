function solve(args) {

    var text = args[0];

    function reverseString(text) {
        var output = "";
        for (var i = 0; i < text.length; i += 1) {
            output += text[text.length - 1 - i];
        }
        return output;
    }

    reversedText = reverseString(text);

    console.log(reversedText);
}

//solve(['sample']);