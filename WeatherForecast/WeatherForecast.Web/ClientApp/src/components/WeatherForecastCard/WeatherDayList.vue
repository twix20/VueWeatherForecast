<template>
  <div class="root">
    <div class="item" v-for="day in days" :key="day.date">
      <WeatherDayCard :day="day"/>
    </div>
  </div>
</template>

<script>
import WeatherDayCard from "./WeatherDayCard";

export default {
  props: {
    days: Array
  },
  components: {
    WeatherDayCard
  }
};
</script>

<style scoped>
.root {
  display: flex;
  flex: 1 1 0;
  justify-content: space-between;
  overflow-x: auto;
}
.item {
  margin-right: 0.8em;
  max-width: 120px;
}
</style>
