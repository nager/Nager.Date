if (parseInt(Vue.version) < 3) { // legacy browser running Vue2
    Vue.createApp = function (app) {
        return {
            mount: function (elSelector) {
                app.el = elSelector;
                return new Vue(app);
            }
        }
    }
}
