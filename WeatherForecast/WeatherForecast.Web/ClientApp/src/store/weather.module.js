import { WeatherApi } from "@/common/services/api";

import { FETCH_WEATHER_FORECAST, WEATHER_HISTORY_ADD } from "./actions.type";
import { SET_WEATHER_FORECAST, HISTORY_ADD } from "./mutations.type";

const initialState = {
  forecast: [],
  history: []
};

export const state = { ...initialState };

export const actions = {
  async [FETCH_WEATHER_FORECAST](context, { city, zipCode }) {
    debugger;
    const { data } = await WeatherApi.getForecast(city, zipCode);

    context.commit(SET_WEATHER_FORECAST, data.article);
    return data;
  },
  [WEATHER_HISTORY_ADD](context, payload) {
    context.commit(HISTORY_ADD, payload);
  }
};

export const mutations = {
  [HISTORY_ADD](state, payload) {
    state.history = [...state.history, payload];
  }
};

const getters = {
  forecast: state => state.forecast,
  history: state => state.history
};

export default {
  state,
  actions,
  mutations,
  getters
};
