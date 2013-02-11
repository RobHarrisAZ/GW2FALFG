LFG.controllers.controller('LFGCtrl', ['$scope', '$http', '$routeParams', 'CookieService', function ($scope, $http, $routeParams, CookieService) {
    var groupRequestId = $routeParams.id,
        getAllGroupRequests = function() {
            console.log('fetching all groups');
            $http.get('/api/group/', { cache: false }).success(function(response) {
                $scope.groupRequestsAll = response;
            });
        },
        purgeOldData = function() {
            console.log('purging old records');
            $http.delete('/api/group/').success(function(response) {
            });
        },
        getGroupRequestsByEvent = function(event) {
            $http.get('/api/group/GetByEventName' + event).success(function(response) {
                $scope.groupRequestsAll = response;
            });
        },
        getByLanguage = function(language) {
            $http.get('/api/group/GetByLanguagePref/' + language).success(function(response) {
                $scope.groupRequestsAll = response;
            });
        },
        getByUser = function(user) {
            $http.get('/api/group/GetByUser/' + user).success(function(response) {
                $scope.groupRequestsAll = response;
            });
        },
        getEvents = function() {
            $http.get('/api/event/').success(function(response) {
                $scope.events = response;
            });
        },
        getLanguages = function() {
            $http.get('/api/language/').success(function(response) {
                $scope.languages = response;
            });
        },
        getGroupRequestById = function(id) {
            $http.get('/api/group/' + id).success(function(response) {
                $scope.request = response;
                if ($scope.request.UserGuid === CookieService.getCookie('userGuid')) {
                    if (!$scope.events) {
                        getEvents();
                    }
                    if (!$scope.languages) {
                        getLanguages();
                    }
                    $scope.viewUrl = 'views/editgroup.html';
                }
            });
        },
        createUuid = function() {
            var s = [];
            var hexDigits = "0123456789abcdef";
            for (var i = 0; i < 36; i++) {
                s[i] = hexDigits.substr(Math.floor(Math.random() * 0x10), 1);
            }
            s[14] = "4"; // bits 12-15 of the time_hi_and_version field to 0010
            s[19] = hexDigits.substr((s[19] & 0x3) | 0x8, 1); // bits 6-7 of the clock_seq_hi_and_reserved to 01
            s[8] = s[13] = s[18] = s[23] = "-";

            var uuid = s.join("");
            return uuid;
        },
        initRequest = function() {
            $scope.request = {
                GroupRequestId: 0,
                LanguagePreference: 'English',
                ExperiencedOnlyFl: false,
                FullRunFl: false,
                SpeedRunFl: false,
                NewToDungeonFl: false
            };
        };

    //Handle User ID
    $scope.userGuid = CookieService.getCookie('userGuid');
    if (!$scope.userGuid) {
        $scope.userGuid = createUuid();
        var expDate = new Date(new Date().getTime() + CookieService.daysToMs(7));
        CookieService.setCookie('userGuid', $scope.userGuid, expDate);
    }

    $scope.viewUrl = 'views/showgroups.html';

    if (groupRequestId) {
        getEvents();
        getLanguages();
        getGroupRequestById(groupRequestId);
        $scope.viewUrl = 'views/editgroup.html';
    } else {
        getAllGroupRequests();
        $scope.viewUrl = 'views/showgroups.html';
    }

    $scope.addNew = function () {
        initRequest();
        if (!$scope.events) {
            getEvents();
        }
        if (!$scope.languages) {
            getLanguages();
        }
        $scope.request.UserGuid = $scope.userGuid;
        $scope.viewUrl = 'views/editgroup.html';
    };
    $scope.editGroup = function( request ) {
        getGroupRequestById(request.GroupRequestId);
    };
    $scope.refreshGroups = function () {
        getAllGroupRequests();
    };
    $scope.saveGroup = function () {
        $scope.request.Timestamp = new Date();
        if ($scope.request.GroupRequestId > 0) {
            $http.put('/api/group/put/?id=' + $scope.request.GroupRequestId, $scope.request).success(function (response) {
                $scope.viewUrl = 'views/showgroups.html';
                setTimeout(function () { getAllGroupRequests(); }, 1000);
            });
        } else {
            $http.post('/api/group/post/', $scope.request).success(function(response) {
                $scope.viewUrl = 'views/showgroups.html';
                setTimeout(function () { getAllGroupRequests(); }, 1000);
            });
        }
    };
    $scope.cancelEdit = function() {
        $scope.viewUrl = 'views/showgroups.html';
        setTimeout(function () { getAllGroupRequests(); }, 1000);
    };

    //var fetchLoop = setInterval(function () { getAllGroupRequests(); }, 60000);//Refresh every minute-may need to disable this
    //var purgeLoop = setInterval(function () { purgeOldData(); }, 1800000);//Purge every 30 minutes
}]);