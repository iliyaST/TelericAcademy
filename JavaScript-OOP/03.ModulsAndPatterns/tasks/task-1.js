function solve() {

    var Course = {

        init: function(title, presentations) {

            this.presentations = presentations;
            this.students = [];
            this.ID = 0;

            if (title == '' || title == ' ' || title == undefined || title == null) {
                throw 'title cannot be empty or you know....';
            }

            for (let i = 0; i < presentations.length; i += 1) {
                if (presentations[i] == '' || presentations[i] == ' ' ||
                    presentations[i == undefined || presentations[i] == null]) {
                    throw 'exeption';
                }

                for (let j = 0; j < presentations[i].length; j += 1) {
                    if (presentations[i][j] == ' ' && presentations[i][j + 1] == ' ') {
                        throw 'consecutive space';
                    }
                }
            }

            for (let i = 1; i < title.length - 1; i += 1) {
                if (title[i] == ' ' && title[i + 1] == ' ') {
                    throw 'title does not contain consecutive space';
                }
            }

            if (title[0] == ' ' || title[title.length - 1] == ' ') {
                throw 'titles do not start or end with space';
            }

            if (title.length < 1) {
                throw 'title must contains atleast 1 char';
            }

            if (presentations.length == 0) {
                throw 'there must be presantations!';
            }

            return this;
        },
        addStudent: function(name) {

            var names = name.split(' ');

            if (names.length != 2) {
                throw 'invalid input';
            }

            this.ID += 1;

            var sID = this.ID,
                firstName = names[0],
                secondName = names[1];

            if (firstName[0] != firstName[0].toUpperCase()) {
                throw 'invalid name';
            }

            if (secondName[0] != secondName[0].toUpperCase()) {
                throw 'invalid name';
            }

            let fNameSub = firstName.substr(1, firstName.length),
                sNameSub = secondName.substr(1, secondName.length);

            if (fNameSub != fNameSub.toLowerCase() || sNameSub != sNameSub.toLowerCase()) {
                throw 'invalid name';
            }

            var student = {
                firstname: firstName,
                lastname: secondName,
                id: sID
            };

            this.students.push(student);

            return sID;
        },
        getAllStudents: function() {
            return this.students;
        },
        submitHomework: function(studentID, homeworkID) {

            function isInt(value) {
                var x = parseFloat(value);
                return !isNaN(value) && (x | 0) === x;
            }

            let studentsCount = this.students.length,
                presentationsCount = this.presentations.length;

            if (homeworkID > presentationsCount) {
                throw 'invalid ID';
            }

            if (studentID > studentsCount) {
                throw 'invalid ID';
            }

            if (homeworkID > presentationsCount) {
                throw 'invalid ID';
            }

            if (studentID < 1 || homeworkID < 1) {
                throw 'invalid ID';
            }

            if (!isInt(studentID)) {
                throw 'invalid ID';
            }

            if (!isInt(homeworkID)) {
                throw 'invalid ID';
            }


        },
        pushExamResults: function(results) {

            if (!(results instanceof Array)) {
                throw 'invalid input';
            }

            let idsArray = [];

            for (r of results) {
                if (r.StudentID < 1 || isNaN(r.score) ||
                    isNaN(r.StudentID) || r.StudentID > this.students.length
                ) {
                    throw 'invalid';
                }

                idsArray.push(r.StudentID);
            }


            for (let i = 0; i <= idsArray.length - 1; i += 1) {
                for (let j = i + 1; j < idsArray.length; j += 1) {
                    if (idsArray[j] == idsArray[i]) {
                        throw 'cheater allert';
                    }
                }
            }

        },
        getTopStudents: function() {}
    };

    return Course;
}

module.exports = solve;