function solve(args) {
    function deepCopy(obj) {
        var objCopy = {};
        for (var prop in obj) {
            if (typeof(obj[prop]) == "object") {
                objCopy[prop] = deepCopy(obj[prop]);
            } else {
                objCopy[prop] = obj[prop];
            }
        }
        return objCopy;
    }

    var pesho = {
        name: "Pesho",
        age: 16,
        objProp: { prop1: 4, prop2: 7 }
    };

    var copy = deepCopy(pesho);
}
solve();