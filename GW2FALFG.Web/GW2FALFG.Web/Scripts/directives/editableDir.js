LFG.directives.
    directive('editlink', function() {
        return {
            replace: true,
            //template: '<input id="edit{{groupRequest}}" type=\"button\" ng-click=\"editGroup({{groupRequest}})\" class=\"btn btn-inverse\" value=\"Edit\"/>',
            link: function(scope, element, attrs) {
                if (scope.userGuid != scope.row.getProperty('UserGuid')) {
                    element.addClass('hide');
                }
            }
        };
    });