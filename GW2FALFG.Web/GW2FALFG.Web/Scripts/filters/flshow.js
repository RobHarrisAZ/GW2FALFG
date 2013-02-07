LFG.filters.
    filter('flshow', function () {
        return function (input) {
            var output = '';
            if (input === true) {
                output = 'icon-film';
            }
            return output;
        };
    });