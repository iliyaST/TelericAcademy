/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

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

// let course = solve();
// course.init('CSharp', ['Presentation1', 'Presentation2']);
// course.addStudent('Pesho Peshov');
// course.addStudent('Evg Nest');
// course.addStudent('Ili St');
// console.log(course.getAllStudents());
// course.submitHomework(1, 1);
module.exports = solve;