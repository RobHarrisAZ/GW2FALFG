LFG.directives.
    directive('editlink', function() {
        return {
            replace: true,
            link: function(scope, element, attrs) {
                if (scope.userGuid != scope.row.getProperty('UserGuid')) {
                    element.addClass('hide');
                }
            }
        };
    });