import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";

import { API_HOST_URL } from "@/config";
import * as WeatherApi from "./weatherApi";
import * as OpenStreetmapApi from "./openstreetmapApi";

Vue.use(VueAxios, axios);

export const instance = axios.create({
  baseURL: API_HOST_URL
});

export { WeatherApi, OpenStreetmapApi };
