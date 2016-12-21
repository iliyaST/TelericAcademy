//Implement a javascript function 
//that uses an expression to check if given integer 
//is odd or even, and prints "even NUMBER" or "odd NUMBER", 
//where you should print the input number's value instead of NUMBER.

function solve(args) {
    var a = args[0];
    if (a % 2 == 0) {
        console.log('even ' + a);
    } else {
        console.log('odd ' + a);
    }
}