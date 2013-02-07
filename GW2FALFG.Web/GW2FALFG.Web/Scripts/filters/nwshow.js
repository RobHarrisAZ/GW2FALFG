LFG.filters.
    filter('nwshow', function () {
        return function (input) {
            var output = '';
            if (input === true) {
                output = 'icon-question-sign';
            }
            return output;
        };
    });