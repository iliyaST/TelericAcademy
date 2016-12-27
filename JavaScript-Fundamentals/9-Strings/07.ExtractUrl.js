function solve(args) {
    var url = args[0].split(''),
        inProtocol = false,
        inServer = false,
        protocol = '',
        server = '',
        resource = '',
        index;

    inProtocol = true;
    for (index = 0; index < url.length; index += 1) {
        if (inProtocol) {
            if (url[index] == ':') {
                inProtocol = false;
                inServer = true;
                index += 2;
                continue;
            }
            protocol += url[index];
        }

        if (inServer) {
            if (url[index] == '/') {
                inServer = false;
                index -= 1;
                continue;
            }
            server += url[index];
        }

        if (!inProtocol && !inServer) {
            resource += url[index];
        }
    }

    console.log('protocol: ' + protocol);
    console.log('server: ' + server);
    console.log('resource: ' + resource);

}

// solve(['http://telerikacademy.com/Courses/Courses/Details/239']);