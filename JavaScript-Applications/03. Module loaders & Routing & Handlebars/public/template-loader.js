const templateLoader = (() => {

    const catche = {};

    function get(templateName) {
        return new Promise((resolve, reject) => {

            if (catche[templateName]) {
                resolve(catche[templateName]);
            } else {
                $.get(`templates/${templateName}.handlebars`)
                    .done((data) => {
                        let template = Handlebars.compile(data);
                        catche[templateName] = template;
                        resolve(template);
                    })
                    .fail(reject);
            }
        })

    }

    return {
        get
    }
})();

export { templateLoader };