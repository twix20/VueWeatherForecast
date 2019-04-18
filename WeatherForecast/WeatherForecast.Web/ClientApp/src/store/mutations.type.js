const createAsyncMutation = type => ({
  SUCCESS: `${type}_SUCCESS`,
  FAILURE: `${type}_FAILURE`,
  START: `${type}_START`,
  loadingKey: `${type}_PENDING`.toUpperCase(),
  errorKey: `${type}_ERROR`.toUpperCase()
});

export const FETCH_WEATHER_FORECAST = createAsyncMutation(
  "FETCH_WEATHER_FORECAST"
);

export const HISTORY_ADD = "HISTORY_ADD";
