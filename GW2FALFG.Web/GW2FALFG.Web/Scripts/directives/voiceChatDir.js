LFG.directives.
    directive('voicechats', function () {
        return {
            restrict: 'E',
            replace: true,
            scope: false,
            template: [
                '<ul class="voiceImageDisplay">',
                '<li class="voiceImageDisplayItem" ng-repeat="voice in row.getProperty(\'GroupVoiceChats\')"><img ng-src="{{voice.VoiceChat.LogoImageUrl}}" alt="{{voice.VoiceChat.VoiceChatName}}" title="{{voice.VoiceChat.VoiceChatName}}" class="voiceImagesSm"/></li>',
                '</ul>'
            ].join('')
        };
    });