//Create the variables
var exampleString = 'Hello!',
    exampleBoolean = true,
    exampleInt = 69,
    exampleDouble = 6.9,
    exampleObject = {},
    exampleArray = [],
    exampleNull = null,
    exampleUndefined;

typeof(exampleArray)
//"object"
typeof(exampleBoolean);
//"boolean"
typeof(exampleString);
//"string"
typeof(exampleInt);
//"number"
typeof(exampleNull);
//"object"
typeof(exampleUndefined);
//"undefined"

//Other way
var variables = [
    'hello',
    15,
    null,
    25.6,
    true, [],
    {},
];

for (var i = 0; i < variables.length; i++) {
    console.log(typeof(variables[i]));
}