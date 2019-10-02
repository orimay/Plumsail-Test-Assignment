import Vue from "vue";
import App from "./App.vue";
import plugins from "./plugins/";

Vue.config.productionTip = false;

new Vue({
  ...plugins,
  render: h => h(App)
}).$mount("#app");
