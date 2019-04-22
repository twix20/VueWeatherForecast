<template>
  <div>
    <Navbar/>
    <b-container class="HomePage">
      <b-row>
        <b-col sm="12" md="9" class="HomePage__Content p-2">
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
        </b-col>
        <b-col sm="12" md="3" class="HomePage__RightSide p-2">
          <SearchWeatherHistoryList :history="history"/>
        </b-col>
      </b-row>
    </b-container>
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
    ...mapGetters(["forecast", "loadingForecast", "errorForecast"]),
    history() {
      return this.$store.getters.history.slice().sort(function(a, b) {
        return new Date(b.date) - new Date(a.date);
      });
    }
  }
};
</script>

<style>
.HomePage__RightSide {
  height: calc(100vh - 70px);
  overflow-y: auto;
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