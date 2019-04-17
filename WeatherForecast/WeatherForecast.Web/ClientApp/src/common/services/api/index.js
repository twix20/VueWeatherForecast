import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";

import { API_HOST_URL } from "@/common/config";
import * as WeatherApi from "./weatherApi";

Vue.use(VueAxios, axios);

export const instance = axios.create({
  baseURL: API_HOST_URL
});

export { WeatherApi };
