function solve() {

    const VALIDATOR = {
        IS_VALID_STRING: function(x) {
            if (x == undefined || x == NaN || typeof x !== 'string') {
                throw Error('invalid string');
            }
        },
        IS_VALID_NUMBER: function(x) {
            if (x == undefined || x == NaN || typeof x !== 'number') {
                throw Error('invalid number');
            }
        },
        IS_IN_RANGE: function(x, min, max) {
            if (x < min || x > max) {
                throw Error('not in range');
            }
        },
        CONTAINS_ONLY_VALID_LETTERS: function(x) {
            let pattern = /([A-Za-z0-9\s])+/g;

            if (!pattern.test(x)) {
                throw Error('invalid');
            }
        }
    }



    class App {
        constructor(name, description, version, rating) {
            this.name = name;
            this.description = description;
            this.version = version;
            this.rating = rating;
        }

        get name() {
            return this._name;
        }

        set name(x) {

            VALIDATOR.IS_VALID_STRING(x);
            VALIDATOR.IS_IN_RANGE(x.length, 1, 24);
            VALIDATOR.CONTAINS_ONLY_VALID_LETTERS(x);

            this._name = x;
        }

        get description() {
            return this._description;
        }

        set description(x) {
            VALIDATOR.IS_VALID_STRING(x);
            this._description = x;
        }

        get version() {
            return this._version;
        }

        set version(x) {

            VALIDATOR.IS_VALID_NUMBER(x);

            if (x < 0) {
                throw Error('must be positive version');
            }

            this._version = x;
        }

        get rating() {
            return this._rating;
        }

        set rating(x) {

            VALIDATOR.IS_VALID_NUMBER(x);

            VALIDATOR.IS_IN_RANGE(x, 1, 10);

            this._rating = x;
        }

        release(optionsOrVersion) {

            if (optionsOrVersion == undefined || optionsOrVersion == NaN) {
                throw Error('invalid');
            }

            if (typeof optionsOrVersion !== 'number' && typeof optionsOrVersion !== 'object') {
                throw Error('invalid');
            }

            if (typeof optionsOrVersion === 'number') {
                optionsOrVersion = {
                    version: optionsOrVersion
                };
            }

            if (optionsOrVersion.version == undefined || optionsOrVersion.version == NaN) {
                throw Error('invalid');
            }

            if (optionsOrVersion.description != undefined && optionsOrVersion.description != NaN) {
                this.description = optionsOrVersion.description;
            }

            if (optionsOrVersion.rating != undefined && optionsOrVersion.rating != NaN) {
                this.rating = optionsOrVersion.rating;
            }

            if (optionsOrVersion.version <= this.version) {
                throw Error('invalid lower version');
            }

            this.version = optionsOrVersion.version;

            return this;
        }
    }

    class Store extends App {
        constructor(name, description, version, rating) {
            super(name, description, version, rating);

            this.apps = [];
        }

        uploadApp(app) {

            let a = new App(app.name, app.description, app.version, app.rating);

            if (!(a instanceof App)) {
                throw Error('not an app');
            }

            let index = this.apps.findIndex(x => x.name == app.name);

            if (index < 0) {
                this.apps.push(a);
            } else {
                this.apps[index].release(a);
                this.apps.push(this.apps[index]);
                this.apps.splice(index, 1);
            }

            return this;
        }

        takedownApp(name) {

            let index = this.apps.findIndex(x => x.name == name);

            if (index < 0) {
                throw Error('not found');
            }

            this.apps.splice(index, 1);

            return this;
        }

        search(pattern) {
            return this.apps.filter(x => x.name.toLowerCase().includes(pattern.toLowerCase()))
                .sort((a, b) => a.name.toLowerCase() > b.name.toLowerCase());
        }

        listMostRecentApps(count) {

            if (count == undefined || count == NaN) {
                count = 10;
            }

            let result = [];

            this.apps.forEach(x => result.push(x));

            return result.reverse().slice(0, count);
        }

        listMostPopularApps(count) {

            if (count == undefined || count == NaN) {
                count = 10;
            }

            let result = this.apps.slice();

            result.reverse();

            result.sort((a, b) => b.rating - a.rating);

            return result.slice(0, count);
        }
    }

    class Device {
        constructor(hostname, apps) {

            this.hostname = hostname;

            if (!Array.isArray(apps)) {
                throw Error('not an array');
            }

            if (!(apps.every(x => x instanceof Store || x instanceof App))) {
                throw Error("invalid apps");
            }

            this._apps = apps;

            this._apps.forEach((app, i) => {
                if (!(app instanceof Store)) {
                    let a = new App(app.name, app.description, app.version, app.rating);
                    this._apps[i] = a;
                }
            });
        }

        get apps() {
            return this._apps;
        }

        get hostname() {
            return this._hostname;
        }

        set hostname(x) {

            VALIDATOR.IS_VALID_STRING(x);

            VALIDATOR.IS_IN_RANGE(x.length, 1, 32);

            this._hostname = x;
        }
        search(pattern) {

            let stores = this.apps.filter(x => x instanceof Store);

            let arrayOfApps = [];

            stores.forEach(store => {
                store.apps.forEach(app => {
                    if (app.name.toLowerCase().includes(pattern.toLowerCase())) {
                        arrayOfApps.push(app);
                    }
                });
            });

            let uniq = {};

            arrayOfApps.forEach(app => uniq[app.name] = true);

            let getLatestApps = [];

            Object.keys(uniq).forEach(uniqName => {

                let currentApps = arrayOfApps.filter(x => x.name == uniqName);
                let latestVersion = -1;
                let latestApp = -1;

                currentApps.forEach((cApp, i) => {
                    if (cApp.version > latestVersion) {
                        latestVersion = cApp.version;
                        latestApp = cApp;
                    }
                });

                getLatestApps.push(latestApp);
            });

            return getLatestApps.sort((a, b) => a.name > b.name);
        }

        install(name) {

            let stores = this.apps.filter(x => x instanceof Store)

            if (stores.every(store => store.apps.every(app => app.name != name))) {
                throw Error('not available');
            }

            if ((this.apps.find(app => app.name == name)) == undefined) {

                let allAppsWithThisName = [];

                stores.forEach(store => {
                    store.apps.forEach(app => {
                        if (app.name == name) {
                            allAppsWithThisName.push(app);
                        }
                    });
                });

                let latestVersion = -1;
                let latestApp = -1;

                allAppsWithThisName.forEach(ap => {
                    if (ap.version > latestVersion) {
                        latestVersion = ap.version;
                        latestApp = ap;
                    }
                });

                this.apps.push(latestApp);
            }

            return this;
        }

        uninstall(name) {

            let index = this.apps.findIndex(x => x.name == name);

            if (index < 0) {
                throw Error('Such app is not found');
            }

            this.apps.splice(index, 1);

            return this;
        }

        listInstalled() {
            let result = this.apps.slice();

            return result.sort((a, b) => a.name > b.name);
        }

        update() {

            let installedApps = this.apps.filter(x => !(x instanceof Store));
            let installedStores = this.apps.filter(x => x instanceof Store);

            installedApps.forEach(app => {
                installedStores.forEach(store => {
                    store.apps.forEach(stApp => {
                        if (app.name == stApp.name && app.version < stApp.version) {

                            app.version = stApp.version;
                            app.description = stApp.description;
                            app.rating = stApp.rating;
                        }
                    });
                });
            });

            return this;
        }
    }

    return {
        createApp(name, description, version, rating) {
            return new App(name, description, version, rating);
        },
        createStore(name, description, version, rating) {
            return new Store(name, description, version, rating);
        },
        createDevice(hostname, apps) {
            return new Device(hostname, apps);
        }
    };
}

// Submit the code above this line in bgcoder.com
module.exports = solve;