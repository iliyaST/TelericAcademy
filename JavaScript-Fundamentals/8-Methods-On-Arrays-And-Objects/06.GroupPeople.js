/*
Problem 6. Group people
 Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object
 Use Array#reduce
 Use only array methods and no regular loops (for, while)
*/

function solution(args) {
    function Person(fname, lname, age, gender) {
        this.firstName = fname;
        this.lastName = lname;
        this.gender = gender;
    }

    var people = [
        new Person('Doncho', 'Minkov', 25, 'male'),
        new Person('Pesho', 'Goshev', 27, 'male'),
        new Person('Nikolay', 'Kostov', 22, 'male'),
        new Person('Dodo', 'Pesheva', 14, 'female'),
        new Person('Ivaylo', 'Kenov', 64, 'male'),
        new Person('Stamat', 'Shopov', 76, 'male'),
        new Person('Evlogi', 'Georgiev', 18, 'male'),
        new Person('Eveta', 'Kostova', 43, 'female'),
        new Person('Petra', 'Nenkova', 76, 'female'),
        new Person('Nencho', 'Nenchov', 11, 'male')
    ];

    /* First Way */

    var result = {},
        letters = [];

    people = people.sort(function(first, second) {
        return first.firstName - second.firstName;
    });

    people.forEach(function(person) {
        if (letters.indexOf(person.firstName.charAt(0).toLowerCase()) == -1) {
            letters.push(person.firstName.charAt(0).toLowerCase());
        }
    });

    letters.forEach(function(letter) {
        result[letter] = people
            .filter(function(person) {
                return (person.firstName.charAt(0).toLowerCase() === letter);
            })
            .map(function(person) {
                return { Firstname: person.firstName };
            });
    });

    console.log(result);

    /* Second Way */

}

solution(null);