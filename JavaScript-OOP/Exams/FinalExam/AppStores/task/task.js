function solve() {

    const VALIDATOR = {
        IT_IS_VALID_STRING: function(x) {
            if (x == undefined || x == NaN || typeof x != 'string') {
                throw Error('invalid string');
            }
        },
        Check_If_It_Is_In_Range: function(x, min, max) {
            if (x < min || x > max) {
                throw Error('invalid');
            }
        },
        IT_IS_VALID_NUMBER: function(x) {
            if (x == undefined || x == NaN || typeof x != 'number') {
                throw Error('invalid number');
            }
        },
        Check_If_IT_Matches_Pattern: function(x) {

            let pattern = /([A-Za-z0-9\s])+/g;

            if (!pattern.test(x)) {
                throw Error('Must contain ony latin letters and space');
            }
        },
        Check_If_IS_Valid_Array: function(x) {
            if (x == undefined || x == NaN || typeof x != 'object' || x.constructor !== Array) {
                throw Error('invalid element must be array');
            }
        },
        Check_If_IS_Valid_Array_Contains_Apps(x) {
            let test = new App('validName', 'asfjasjifasij', 2, 4);

            for (let e of x) {
                if (!(e instanceof Store) && (!(e instanceof App))) {
                    throw Error('invalid');
                }
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

            VALIDATOR.IT_IS_VALID_STRING(x);
            VALIDATOR.Check_If_It_Is_In_Range(x.length, 2, 23);
            VALIDATOR.Check_If_IT_Matches_Pattern(x);

            this._name = x;
        }

        get description() {
            return this._description;
        }

        set description(x) {

            VALIDATOR.IT_IS_VALID_STRING(x);

            this._description = x;
        }

        get version() {
            return this._version;
        }

        set version(x) {

            VALIDATOR.IT_IS_VALID_NUMBER(x);

            if (x < 0) {
                throw Error('must be a positive number');
            }

            this._version = x;
        }

        get rating() {
            return this._rating;
        }

        set rating(x) {

            VALIDATOR.IT_IS_VALID_NUMBER(x);

            VALIDATOR.Check_If_It_Is_In_Range(x, 1, 10);

            this._rating = x;
        }

        release(version) {

            if (version == undefined || version == NaN) {
                throw Error('invalid input');
            }

            if (typeof version != 'number' && typeof version != 'object') {
                throw Error('invali input');
            }

            if (typeof version == 'number') {
                version = {
                    version: version
                }
            }

            VALIDATOR.IT_IS_VALID_NUMBER(version.version);

            if (version.version == undefined || version.version < 0 || version.version == NaN) {
                throw Error('invalid');
            }

            if (version.description != undefined) {
                this.description = version.description;
            }

            if (version.rating != undefined) {
                this.rating = version.rating;
            }

            if (version.version <= this.version) {
                throw Error('version is not above old one');
            }

            this.version = version.version;
        }
    }


    class Store extends App {
        constructor(name, description, version, rating) {
            super(name, description, version, rating);

            this.apps = [];
        }

        uploadApp(app) {

            if (app == undefined || app == NaN ||
                (!(app instanceof App))) {
                throw Error('invalid App');
            }

            let index = this.apps.findIndex(x => x.name == app.name);

            if (index < 0) {
                this.apps.push(app);
            } else {
                this.apps[index].release(app);
            }

            return this;
        }

        takedownApp(name) {

            let index = this.apps.findIndex(x => x.name == name);

            if (index < 0) {
                throw Error('app not found');
            }

            this.apps.splice(index, 1);

            return this;
        }

        search(pattern) {
            return this.apps.filter(x => x.name.toLowerCase().includes(pattern.toLowerCase()))
                .sort((a, b) => a.name.toLowerCase() > b.name.toLowerCase());
        }

        listMostRecentApps(count) {

            if (count == undefined) {
                count = 10;
            }

            let result = [];

            for (let i = this.apps.length - 1; i >= 0; i -= 1) {
                result.push(this.apps[i]);
            }

            return result.slice(0, count);
        }

        listMostPopularApps(count) {
            if (count == undefined) {
                count = 10;
            }

            let result = [];

            for (let i = this.apps.length - 1; i >= 0; i -= 1) {
                result.push(this.apps[i]);
            }

            result.sort((a, b) => a.rating < b.rating);

            return result.slice(0, count);
        }
    }

    class Device {
        constructor(hostname, apps) {
            this.hostname = hostname;
            this.apps = apps;
        }

        get hostname() {
            return this._hostname;
        }

        set hostname(x) {

            VALIDATOR.IT_IS_VALID_STRING(x);

            VALIDATOR.Check_If_It_Is_In_Range(x.length, 2, 31);

            this._hostname = x;
        }


        get apps() {
            return this._apps;
        }

        set apps(x) {

            VALIDATOR.Check_If_IS_Valid_Array(x);

            VALIDATOR.Check_If_IS_Valid_Array_Contains_Apps(x);

            this._apps = x;
        }

        search(pattern) {

            let stores = this.apps.filter(x => x instanceof Store);
            let appsContainingPattern = [];

            for (let s of stores) {
                for (let app of s.apps) {
                    if (app.name.toLowerCase().includes(pattern.toLowerCase())) {
                        appsContainingPattern.push(app);
                    }
                }
            }

            for (let i = 0; i < appsContainingPattern.length; i += 1) {

                let currentApp = appsContainingPattern[i];
                for (let j = i + 1; j < appsContainingPattern.length; j += 1) {
                    if (currentApp.name == appsContainingPattern[j].name &&
                        appsContainingPattern[j].version > currentApp.version) {
                        appsContainingPattern.splice(i, 1);
                        i = -1;
                        break;
                    }
                }
            }

            appsContainingPattern.sort((a, b) => a.name > b.name);

            return appsContainingPattern;
        }

        install(name) {

            let latestV = -14;
            let latestApp = -14;

            let installedApps = this.apps.filter(x => !(x instanceof Store));

            if ((installedApps.find(x => x.name == name)) == undefined) {

                let stores = this.apps.filter(x => x instanceof Store);

                if (stores.every(store => store.apps.every(app => app.name != name))) {
                    throw Error('unavabable');
                }


                for (let s of stores) {
                    for (let a of s.apps) {
                        if (a.name == name && latestV < a.version) {
                            latestV = a.version;
                            latestApp = a;
                        }
                    }
                }

                this.apps.push(latestApp);
            }

            return this;
        }

        uninstall(name) {

            let i = this.apps.findIndex(x => x.name == name);

            if (i < 0) {
                throw Error('not found');
            }

            this.apps.splice(i, 1);

            return this;
        }

        listInstalled() {

            let installedApps = this.apps.filter(x => !(x instanceof Store));

            return installedApps.sort((a, b) => a.name.toLowerCase() > b.name.toLowerCase());
        }

        update() {

            let installedApps = this.apps.filter(x => !(x instanceof Store));
            let installedStores = this.apps.filter(x => x instanceof Store);

            for (let app of installedApps) {
                for (let store of installedStores) {
                    for (let a of store.apps) {
                        if (a.name == app.name && a.version > app.version) {
                            app.version = a.version;
                        }
                    }
                }
            }

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

module.exports = solve;

// let engine = solve();

// let st1 = engine.createStore('Store1', 'agijasijgasijg', 4, 5);
// let ap = engine.createApp('app1 ist the worst', 'agijasijgasijg', 4, 5);
// let ap2 = engine.createApp('app2app1', 'agijasijgasijg', 4, 5);
// let ap3 = engine.createApp('app3', 'agijasijgasijg', 4, 5);
// st1.uploadApp(ap).uploadApp(ap2).uploadApp(ap3);
// let st2 = engine.createStore('Store2', 'agijasijgasijg', 4, 5);
// let ap4 = engine.createApp('app1 ist the worst', 'agijasijgasijg', 10, 5);
// let ap15 = engine.createApp('ThisApp1', 'agijasijgasijg', 10, 5);
// st1.uploadApp(ap4);
// st1.uploadApp(ap15);
// console.log(st1.search('app1'));
// let ap5 = engine.createApp('app2app1', 'agijasijgasijg', 10, 5);
// let ap6 = engine.createApp('app3', 'agijasijgasijg', 10, 5);
// st2.uploadApp(ap4).uploadApp(ap5).uploadApp(ap6);
// let st3 = engine.createStore('Store3', 'agijasijgasijg', 4, 5);
// let ap7 = engine.createApp('app1 ist the worst', 'agijasijgasijg', 15, 5);
// let ap8 = engine.createApp('app2app1', 'agijasijgasijg', 15, 5);
// let ap9 = engine.createApp('app9', 'agijasijgasijg', 10, 5);
// let ap66 = engine.createApp('app3', 'agijasijgasijg', 35, 5);
// st3.uploadApp(ap7).uploadApp(ap8).uploadApp(ap9).uploadApp(ap66);
// console.log(st1.apps);
// let device = engine.createDevice('NaBABAHosta', [st1, st2, st3, ap3])
// device.search('app1');
// device.install('app3');
// device.update();