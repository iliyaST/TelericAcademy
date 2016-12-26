function solve(args) {
    var people = [
        { firstname: 'Gosho', lastname: 'Goshev', age: 13 },
        { firstname: 'Ivan', lastname: 'Ivanov', age: 34 },
        { firstname: 'Niki', lastname: 'Petrov', age: 65 },
        { firstname: 'Niki', lastname: 'Goshev', age: 13 },
        { firstname: 'Gosho', lastname: 'Ivanov', age: 34 },
        { firstname: 'Ivan', lastname: 'Petrov', age: 65 }
    ];

    function group(people, key) {
        if (!people.length) return undefined;
        var result = {};
        for (var prop in people[0]) {
            if (prop === key) {
                for (var i = 0; i < people.length; i += 1) {
                    if (!result[people[i][key]]) {
                        result[people[i][key]] = [];
                    }
                    result[people[i][key]].push(people[i]);
                }
            }
        }
        return result;
    }

    var byAge = group(people, 'age'),
        byFirstName = group(people, 'firstname'),
        byLastName = group(people, 'lastname');

    console.log(byAge);
    console.log("\n\n");

    console.log(byFirstName);
    console.log("\n\n");

    console.log(byLastName);
}

solve();