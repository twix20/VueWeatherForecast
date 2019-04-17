import Vue from "vue";
import Vuex from "vuex";

import weather from "./weather.module";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    weather
  }
});
