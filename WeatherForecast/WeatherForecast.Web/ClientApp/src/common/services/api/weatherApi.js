import { instance } from "./index";

export const getForecast = (city, zipCode) =>
  instance.get(`/api/Weather/Forecast`, {
    params: {
      city,
      zipCode
    }
  });
