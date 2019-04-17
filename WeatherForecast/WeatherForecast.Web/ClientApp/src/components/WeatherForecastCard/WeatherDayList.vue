<template>
  <div class="root">
    <div class="item">
      <WeatherDayCard/>
    </div>
    <div class="item">
      <WeatherDayCard/>
    </div>
    <div class="item">
      <WeatherDayCard/>
    </div>
    <div class="item">
      <WeatherDayCard/>
    </div>
    <div class="item">
      <WeatherDayCard/>
    </div>
  </div>
</template>

<script>
import WeatherDayCard from "./WeatherDayCard";
export default {
  components: {
    WeatherDayCard
  }
};
</script>

<style scoped>
.root {
  display: flex;
  justify-content: space-between;
  overflow-x: auto;
}
.item {
  margin-right: 1em;
}
</style>
