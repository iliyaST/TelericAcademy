function solution(args) {
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
        new Person('Gosha', 'Pesheva', 14, 'female'),
        new Person('Ivaylo', 'Kenov', 64, 'male'),
        new Person('Stamat', 'Shopov', 76, 'male'),
        new Person('Evlogi', 'Georgiev', 18, 'male'),
        new Person('Iveta', 'Kostova', 43, 'female'),
        new Person('Nenka', 'Nenkova', 76, 'female'),
        new Person('Nencho', 'Nenchov', 11, 'male')
    ];

    function Print(person) {
        console.log(person);
    }

    people.forEach(Print);
}
solution(null);