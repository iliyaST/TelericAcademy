let element = document.getElementById('popup');
let redirectSiteURl = 'http://google.bg';

(function() {
    let myPromise = new Promise((resolve, reject) => {
        resolve(document.getElementById('popup'));
    });

    function wait(time, element) {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(element);
            }, time);
        });
    }

    function popUpDiv(element) {
        element.style.display = 'block';
        return element;
    }

    function redirect(element) {
        window.location = redirectSiteURl;
    }

    myPromise
        .then(element => wait(2000, element))
        .then(popUpDiv)
        .then(element => wait(5000, element))
        .then(redirect);

}());