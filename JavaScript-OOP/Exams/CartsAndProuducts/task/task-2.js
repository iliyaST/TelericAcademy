function solve() {


    const VALIDATOR = {
        IS_VALID_STRING: function(x) {
            if (x === undefined || x === NaN || typeof x !== 'string') {
                throw Error('invalid string');
            }
        },
        IS_VALID_NUMBER: function(x) {
            if (x === undefined || x === NaN || typeof x !== 'number') {
                throw Error('invalid number');
            }
        },
        IS_VALID_PRODUCT: function(product) {
            if (typeof product != 'object') {
                throw Error('invalid product');
            }
        }
    };


    class Product {
        constructor(productType, name, price) {
            this.productType = productType;
            this.name = name;
            this.price = price;
        }

        get productType() {
            return this._productType;
        }

        set productType(x) {

            VALIDATOR.IS_VALID_STRING(x);
            this._productType = x;
        }

        get name() {
            return this._name;
        }

        set name(x) {

            VALIDATOR.IS_VALID_STRING(x);

            this._name = x;
        }

        get price() {
            return this._price;
        }

        set price(x) {

            VALIDATOR.IS_VALID_NUMBER(x);
            this._price = x;
        }
    }

    class ShoppingCart {
        constructor() {
            this.products = [];
        }


        add(product) {

            VALIDATOR.IS_VALID_PRODUCT(product);


            if (!(Object.keys(product).every(key => product[key] != undefined))) {
                throw Error('invalid');
            }

            this.products.push(product);

            return this;
        }

        remove(product) {

            VALIDATOR.IS_VALID_PRODUCT(product);

            let productA = new Product(product.productType, product.name, product.price);

            const index = this.products.findIndex(p => p.name === productA.name && p.productType === productA.productType && p.price === productA.price);

            if (index < 0) {
                throw 'Product not found';
            }

            this.products.splice(index, 1);

            return this;
        }

        showCost() {
            let sum = 0;

            this.products.forEach(x => sum += x.price);

            return sum;
        }

        showProductTypes() {

            let uniqP = {};

            this.products.forEach(x => uniqP[x.productType] = true);

            return Object.keys(uniqP).sort((a, b) => a > b);

        }

        getInfo() {

            let uniqN = {};

            this.products.forEach(x => uniqN[x.name] = true);

            let groupedByNameProducts = [];

            Object.keys(uniqN).forEach(uN => groupedByNameProducts.push(this.products.filter(p => p.name == uN)));

            let finalArrayOfGroupedObjects = [];

            for (let ar of groupedByNameProducts) {

                let resultArray = [];
                let resultObj = { name: ar[0].name };
                let totalP = 0;
                let totalQ = 0;

                for (let p of ar) {
                    totalP += p.price;
                    totalQ += 1;
                }

                resultObj.totalPrice = totalP;
                resultObj.quantity = totalQ;

                finalArrayOfGroupedObjects.push(resultObj);
            }

            let finalSum = 0;
            this.products.forEach(x => finalSum += x.price);

            return {
                totalPrice: finalSum,
                products: finalArrayOfGroupedObjects.sort((a, b) => a.name > b.name)
            }
        }
    }

    return {
        Product,
        ShoppingCart
    };
}

module.exports = solve;