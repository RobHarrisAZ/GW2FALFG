LFG.services.
    factory('CookieService', function() {
        return {
            getCookie: function (key) {
                var cookieCollection = document.cookie;
                if (cookieCollection.length > 0) {
                    var first = cookieCollection.indexOf(key + "=");
                    if (first != -1) {
                        first = first + key.length + 1;
                        var last = cookieCollection.indexOf(";", first);
                        if (last === -1) {
                            last = cookieCollection.length;
                        }
                        return unescape(cookieCollection.substring(first, last));
                    }
                }
                return "";
            },
            setCookie: function(key, value, expDate) {
                document.cookie = key + "=" + value + ";expires=" + expDate.toGMTString();
            },
            fromSeconds: function(numseconds) {
                return numseconds * 1000;
            },
            minutesToMs: function(numminutes) {
                return this.fromSeconds(numminutes * 60);
            },
            hoursToMs: function (numhours) {
                return this.minutesToMs(numhours * 60);
            },
            daysToMs: function (numdays) {
                return this.hoursToMs(numdays * 24);
            },
            yearsToMs: function (numyears) {
                return this.daysToMs(numyears * 365);
            }
        };
    });

