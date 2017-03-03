function solve() {

    const getNextId = (function() {
        let counter = 0;
        return function() {
            counter += 1;
            return counter;
        };
    })();

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

    class Product {
        constructor(manufacturer, model, price) {
            this.id = getNextId();
            this.manufacturer = manufacturer;
            this.model = model;
            this.price = price;
        }

        get manufacturer() {
            return this._manufacturer;
        }

        set manufacturer(x) {

            VALIDATOR.IS_VALID_STRING(x);
            VALIDATOR.IS_IN_RANGE(x.length, 1, 20);

            this._manufacturer = x;
        }

        get model() {
            return this._model;
        }

        set model(x) {

            VALIDATOR.IS_VALID_STRING(x);
            VALIDATOR.IS_IN_RANGE(x.length, 1, 20);

            this._model = x;
        }

        get price() {
            return this._price;
        }

        set price(x) {

            VALIDATOR.IS_VALID_NUMBER(x);

            if (x <= 0) {
                throw Error('price must be positive non-zero number');
            }

            this._price = x;
        }

        getLabel() {

        }
    }

    class SmartPhone extends Product {
        constructor(manufacturer, model, price, screenSize, operatingSystem) {
            super(manufacturer, model, price);
            this.screenSize = screenSize;
            this.operatingSystem = operatingSystem;
        }

        get screenSize() {
            return this._screenSize;
        }

        set screenSize(x) {

            VALIDATOR.IS_VALID_NUMBER(x);
            if (x <= 0) {
                throw Error('screenSize must be positive non-zero number');
            }

            this._screenSize = x;
        }

        get operatingSystem() {
            return this._operatingSystem;
        }

        set operatingSystem(x) {

            VALIDATOR.IS_VALID_STRING(x);
            VALIDATOR.IS_IN_RANGE(x.length, 1, 10);

            this._operatingSystem = x;
        }

        getLabel() {

            return 'SmartPhone - ' + this.manufacturer + ' ' + this.model + ' -' + ' **' + this.price + '**';
        }
    }

    class Charger extends Product {
        constructor(manufacturer, model, price, outputVoltage, outputCurrent) {
            super(manufacturer, model, price);
            this.outputVoltage = outputVoltage;
            this.outputCurrent = outputCurrent;
        }

        get outputVoltage() {
            return this._outputVoltage;
        }

        set outputVoltage(x) {

            VALIDATOR.IS_VALID_NUMBER(x);
            VALIDATOR.IS_IN_RANGE(x, 5, 20);

            this._outputVoltage = x;
        }

        get outputCurrent() {
            return this._outputCurrent;
        }

        set outputCurrent(x) {

            VALIDATOR.IS_VALID_NUMBER(x);
            VALIDATOR.IS_IN_RANGE(x, 100, 3000);

            this._outputCurrent = x;
        }

        getLabel() {
            return 'Charger - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';
        }
    }

    class Router extends Product {
        constructor(manufacturer, model, price, wifiRange, lanPorts) {
            super(manufacturer, model, price);
            this.wifiRange = wifiRange;
            this.lanPorts = lanPorts;
        }


        get wifiRange() {
            return this._wifiRange;
        }

        set wifiRange(x) {

            VALIDATOR.IS_VALID_NUMBER(x);
            if (x <= 0) {
                throw Error('wifiRange must be positive non-zero number');
            }

            this._wifiRange = x;
        }


        get lanPorts() {
            return this._lanPorts;
        }

        set lanPorts(x) {

            VALIDATOR.IS_VALID_NUMBER(x);
            if (x <= 0 || !Number.isInteger(x)) {
                throw Error('lanPorts must be positive non-zero number');
            }

            this._lanPorts = x;
        }
        getLabel() {
            return 'Router - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';
        }
    }

    class Headphones extends Product {
        constructor(manufacturer, model, price, quality, hasMicrophone) {
            super(manufacturer, model, price);
            this.quality = quality;
            this.hasMicrophone = hasMicrophone;
        }


        get quality() {
            return this._quality;
        }

        set quality(x) {

            if (x !== 'high' && x != 'mid' && x !== 'low') {
                throw Error('invalid quality');
            }

            this._quality = x;
        }


        get hasMicrophone() {
            return this._hasMicrophone;
        }

        set hasMicrophone(x) {
            if (x) {
                this._hasMicrophone = true;
            } else {
                this._hasMicrophone = false;
            }
        }
        getLabel() {
            return 'Headphones - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';
        }
    }

    class HardwareStore {
        constructor(name) {
            this.name = name;
            this.products1 = [];
            this.products = [];
            this._totalCash = 0;
        }

        get name() {
            return this._name;
        }

        set name(x) {

            VALIDATOR.IS_VALID_STRING(x);
            VALIDATOR.IS_IN_RANGE(x.length, 1, 20);

            this._name = x;
        }

        stock(product, quantity) {

            if (!(product instanceof Product)) {
                throw Error('stock() invalid product');
            }

            VALIDATOR.IS_VALID_NUMBER(quantity);

            if (quantity <= 0 || !Number.isInteger(quantity)) {
                throw Error('stock() invalid quantity');
            }

            let index = this.products1.findIndex(x => x.product.id == product.id);

            if (index < 0) {
                this.products1.push({ product, quantity });
                this.products.push(product);
            } else {
                this.products1[index].quantity += quantity;
            }

            return this;
        }

        sell(productId, quantity) {

            if (quantity <= 0 || !Number.isInteger(quantity)) {
                throw Error('stock() invalid quantity');
            }

            let index = this.products1.findIndex(x => x.product.id == productId);

            if (index < 0) {
                throw Error('product not found');
            }

            if (this.products1[index].quantity < quantity) {
                throw Error('quantity is less');
            }

            this._totalCash += this.products1[index].product.price * quantity;

            if (this.products1[index].quantity - quantity == 0) {
                this.products1.splice(index, 1);
                this.products.splice(index, 1);
            } else {
                this.products1[index].quantity = this.products1[index].quantity - quantity;
            }

            return this;
        }

        getSold() {
            return this._totalCash;
        }

        search(pattern) {

            if (pattern == undefined || pattern == NaN) {
                throw Error('invali pattern');
            }

            if (typeof pattern === 'string') {

                let result = this.products1.filter(el => (el.product.model.toLowerCase().includes(pattern.toLowerCase()) ||
                    el.product.manufacturer.toLowerCase().includes(pattern.toLowerCase())));

                return result;
            } else if (typeof pattern === 'object') {

                let result = [];

                if (pattern.manufacturerPattern != undefined && typeof pattern.manufacturerPattern === 'string') {
                    result = this.products1.filter(el => el.product.manufacturer.includes(pattern.manufacturerPattern));
                }

                if (result.length == 0) {
                    if (pattern.modelPattern != undefined && typeof pattern.modelPattern === 'string') {
                        result = this.products1.filter(el => el.product.model.includes(pattern.modelPattern));
                    }
                } else {
                    if (pattern.modelPattern != undefined && typeof pattern.modelPattern === 'string') {
                        result = result.filter(el => el.product.model.includes(pattern.modelPattern));
                    }
                }

                if (result.length != 0) {
                    if (pattern.type === 'SmartPhone' || pattern.type === 'Charger' ||
                        pattern.type === 'Router' || pattern.type === 'Headphones') {

                        if (pattern.type === 'SmartPhone') {
                            result = result.filter(el => el.product instanceof SmartPhone);
                        }

                        if (pattern.type === 'Charger') {
                            result = result.filter(el => el.product instanceof Charger);
                        }

                        if (pattern.type === 'Router') {
                            result = result.filter(el => el.product instanceof Router);
                        }

                        if (pattern.type === 'Headphones') {
                            result = result.filter(el => el.product instanceof Headphones);
                        }
                    }
                } else {
                    if (pattern.type === 'SmartPhone' || pattern.type === 'Charger' ||
                        pattern.type === 'Router' || pattern.type === 'Headphones') {

                        if (pattern.type === 'SmartPhone') {
                            result = this.products1.filter(el => el.product instanceof SmartPhone);
                        }

                        if (pattern.type === 'Charger') {
                            result = this.products1.filter(el => el.product instanceof Charger);
                        }

                        if (pattern.type === 'Router') {
                            result = this.products1.filter(el => el.product instanceof Router);
                        }

                        if (pattern.type === 'Headphones') {
                            result = this.products1.filter(el => el.product instanceof Headphones);
                        }
                    }
                }

                if (result.length != 0) {
                    if (pattern.minPrice !== undefined && typeof pattern.minPrice === 'number') {
                        result = result.filter(el => el.product.price >= pattern.minPrice);
                    }
                } else {
                    if (pattern.minPrice !== undefined && typeof pattern.minPrice === 'number') {
                        result = this.products1.filter(el => el.product.price >= pattern.minPrice);
                    }
                }


                if (result.length != 0) {
                    if (pattern.maxPrice !== undefined && typeof pattern.maxPrice === 'number') {
                        result = result.filter(el => el.product.price <= pattern.maxPrice);
                    }
                } else {
                    if (pattern.maxPrice !== undefined && typeof pattern.maxPrice === 'number') {
                        result = this.products1.filter(el => el.product.price <= pattern.maxPrice);
                    }
                }

                return result;
            } else {
                throw Error('invalid');
            }
        }
    }

    return {
        getSmartPhone(manufacturer, model, price, screenSize, operatingSystem) {
            return new SmartPhone(manufacturer, model, price, screenSize, operatingSystem);
        },
        getCharger(manufacturer, model, price, outputVoltage, outputCurrent) {
            return new Charger(manufacturer, model, price, outputVoltage, outputCurrent);
        },
        getRouter(manufacturer, model, price, wifiRange, lanPorts) {
            return new Router(manufacturer, model, price, wifiRange, lanPorts);
        },
        getHeadphones(manufacturer, model, price, quality, hasMicrophone) {
            return new Headphones(manufacturer, model, price, quality, hasMicrophone);
        },
        getHardwareStore(name) {
            return new HardwareStore(name);
        }
    };
}

