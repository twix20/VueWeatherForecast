<template>
  <div>
    <Navbar/>

    <div class="HomePage mt-2">
      <b-container>
        <div class="mb-2 HomePage__SearchInputContainer">
          <SearchWeatherInput class="HomePage__SearchInput"/>
        </div>
        <div v-if="forecast !== null">
          <WeatherForecastCard :forecast="forecast" :loadingForecast="loadingForecast"/>
        </div>
        <div v-else-if="loadingForecast">
          <b-spinner variant="primary" type="grow" label="Spinning"></b-spinner>
        </div>
        <div v-else>
          <b-jumbotron
            header="Weather Forecast"
            lead="Start searching by using search engine above!"
          ></b-jumbotron>
        </div>
      </b-container>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import Navbar from "@/components/Navbar";
import WeatherForecastCard from "@/components/WeatherForecastCard/WeatherForecastCard";
import SearchWeatherInput from "@/components/SearchWeatherInput";

export default {
  name: "HomePage",
  components: {
    Navbar,
    WeatherForecastCard,
    SearchWeatherInput
  },
  watch: {
    errorForecast() {
      this.$toast.error("Error fetching forecast... Try again later");
    }
  },
  computed: {
    ...mapGetters(["forecast", "loadingForecast", "errorForecast"])
  }
};
</script>

<style>
.HomePage {
  max-width: 900px;
  margin: 0 auto;
}

.HomePage__SearchInputContainer {
  display: flex;
  justify-content: center;
}

.HomePage__SearchInput {
  max-width: 90%;
}

.HomePage__SearchInput .multiselect__single {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>