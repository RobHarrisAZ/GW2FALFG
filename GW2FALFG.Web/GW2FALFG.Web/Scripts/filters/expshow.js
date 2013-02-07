LFG.filters.
    filter('expshow', function() {
        return function(input) {
            var output = '';
            if (input === true) {
                output = 'icon-star';
            }
            return output;
        };
    });