var LFG = LFG || {};

LFG.app = angular.module('LFG', ['LFGCtrl', 'LFGDir', 'LFGFilters', 'LFGServices']);
LFG.controllers = angular.module('LFGCtrl', ['ngGrid']);
LFG.directives = angular.module('LFGDir', []);
LFG.filters = angular.module('LFGFilters', []);
LFG.services = angular.module('LFGServices', []);

$(document).ready({
    
});