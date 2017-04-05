(function() {
    var myPromise = new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition((pos) => {
            resolve(pos);
        })
    });

    function parsePosition(pos) {
        return {
            lat: pos.coords.latitude,
            long: pos.coords.longtitude
        }
    }

    function displayMap(pos) {
        let img = document.getElementById('theImg');
        img.src = `https://www.google.bg/maps/@${pos.lat},${pos.long},17z?hl=bg`;
    }

    myPromise
        .then(parsePosition)
        .then(displayMap)
}());