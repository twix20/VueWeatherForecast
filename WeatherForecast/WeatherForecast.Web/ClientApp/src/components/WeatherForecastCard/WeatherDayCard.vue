<template>
  <b-card class="WeatherDayCard__Root">
    <b-card-title class="WeatherDayCard__Title">Sun</b-card-title>
    <b-card-text>
      <b-container>
        <b-row class="WeatherDayCard__MeasurementContainer">
          <span class="WeatherDayCard__Measurement">18&#8451;</span>

          <span class="WeatherDayCard__Measurement">29</span>
        </b-row>
      </b-container>
    </b-card-text>
    <b-card-text class="small text-muted">
      <CloudImg/>
    </b-card-text>
    <b-card-footer>Sunset</b-card-footer>
  </b-card>
</template>

<script>
import CloudImg from "../CloudImg";
export default {
  components: {
    CloudImg
  }
};
</script>

<style>
.WeatherDayCard__Root {
  text-align: center;
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
</style>

