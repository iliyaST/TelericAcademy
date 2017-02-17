/* globals module */

function solve() {
    function* idGenerator() {
        let lastId = 0,
            forever = true;

        while (forever) {
            yield(lastId += 1);
        }
    }

    let itemsIdGenerator = idGenerator();

    class Item {
        constructor(description, name) {
            this.id = itemsIdGenerator.next().value;
            this.description = description;
            this.name = name;
        }

        get description() {
            return this._description;
        }
        set description(x) {
            if (typeof x !== 'string') {
                throw Error('Description should be a string');
            }
            if (x === '') {
                throw Error('Description should not be empty');
            }
            this._description = x;
        }

        get name() {
            return this._name;
        }
        set name(name) {
            if (typeof name !== 'string') {
                throw Error('Name should be a string');
            }
            if (name.length < 2 || name.length > 40) {
                throw Error('Name length should be between 2 and 40');
            }
            this._name = name;
        }
    }

    class Book extends Item {
        constructor(description, name, isbn, genre) {
            super(description, name)
            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn() {
            return this._isbn;
        }
        set isbn(x) {
            if (x.length != 10 && x.length != 13) {
                throw Error('invalid lenght');
            }
            if (x.match(/^[0-9]+$/) == null) {
                throw Error('must contain only numbers');
            }

            this._isbn = x;
        }

        get genre() {
            return this._genre;
        }

        set genre(x) {

            if (x == undefined || typeof x != 'string') {
                throw Error('invalid genre');
            }

            if (x.length < 2 || x.length > 40) {
                throw Error('invalid genre');
            }

            this._genre = x;
        }
    }


    class Media extends Item {
        constructor(description, name, duration, rating) {
            super(description, name)
            this.duration = duration;
            this.rating = rating;
        }

        get duration() {
            return this._duration;
        }

        set duration(x) {
            if (typeof x != 'number' || x < 0) {
                throw Error('duration must be a positive number');
            }
            this._duration = x;
        }

        get rating() {
            return this._rating;
        }

        set rating(x) {

            if (typeof x !== 'number' || x > 5 || x < 1) {
                throw Error('x must be between 1 and 5 and must be a number');
            }

            this._rating = x;
        }
    }

    class Catalog {
        constructor(name) {
            this.id = itemsIdGenerator.next().value;
            this.items = [];
        }

        get name() {
            return this._name;
        }

        set name(x) {

            if (x.length < 2 || x.length > 40) {
                throw Error('Genre length should be between 2 and 40');
            }

            this._name = x;
        }

        add(...its) {

            if (its == undefined || its.length == 0) {
                throw Error('Invalid input must pass items');
            }


            if (typeof its[0] != []) {
                for (let i of its) {
                    if (typeof i != 'object') {
                        throw Error('Invalid item found');
                    }
                }

                for (let i of its) {
                    this.items.push(i);
                }
            }

            if (typeof its[0] == []) {
                for (let i of its[0]) {
                    if (typeof i != 'object') {
                        throw Error('Invalid item found');
                    }
                }

                for (let i of its[0]) {
                    this.items.push(i);
                }
            }
        }

        find(options) {

            if (options == undefined || options == null || options == NaN) {
                throw Error('Invalid input');
            }


            if (typeof options == 'number') {

                let result = [];

                for (let item of this.items) {
                    if (options == item.id) {
                        result.push(item);
                    }
                }

                return result;
            }

            let result = [];

            if (options.name == undefined && options.id != undefined && typeof options.id == 'number') {
                for (let item of this.items) {
                    if (item.id == options.id) {
                        result.push(item);
                    }
                }
            }

            if (options.name != undefined && typeof options.name == 'string' && options.id == undefined) {
                for (let item of this.items) {
                    if (item.name == options.name) {
                        result.push(item);
                    }
                }
            }

            if (options.name != undefined && typeof options.name == 'string' &&
                options.id != undefined && typeof options.id == 'number') {
                for (let item of this.items) {
                    if (item.name == options.name && item.id == options.id) {
                        result.push(item);
                    }
                }
            }

            return result;
        }

        search(pattern) {

            if (typeof pattern != 'string' || pattern == undefined || pattern.length < 1) {
                return [];
            }

            let arrayOfItems = [];

            for (let item of this.items) {
                if (item.name.toLowerCase().includes(pattern.toLowerCase()) ||
                    item.description.toLowerCase().includes(pattern.toLowerCase())) {
                    arrayOfItems.push(item);
                }
            }

            return arrayOfItems;
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...books) {

            if (books.length == 0 || books == undefined) {
                throw 'no item passed';
            }

            if (typeof books[0] == []) {

                for (let b of books[0]) {
                    if (!(b instanceof Book)) {
                        throw 'Not a book-like object';
                    }
                }

                return super.add(books[0]);
            }

            for (let b of books) {
                if (!(b instanceof Book)) {
                    throw 'Not a book-like object';
                }
            }

            return super.add(...books);
        }

        getGenres() {
            var arrayOfGenres = new Set();

            for (let book of this.items) {
                arrayOfGenres.add(book.genre.toLowerCase());
            }

            return arrayOfGenres;
        }

        find(options) {

            let result = [];

            if (options.genre != undefined && options.name != undefined && options.id != undefined) {
                for (let item of this.items) {
                    if (item.genre == options.genre &&
                        item.name == options.name &&
                        item.id == options.id) {
                        result.push(item);
                    }
                }

                return result;
            }

            if (options.genre != undefined && options.name != undefined) {
                for (let item of this.items) {
                    if (item.genre == options.genre && item.name == options.name) {
                        result.push(item);
                    }
                }

                return result;
            }

            if (options.genre != undefined && options.id != undefined) {
                for (let item of this.items) {
                    if (item.genre == options.genre && item.id == options.id) {
                        result.push(item);
                    }
                }

                return result;
            }

            if (options.genre != undefined) {
                for (let item of this.items) {
                    if (item.genre == options.genre) {
                        result.push(item);
                    }
                }

                return result;
            }

            return super.find(options);
        }
    }

    class MediaCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...medias) {

            if (medias.length == 0 || medias == undefined) {
                throw 'no item passed';
            }

            if (typeof medias[0] == []) {

                for (let m of medias[0]) {
                    if (!(m instanceof Media)) {
                        throw 'Not a Media-like object';
                    }
                }

                return super.add(medias[0]);
            }

            for (let m of medias) {
                if (!(m instanceof Media)) {
                    throw 'Not a Media-like object';
                }
            }

            return super.add(...medias);
        }

        find(options) {

            let result = [];

            if (options.rating != undefined && options.name != undefined && options.id != undefined) {
                for (let item of this.items) {
                    if (item.rating == options.rating &&
                        item.name == options.name &&
                        item.id == options.id) {
                        result.push(item);
                    }
                }

                return result;
            }

            if (options.rating != undefined && options.name != undefined) {
                for (let item of this.items) {
                    if (item.rating == options.rating && item.name == options.name) {
                        result.push(item);
                    }
                }

                return result;
            }

            if (options.rating != undefined && options.id != undefined) {
                for (let item of this.items) {
                    if (item.rating == options.rating && item.id == options.id) {
                        result.push(item);
                    }
                }

                return result;
            }

            if (options.rating != undefined) {
                for (let item of this.items) {
                    if (item.rating == options.rating) {
                        result.push(item);
                    }
                }

                return result;
            }


            return super.find(options);
        }

        getTop(count) {

            if (typeof count !== 'number') {
                throw 'not a number';
            }

            if (count < 1) {
                throw 'count cant be less than 1';
            }

            let b = 0;

            this.items.sort();

            let result = [];

            for (let i = this.items.length - 1; i >= 0; i -= 1) {

                if (b == count) {
                    return result;
                }

                result.push(this.items[i]);
                b += 1;
            }
        }

        getSortedByDuration() {

            let result = [];

            //Descenging by duration
            for (let i = 0; i < this.items.length - 1; i += 1) {
                for (let j = i + 1; j < this.items.length; j += 1) {
                    if (this.items[j].duration > this.items[i].duration) {
                        let temp = this.items[i];
                        this.items[i] = this.items[j];
                        this.items[j] = temp;
                    }
                }
            }

            //Ascenging by id
            for (let i = 0; i < this.items.length - 1; i += 1) {
                for (let j = i + 1; j < this.items.length; j += 1) {
                    if (this.items[j].id < this.items[i].id) {
                        let temp = this.items[i];
                        this.items[i] = this.items[j];
                        this.items[j] = temp;
                    }
                }
            }

            result = this.items.slice();

            return result;
        }
    }

    return {
        getBook: function(name, isbn, genre, description) {
            return new Book(description, name, isbn, genre);
        },
        getMedia: function(name, rating, duration, description) {
            return new Media(description, name, duration, rating);
        },
        getBookCatalog: function(name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function(name) {
            return new MediaCatalog(name);
        }
    };
}
module.exports = solve;