LFG.filters.
    filter('showelapsed', function () {
        return function (input) {
            var output = '';
            var now = new Date();
            if (input) {
                var timestamp = new Date(input);
                output = Math.floor((now - timestamp) / 60000);
                
                if (output > 1) {
                    output += ' minutes ago';
                } else {
                    if (output === 1) {
                        output += ' minute ago';
                    } else {
                        output = '< 1 minute ago';
                    }
                }
            }
            return output;
        };
    });