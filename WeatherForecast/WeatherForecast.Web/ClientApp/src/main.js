import Vue from "vue";
import Multiselect from "vue-multiselect";
import VueBootstrapToasts from "vue-bootstrap-toasts";
import BootstrapVue from "bootstrap-vue";
import { Layout } from "bootstrap-vue/es/components";
import { library } from "@fortawesome/fontawesome-svg-core";
import { faUserSecret, faSearch } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

import App from "./App.vue";
import store from "./store";

library.add(faUserSecret, faSearch);

Vue.config.productionTip = false;
Vue.component("multiselect", Multiselect);
Vue.component("font-awesome-icon", FontAwesomeIcon);
Vue.use(BootstrapVue);
Vue.use(Layout);
Vue.use(VueBootstrapToasts);

new Vue({
  store,
  render: h => h(App)
}).$mount("#app");
