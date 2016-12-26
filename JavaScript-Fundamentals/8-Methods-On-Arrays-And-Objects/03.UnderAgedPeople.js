function solve(args) {

    function Person(fname, lname, age, gender) {
        this.firstName = fname;
        this.lastName = lname;
        this.age = age;
        this.gender = gender;
    }

    var people = [
        new Person('Doncho', 'Minkov', 15, 'male'),
        new Person('Pesho', 'Goshev', 27, 'male'),
        new Person('Nikolay', 'Kostov', 22, 'male'),
        new Person('Gosha', 'Pesheva', 18, 'female'),
        new Person('Ivaylo', 'Kenov', 64, 'male'),
        new Person('Stamat', 'Shopov', 76, 'male'),
        new Person('Evlogi', 'Georgiev', 18, 'male'),
        new Person('Iveta', 'Kostova', 17, 'female'),
        new Person('Nenka', 'Nenkova', 16, 'female'),
        new Person('Nencho', 'Nenchov', 11, 'male')
    ];

    //using forEach
    people.forEach(PrintPersonFirstNameAndAge);

    function PrintPersonFirstNameAndAge(person) {
        if (person.age < 18) {
            console.log(person.firstName + ' ' + person.age);
        }
    }

    //using filter
    var result = people.filter(isUnderAged);
    console.log(result);

    function isUnderAged(person) {
        return person.age < 18;
    }

}
solve(null);