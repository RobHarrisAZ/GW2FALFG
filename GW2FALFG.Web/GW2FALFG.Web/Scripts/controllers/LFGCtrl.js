LFG.controllers.controller('LFGCtrl', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
    var groupRequestId = $routeParams.id,
        getAllGroupRequests = function() {
            $http.get('/api/group/').success(function(response) {
                $scope.groupRequestsAll = response;
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
        setCookie = function(name, value, expYear, expMonth, expDay, path, domain, secure) {
            var cookieString = name + "=" + escape(value);

            if (expYear) {
                var expires = new Date(expYear, expMonth, expDay);
                cookieString += "; expires=" + expires.toGMTString();
            }

            if (path)
                cookieString += "; path=" + escape(path);

            if (domain)
                cookieString += "; domain=" + escape(domain);

            if (secure)
                cookieString += "; secure";

            document.cookie = cookieString;
        },
        getCookie = function(cookieName) {
            var results = document.cookie.match('(^|;) ?' + cookieName + '=([^;]*)(;|$)');

            if (results) {
                return (unescape(results[2]));
            } else {
                return null;
            }
        };

    //Handle User ID
    $scope.userGuid = getCookie('userGuid');
    if (!$scope.userGuid) {
        $scope.userGuid = createUuid();
        var today = new Date();
        today.setTime(today.getTime() + 86400);
        setCookie('userGuid', $scope.userGuid, today.getYear(), today.getMonth(), today.getDate(), '', 'infidelux.net', 'secure');
    }

    $scope.request = {};
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
        if (!$scope.events) {
            getEvents();
        }
        if (!$scope.languages) {
            getLanguages();
        }
        $scope.request.GroupRequestId = 0;
        $scope.request.UserGuid = $scope.userGuid;
        $scope.request.LanguagePreference = 'English';//Default
        $scope.viewUrl = 'views/editgroup.html';
    };
    $scope.saveGroup = function () {
        $scope.request.Timestamp = new Date();
        var requestString = 'Request:\r' +
            '\rID:' + $scope.request.GroupRequestId +
            '\rAgonyResist:' + $scope.request.AgonyResistRequired +
            '\rDescription:' + $scope.request.Description +
            '\rEventName:' + $scope.request.EventName +
            '\rFullRunFl:' + $scope.request.FullRunFl +
            '\rExperiencedOnlyFl:' + $scope.request.ExperiencedOnlyFl +
            '\rLanguagePreference:' + $scope.request.LanguagePreference +
            '\rLevel:' + $scope.request.Level +
            '\rLookingForNumber:' + $scope.request.LookingForNumber +
            '\rNewToDungeonFl:' + $scope.request.NewToDungeonFl +
            '\rPlayerName:' + $scope.request.PlayerName +
            '\rSpeedRunFl:' + $scope.request.SpeedRunFl +
            '\rTimestamp:' + $scope.request.Timestamp +
            '\rUserGuid:' + $scope.request.UserGuid;
        alert(requestString);
    };

}]);