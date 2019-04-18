<template>
  <b-card class="WeatherDayCard__Root">
    <b-card-title
      :class="{'WeatherDayCard__Title': true, 'WeatherDayCard__Title--weekend': isWeekend(day.date)}"
    >{{dayName(day.date)}}</b-card-title>
    <b-card-text>
      <b-container>
        <b-row class="WeatherDayCard__MeasurementContainer flex-column">
          <div class="WeatherDayCard__Measurement">{{day.averageTemperature}}&#8451;</div>

          <div class="d-flex justify-content-between">
            <span class="WeatherDayCard__Measurement">{{day.humidity}}</span>
            <span class="WeatherDayCard__Measurement">{{day.windSpeed}}</span>
          </div>
        </b-row>
      </b-container>
    </b-card-text>
    <b-card-text class="small text-muted">
      <CloudImg
        class="WeatherDayCard__CloudImage"
        :alt="day.date"
        :temperature="day.averageTemperature"
        :windSpeed="day.windSpeed"
        :humidity="day.humidity"
      />
    </b-card-text>
  </b-card>
</template>

<script>
import moment from "moment";
import CloudImg from "../CloudImg";

export default {
  props: {
    day: Object
  },
  components: {
    CloudImg
  },
  methods: {
    dayName(date) {
      return moment(date)
        .format("ddd")
        .toUpperCase();
    },
    isWeekend(date) {
      const dayNumber = moment(date).day();

      return [0, 6].includes(dayNumber);
    }
  }
};
</script>

<style>
.WeatherDayCard__Root {
  text-align: center;
}

.WeatherDayCard__Title--weekend {
  background-color: red;
  color: white;
}

.WeatherDayCard__MeasurementContainer {
  display: flex;
  justify-content: space-around;
}
.WeatherDayCard__Measurement {
  padding: 1px 3px;
  margin: 1px;
  background-color: rgba(240, 240, 240, 0.863);
}
.WeatherDayCard__CloudImage {
  width: 55px;
}
</style>

