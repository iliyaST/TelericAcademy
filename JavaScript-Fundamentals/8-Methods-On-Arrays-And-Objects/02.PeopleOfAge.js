function solve(args) {

    function Person(fname, lname, age, gender) {
        this.firstName = fname;
        this.lastName = lname;
        this.age = age;
        this.gender = gender;
    }

    var people = [
        new Person('Doncho', 'Minkov', 25, 'male'),
        new Person('Pesho', 'Goshev', 27, 'male'),
        new Person('Nikolay', 'Kostov', 22, 'male'),
        new Person('Gosha', 'Pesheva', 18, 'female'),
        new Person('Ivaylo', 'Kenov', 64, 'male'),
        new Person('Stamat', 'Shopov', 76, 'male'),
        new Person('Evlogi', 'Georgiev', 18, 'male'),
        new Person('Iveta', 'Kostova', 43, 'female'),
        new Person('Nenka', 'Nenkova', 76, 'female'),
        new Person('Nencho', 'Nenchov', 18, 'male')
    ];

    function isEighteen(person) {
        return !!(person.age >= 18);
    }

    var result = people.every(isEighteen);
    console.log(result);

}
solve(null);