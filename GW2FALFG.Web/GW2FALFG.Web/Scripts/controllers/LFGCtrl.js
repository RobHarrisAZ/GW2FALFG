LFG.controllers.controller('LFGCtrl', ['$scope', '$http', '$routeParams', 'CookieService', function ($scope, $http, $routeParams, CookieService) {
    var groupRequestId = $routeParams.id,
        getAllGroupRequests = function() {
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
        getCharacterClasses = function() {
            $http.get('/api/characterclass/').success(function (response) {
                $scope.classes = response;
            });
        },
        getVoiceChat = function () {
            $http.get('/api/voicechat/').success(function (response) {
                $scope.voiceChats = response;
            });
        },
        getGroupRequestById = function (id) {
            $http.get('/api/group/' + id).success(function(response) {
                $scope.request = response;
                if ($scope.request.UserGuid === CookieService.getCookie('userGuid')) {
                    if (!$scope.events) {
                        getEvents();
                    }
                    if (!$scope.voiceChats) {
                        getVoiceChat();
                    }
                    if (!$scope.classes) {
                        getCharacterClasses();
                    }
                    $scope.newVoiceChats = $scope.voiceChats;
                    for (var index = 0; index < $scope.newVoiceChats.length; index++) {
                        $scope.newVoiceChats[index].checked = '';
                    }
                    if ($scope.request.GroupVoiceChats) {
                        for (var outerIndex = 0; outerIndex < $scope.request.GroupVoiceChats.length; outerIndex++) {
                            for (var innerIndex = 0; innerIndex < $scope.newVoiceChats.length; innerIndex++) {
                                if ($scope.request.GroupVoiceChats[outerIndex].VoiceChatId === $scope.newVoiceChats[innerIndex].VoiceChatId) {
                                    $scope.newVoiceChats[innerIndex].checked = 'checked';
                                }
                            }
                        }
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
                GroupVoiceChats: []
            };
            $scope.newVoiceChats = $scope.voiceChats;
            for (var index = 0; index < $scope.newVoiceChats.length; index++) {
                $scope.newVoiceChats[index].checked = '';
            }
        };

    
    $scope.userGuid = CookieService.getCookie('userGuid');
    if (!$scope.userGuid) {
        $scope.userGuid = createUuid();
        var expDate = new Date(new Date().getTime() + CookieService.daysToMs(7));
        CookieService.setCookie('userGuid', $scope.userGuid, expDate);
    }
    $scope.viewUrl = 'views/showgroups.html';

    if (groupRequestId) {
        if (!$scope.events) {
            getEvents();
        }
        if (!$scope.voiceChats) {
            getVoiceChat();
        }
        if (!$scope.classes) {
            getCharacterClasses();
        }
        getGroupRequestById(groupRequestId);
        $scope.viewUrl = 'views/editgroup.html';
    } else {
        getAllGroupRequests();
        if (!$scope.events) {
            getEvents();
        }
        if (!$scope.classes) {
            getCharacterClasses();
        }
        if (!$scope.voiceChats) {
            getVoiceChat();
        }
        $scope.viewUrl = 'views/showgroups.html';
    }
    $scope.adminLogin = function() {
        if (!$scope.events) {
            getEvents();
        }
        if (!$scope.voiceChats) {
            getVoiceChat();
        }
        if (!$scope.classes) {
            getCharacterClasses();
        }
        $scope.viewUrl = 'views/admin.html';
    };
    $scope.addNew = function () {
        if (!$scope.events) {
            getEvents();
        }
        if (!$scope.classes) {
            getCharacterClasses();
        }
        if (!$scope.voiceChats) {
            getVoiceChat();
        }
        initRequest();
        $scope.request.UserGuid = $scope.userGuid;
        $scope.viewUrl = 'views/editgroup.html';
    };
    $scope.editGroup = function( request ) {
        if (!$scope.events) {
            getEvents();
        }
        if (!$scope.classes) {
            getCharacterClasses();
        }
        getGroupRequestById(request.getProperty('GroupRequestId'));
    };
    $scope.refreshGroups = function () {
        getAllGroupRequests();
    };
    $scope.saveGroup = function () {
        $scope.request.Timestamp = new Date();
        //rebuild GroupVoiceChats from form data
        $scope.request.GroupVoiceChats = [];
        for (var index = 0; index < $scope.newVoiceChats.length; index++) {
            if ($scope.newVoiceChats[index].checked === 'checked'){
                $scope.request.GroupVoiceChats.push({ GroupRequestId: $scope.request.GroupRequestId, VoiceChatId: $scope.newVoiceChats[index].VoiceChatId });
            }
        }
        if ($scope.request.GroupRequestId > 0) {
            $http.put('/api/group/put/?id=' + $scope.request.GroupRequestId, $scope.request)
                .success(function(response) {
                    $scope.viewUrl = 'views/showgroups.html';
                    setTimeout(function() { getAllGroupRequests(); }, 1000);
                })
                .error(function(response) {
                    $scope.viewUrl = 'views/error.html';
                });
        } else {
            $http.post('/api/group/post/', $scope.request)
                .success(function (response) {
                    $scope.viewUrl = 'views/showgroups.html';
                    setTimeout(function() { getAllGroupRequests(); }, 1000);
                })
                .error(function(response) {
                    $scope.viewUrl = 'views/error.html';
                });
        }
    };
    $scope.cancelEdit = function() {
        $scope.viewUrl = 'views/showgroups.html';
        setTimeout(function () { getAllGroupRequests(); }, 1000);
    };
    $scope.gridOptions = {
        displaySelectionCheckbox: false,
        displayFooter: false,
        data: 'groupRequestsAll',
        columnDefs: [
            { field: 'GroupRequestId', displayName: ' ', cellTemplate: '<button ng-click="editGroup(row)" class="btn btn-inverse" editlink>Edit</button>' },
            { field: 'PlayerName', displayName: 'Player Name' },
            { field: 'CharacterClassName', displayName: 'Class', cellTemplate: '<span><img ng-src="/Content/images/{{row.getProperty(\'CharacterClass.CharacterClassName\')}}.png" class="voiceImagesSm" alt="{{row.getProperty(\'CharacterClass.CharacterClassName\')}}" title="{{row.getProperty(\'CharacterClass.CharacterClassName\')}}"> {{row.getProperty(\'CharacterClass.CharacterClassName\')}}</span>' },
            { field: 'Level', displayName: 'Level', cellClass: 'input-mini' },
            { field: 'Event.EventName', displayName: 'Event', cellClass: 'input-xlarge' },
            { field: 'Description', displayName: 'Description' },
            {
                field: 'VoiceChat', displayName: 'Voice Chat'
                , cellTemplate: '<voicechats/>'
                //, cellTemplate: '<div ng-class="ngCellText"><ul>' +
                //'<li ng-repeat=""><img url="{{row.getProperty(\'VoiceChats.LogoImageUrl\')}}" title="{{row.getProperty(\'VoiceChats.VoiceChatName\')}}" alt="{{row.getProperty(\'VoiceChats.VoiceChatName\')}}"></li></ul></div>'
            },
            { field: 'Timestamp', displayName: 'Elapsed', cellTemplate: '<span ng-cell-text>{{row.getProperty(\'Timestamp\')|showelapsed}}</span>' }
        ],
    };
    //var fetchLoop = setInterval(function () { getAllGroupRequests(); }, 60000);//Refresh every minute-may need to disable this
}]);