module.exports = solve;

const result = solve();

const products = [
    result.getSmartPhone('HTC', 'One M8', 42, 5, 'Android'),
    result.getCharger('Pesho', 'Gosho', 20, 19, 1000),
    result.getRouter('Gosho', 'Pesho', 80, 30, 5),
    result.getHeadphones('Sennheiser', 'HD 598', 340, 'high', false),
    result.getSmartPhone('alabala', 'Pesho', 42, 5, 'Android'),
    result.getSmartPhone('PesHo', 'alabala', 42, 5, 'Android'),
];

const store = result.getHardwareStore('Technomarket');
products.forEach((p, i) => store.stock(p, i * 17 + 13));

let expectedIDs = [products[1].id, products[2].id, products[4].id].sort();
let expectedQuantities = [17 + 13, 2 * 17 + 13, 4 * 17 + 13].sort();

let actual = store.search({ modelPattern: 'sh' });

expectedIDs = [products[1].id, products[2].id].sort();
expectedQuantities = [17 + 13, 2 * 17 + 13].sort();

actual = store.search({ manufacturerPattern: 'sh' });

expectedIDs = [products[0].id, products[4].id, products[5].id].sort();
expectedQuantities = [13, 4 * 17 + 13, 5 * 17 + 13].sort();

actual = store.search({ type: 'SmartPhone' });

expectedIDs = [products[2].id, products[3].id].sort();
expectedQuantities = [2 * 17 + 13, 3 * 17 + 13].sort();

actual = store.search({ minPrice: 64 });

expectedIDs = [products[0].id, products[1].id, products[4].id, products[5].id].sort();
expectedQuantities = [13, 17 + 13, 4 * 17 + 13, 5 * 17 + 13].sort();

actual = store.search({ maxPrice: 64 });

expectedIDs = [products[0].id, products[4].id, products[5].id].sort();
expectedQuantities = [13, 4 * 17 + 13, 5 * 17 + 13].sort();

actual = store.search({ minPrice: 40, maxPrice: 44 });

actual = store.search({ minPrice: 70, type: 'Charger' });