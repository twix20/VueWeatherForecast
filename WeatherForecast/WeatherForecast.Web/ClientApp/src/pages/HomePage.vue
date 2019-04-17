<template>
  <div class="HomePage">
    <WeatherForecastCard/>
  </div>
</template>

<script>
import WeatherForecastCard from "@/components/WeatherForecastCard/WeatherForecastCard";

export default {
  name: "HomePage",
  components: {
    WeatherForecastCard
  }
};
</script>

<style>
.HomePage {
  max-width: 900px;
  margin: 0 auto;
}
</style>