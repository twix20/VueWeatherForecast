<template>
  <b-card class="WeatherForecastCard__Root">
    <!-- <div class="bg-secondary text-light">
      This is some content within the default
      <samp>&lt;b-card-body&gt;</samp> block of the
      <samp>&lt;b-card&gt;</samp> component. Notice the padding between the card's border and this
      gray
      <samp>&lt;div&gt;</samp>.
    </div>-->
    <b-card-title class="WeatherForecastCard__Title">5 day forecast</b-card-title>

    <b-container fluid>
      <b-row align-h="start" class="mb-2">
        <b-col
          order="1"
          order-sm="1"
          cols="6"
          sm="4"
          class="WeatherForecastCard__Col WeatherForecastCard__LocationContainer"
        >
          <div class="WeatherForecastCard__Date">25.10.2019</div>
          <div class="WeatherForecastCard__Location">Berlin AAaaaaa</div>
          <div class="WeatherForecastCard__Temperature">25.1 &#8451;</div>
        </b-col>
        <b-col class="WeatherForecastCard__Col" order="3" order-sm="2" cols="12" sm="4">
          <CloudImg/>
        </b-col>
        <b-col class="WeatherForecastCard__Col" order="2" order-sm="3" cols="6" sm="4">
          <div class="WeatherForecastCard__Detail">
            <span class="WeatherForecastCard__DetailName">Humidity:</span>
            <span class="WeatherForecastCard__DetailValue">63%</span>
          </div>
          <div class="WeatherForecastCard__Detail">
            <span class="WeatherForecastCard__DetailName">Wind:</span>
            <span class="WeatherForecastCard__DetailValue">23 KM/H</span>
          </div>
        </b-col>
      </b-row>
      <b-row align-h="start">
        <WeatherDayList/>
      </b-row>
    </b-container>
  </b-card>
</template>

<script>
import WeatherDayList from "./WeatherDayList";
import CloudImg from "../CloudImg";

export default {
  name: "WeatherForecastCard",
  components: {
    WeatherDayList,
    CloudImg
  },
  props: {
    // msg: String
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
