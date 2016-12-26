function solve(args) {

    function Person(fname, lname, age, gender) {
        this.firstName = fname;
        this.lastName = lname;
        this.age = age;
        this.gender = gender;
    }

    var people = [
        new Person('Doncho', 'Minkov', 25, false),
        new Person('Pesho', 'Goshev', 27, false),
        new Person('Nikolay', 'Kostov', 22, false),
        new Person('Gosha', 'Pesheva', 18, true),
        new Person('Ivaylo', 'Kenov', 64, false),
        new Person('Stamat', 'Shopov', 76, false),
        new Person('Evlogi', 'Georgiev', 18, false),
        new Person('Iveta', 'Kostova', 43, true),
        new Person('Nenka', 'Nenkova', 76, true),
        new Person('Nencho', 'Nenchov', 18, false)
    ];

    var femaleAges = 0,
        agesCount = 0;

    var adults = people
        .filter(function(people) {
            return people.gender === true;
        })
        .forEach(function(person) {
            femaleAges += person.age;
            agesCount += 1;
        });

    console.log((femaleAges / agesCount) | 0);

}
solve(null);