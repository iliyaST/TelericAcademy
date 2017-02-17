function solve() {
    var library = (function() {
        var books = [];
        var categories = [];

        function bookExist(t) {
            for (let i = 0; i < books.length; i += 1) {
                if (books[i].title == t) {
                    return true;
                }
            }
            return false;
        }

        function checkIfAllBooksAreFromOneCategory() {

            for (let i = 0; i < books.length - 1; i += 1) {
                if (books[i + 1].category != books[i].category) {
                    return false;
                }
            }

            return true;
        }

        function checkBookIsFoundInSelectedCategory(c) {
            for (b of books) {
                if (b.category == c) {
                    return true;
                }
            }
            return false;
        }

        function checkIfBooksFromSelectedAuthorAreFound(a) {
            for (b of books) {
                if (b.author == a) {
                    return true;
                }
            }
            return false;
        }

        function checkIfBooksCategoryAlreadyExistInCategorys(ca) {
            for (c of categories) {
                if (c.category == ca) {
                    return true;
                }
            }

            return false;
        }

        function checkIfRepeatingISBNIsFound(i) {
            for (b of books) {
                if (b.isbn == i) {
                    return true;
                }
            }
            return false;
        }

        function listBooks(optional) {

            if (books.length == 0) {
                return [];
            }

            if (optional && optional.category && (optional.author == null ||
                    optional.author == undefined)) {
                if (!checkBookIsFoundInSelectedCategory(optional.category)) {
                    return [];
                } else {
                    let filteredBooks = books.filter(function(c) {
                        return c.category == optional.category;
                    });

                    if (filteredBooks.length == 1) {
                        return filteredBooks;
                    }
                }
            } else if (optional && optional.author && (optional.category == null ||
                    optional.category == undefined)) {
                if (!checkIfBooksFromSelectedAuthorAreFound(optional.author)) {
                    return [];
                }
            }


            return books;
        }

        function addBook(book) {

            book.ID = books.length + 1;

            if (book.title.length < 2 || book.title.length > 100) {
                throw 'book title length exeption';
            }

            if (bookExist(book.title)) {
                throw 'book exist exeption';
            }

            if (book.isbn.length !== 10 && book.isbn.length !== 13) {
                throw 'isbn lenght exeption';
            }

            if (checkIfRepeatingISBNIsFound(book.isbn)) {
                throw 'Error :)';
            }

            if (book.author === '' || book.author === null || book.author === undefined) {
                throw 'book author must not be empty or null or undefined';
            }

            books.push(book);


            if (!checkIfBooksCategoryAlreadyExistInCategorys(book.category)) {
                let category = {
                    "ID": book.ID,
                    "category": book.category
                };

                categories.push(category);
            }

            return book;
        }

        function listCategories() {

            if (books.length == 0) {
                return [];
            }

            if (checkIfAllBooksAreFromOneCategory()) {
                let result = [];
                result.push(books[0].category);
                return result;
            }

            let result = [];

            categories = categories.sort(function(a, b) {
                var keyA = a.ID,
                    keyB = b.ID;
                // Compare the 2 dates
                if (keyA < keyB) return -1;
                if (keyA > keyB) return 1;
                return 0;
            });


            for (c of categories) {
                result.push(c.category);
            }

            return result;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    }());
    return library;
}

module.exports = solve;