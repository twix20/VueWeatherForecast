<template>
  <b-card class="WeatherForecastCard__Root">
    <b-card-title class="WeatherForecastCard__Title">5 day forecast</b-card-title>

    <div v-if="loadingForecast" class="text-center">
      <b-spinner variant="primary" type="grow" label="Spinning"></b-spinner>
    </div>

    <b-container v-else fluid>
      <b-row align-h="start" class="mb-2">
        <b-col
          order="1"
          order-sm="1"
          cols="6"
          sm="4"
          class="WeatherForecastCard__Col WeatherForecastCard__LocationContainer"
        >
          <div class="WeatherForecastCard__Date">{{formatDate(currentDayForecast.date)}}</div>
          <div class="WeatherForecastCard__Location">{{forecast.city}}</div>
          <div
            class="WeatherForecastCard__Temperature"
          >{{currentDayForecast.averageTemperature}} &#8451;</div>
        </b-col>
        <b-col
          class="WeatherForecastCard__Col align-items-center"
          order="3"
          order-sm="2"
          cols="12"
          sm="4"
        >
          <CloudImg
            class="WeatherForecastCard__MainImg"
            :alt="currentDayForecast.date"
            :temperature="currentDayForecast.averageTemperature"
            :windSpeed="currentDayForecast.windSpeed"
            :humidity="currentDayForecast.humidity"
          />
        </b-col>
        <b-col class="WeatherForecastCard__Col" order="2" order-sm="3" cols="6" sm="4">
          <div class="WeatherForecastCard__Detail">
            <span class="WeatherForecastCard__DetailName">Humidity:</span>
            <span class="WeatherForecastCard__DetailValue">{{currentDayForecast.humidity}}</span>
          </div>
          <div class="WeatherForecastCard__Detail">
            <span class="WeatherForecastCard__DetailName">Wind:</span>
            <span class="WeatherForecastCard__DetailValue">{{currentDayForecast.windSpeed}}KM/H</span>
          </div>
        </b-col>
      </b-row>
      <b-row align-h="center">
        <WeatherDayList :days="forecast.days.slice(1)"/>
      </b-row>
    </b-container>
  </b-card>
</template>

<script>
import moment from "moment";
import WeatherDayList from "./WeatherDayList";
import CloudImg from "../CloudImg";

export default {
  name: "WeatherForecastCard",
  components: {
    WeatherDayList,
    CloudImg
  },
  props: {
    forecast: Object,
    loadingForecast: Boolean
  },
  computed: {
    currentDayForecast() {
      return this.forecast.days[0];
    }
  },
  methods: {
    formatDate(date) {
      return moment(date).format("DD.MM.YYYY");
    }
  }
};
</script>

<style scoped>
.WeatherForecastCard__Root {
  text-align: initial;
}

.WeatherForecastCard__Title {
  text-align: center;
  text-transform: uppercase;
}
.WeatherForecastCard__Col {
  display: flex;
  flex-direction: column;
  justify-content: center;
}
.WeatherForecastCard__MainImg {
  max-width: 80%;
}
.WeatherForecastCard__LocationContainer {
  font-weight: bold;
}
.WeatherForecastCard__Date {
  font-size: 1.1em;
}
.WeatherForecastCard__Location {
  font-size: 1.4em;
  text-transform: uppercase;

  text-overflow: ellipsis;

  /* Required for text-overflow to do anything */
  white-space: nowrap;
  overflow: hidden;
}
.WeatherForecastCard__Temperature {
  font-size: 3.2em;
  white-space: nowrap;
}

.WeatherForecastCard__Detail {
  display: flex;
  justify-content: space-between;
}
.WeatherForecastCard__DetailName {
  font-weight: bold;
}
</style>
