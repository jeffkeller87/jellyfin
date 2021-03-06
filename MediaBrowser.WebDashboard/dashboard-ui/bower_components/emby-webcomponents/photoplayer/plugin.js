define(["browser", "require", "events", "apphost", "loading", "dom", "playbackManager", "appRouter", "appSettings", "connectionManager"], function(browser, require, events, appHost, loading, dom, playbackManager, appRouter, appSettings, connectionManager) {
    "use strict";

    function PhotoPlayer() {
        var self = this;
        self.name = "Photo Player", self.type = "mediaplayer", self.id = "photoplayer", self.priority = 1
    }
    return PhotoPlayer.prototype.play = function(options) {
        return new Promise(function(resolve, reject) {
            require(["slideshow"], function(slideshow) {
                var index = options.startIndex || 0;
                new slideshow({
                    showTitle: !1,
                    cover: !1,
                    items: options.items,
                    startIndex: index,
                    interval: 11e3,
                    interactive: !0
                }).show(), resolve()
            })
        })
    }, PhotoPlayer.prototype.canPlayMediaType = function(mediaType) {
        return "photo" === (mediaType || "").toLowerCase()
    }, PhotoPlayer
});