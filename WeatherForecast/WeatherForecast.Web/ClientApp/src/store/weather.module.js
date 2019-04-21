import { kelvinsToCelcius } from "@/common/utils";
import { WeatherApi } from "@/common/services/api";

import {
  FETCH_WEATHER_FORECAST_ASYNC,
  WEATHER_HISTORY_ADD
} from "./actions.type";
import { FETCH_WEATHER_FORECAST, HISTORY_ADD } from "./mutations.type";

const historyLocalStorageKey = "history";

const initialState = {
  [FETCH_WEATHER_FORECAST.loadingKey]: false,
  [FETCH_WEATHER_FORECAST.errorKey]: null,
  forecast: null,
  history: JSON.parse(
    window.localStorage.getItem(historyLocalStorageKey) || "[]"
  )
};

export const state = { ...initialState };

export const actions = {
  async [FETCH_WEATHER_FORECAST_ASYNC](context, { city, zipCode }) {
    context.commit(FETCH_WEATHER_FORECAST.START);

    try {
      const {
        data: { days }
      } = await WeatherApi.getForecast(city, zipCode);

      context.commit(FETCH_WEATHER_FORECAST.SUCCESS, { city, days });
      return days;
    } catch (error) {
      context.commit(FETCH_WEATHER_FORECAST.FAILURE, error);
    }
  },
  [WEATHER_HISTORY_ADD](context, payload) {
    context.commit(HISTORY_ADD, payload);
  }
};

export const mutations = {
  [HISTORY_ADD](state, payload) {
    state.history = [...state.history, payload];
    window.localStorage.setItem(
      historyLocalStorageKey,
      JSON.stringify(state.history)
    );
  },
  [FETCH_WEATHER_FORECAST.START](state) {
    state[FETCH_WEATHER_FORECAST.loadingKey] = true;
  },
  [FETCH_WEATHER_FORECAST.FAILURE](state, error) {
    state[FETCH_WEATHER_FORECAST.loadingKey] = false;
    state[FETCH_WEATHER_FORECAST.errorKey] = error;
  },
  [FETCH_WEATHER_FORECAST.SUCCESS](state, payload) {
    state[FETCH_WEATHER_FORECAST.loadingKey] = false;
    state.forecast = {
      ...payload,
      days: payload.days.map(d => ({
        ...d,
        averageTemperature: kelvinsToCelcius(d.averageTemperature).toFixed(2),
        windSpeed: d.windSpeed.toFixed(2)
      }))
    };
  }
};

const getters = {
  errorForecast: state => state[FETCH_WEATHER_FORECAST.errorKey],
  loadingForecast: state => state[FETCH_WEATHER_FORECAST.loadingKey],
  forecast: state => state.forecast,
  history: state => state.history
};

export default {
  state,
  actions,
  mutations,
  getters
};
