function solve(args) {

    var property = args;

    obj = {
        name: 'Pesho',
        age: 25,
        sex: 'male',
        toString: function() {
            return '{name: ' + this.name + ', age: ' + this.age + ', sex: ' + this.sex + '}';
        },
    };
    var hasProperty = checkForProperty(obj, property);

    function checkForProperty(object, property) {
        for (var prop in object) {
            if (prop == property) {
                return true;
            }
        }
        return false
    }
}

solve('name');