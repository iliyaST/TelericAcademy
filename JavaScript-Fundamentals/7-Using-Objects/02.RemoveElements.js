function solve(args) {

    var array = args,
        i = 0;


    Array.prototype.remove = function(number) {
        var editedArray = [],
            index;

        for (index = 0; index < this.length; index += 1) {
            if (this[index] != number) {
                editedArray.push(this[index]);
            }
        }

        return editedArray;
    };

    array = array.remove(array[0]);

    var len = array.length;

    for (i = 0; i < len; i += 1) {
        console.log(array[i]);
    }
}