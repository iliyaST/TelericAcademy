(function() {
    var myPromise = new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition((pos) => {
            resolve(pos);
        })
    });

    function parsePosition(pos) {
        return {
            lat: pos.coords.latitude,
            lon: pos.coords.longitude
        }
    }

    function displayMap(pos) {
        let img = document.getElementById('theImg');
        img.src =  "http://maps.googleapis.com/maps/api/staticmap?center=" + pos.lat + "," + pos.lon + "&zoom=13&size=500x500&sensor=false";
    }

    myPromise
        .then(parsePosition)
        .then(console.log)
}());