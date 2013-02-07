LFG.filters.
    filter('spshow', function () {
        return function (input) {
            var output = '';
            if (input === true) {
                output = 'icon-fast-forward';
            }
            return output;
        };
    });