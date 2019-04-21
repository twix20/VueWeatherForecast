<template>
  <div>
    <Navbar/>
    <div class="HomePage mt-2 mr-2 d-flex justify-content-between p-2">
      <div class="HomePage__Content">
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
      <div class="HomePage__RightSide d-none d-lg-block">
        <SearchWeatherHistoryList :history="history"/>
      </div>
    </div>
    <div class="d-lg-none m-2">
      <SearchWeatherHistoryList :history="history"/>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import Navbar from "@/components/Navbar";
import WeatherForecastCard from "@/components/WeatherForecastCard/WeatherForecastCard";
import SearchWeatherInput from "@/components/SearchWeatherInput";
import SearchWeatherHistoryList from "@/components/SearchWeatherHistoryList";

export default {
  name: "HomePage",
  components: {
    Navbar,
    WeatherForecastCard,
    SearchWeatherInput,
    SearchWeatherHistoryList
  },
  watch: {
    errorForecast() {
      this.$toast.error("Error fetching forecast... Try again later");
    }
  },
  computed: {
    ...mapGetters(["forecast", "loadingForecast", "errorForecast", "history"])
  }
};
</script>

<style>
.HomePage {
  /* max-width: 900px;
  margin: 0 auto; */
}

.HomePage__Content {
  flex-grow: 1;
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