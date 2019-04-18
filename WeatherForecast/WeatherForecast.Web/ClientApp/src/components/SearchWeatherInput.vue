<template>
  <b-input-group>
    <b-dropdown slot="prepend">
      <template slot="button-content">
        <font-awesome-icon icon="search"/>
        <span class="sr-only">Search</span>
      </template>

      <b-dropdown-header>Search by</b-dropdown-header>
      <b-dropdown-item-button
        v-for="(option, i) in serachTypes"
        :key="option.value"
        :value="option.value"
        @click="searchType = i"
      >{{option.text}}</b-dropdown-item-button>

      <!-- <b-dropdown-item-button>City</b-dropdown-item-button>
      <b-dropdown-item-button>Zip Code</b-dropdown-item-button>-->
    </b-dropdown>

    <multiselect
      class="form-control p-0"
      v-model="searchInput"
      :placeholder="placeholder"
      :show-no-results="true"
      :options-limit="6"
      :close-on-select="true"
      :loading="isLoading"
      :searchable="true"
      :options="cities"
      open-direction="bottom"
      label="displayName"
      track-by="city"
      @search-change="debouncedAsyncSearch"
    >
      <div slot="noOptions">Start typing...</div>
    </multiselect>
  </b-input-group>
</template>

<script>
import debounce from "lodash/debounce";

import { FETCH_WEATHER_FORECAST_ASYNC } from "../store/actions.type";
import { OpenStreetmapApi } from "@/common/services/api";

export default {
  name: "SearchWeatherInput",
  data() {
    return {
      searchType: 0,
      serachTypes: [
        { value: "city", text: "City" },
        { value: "zipCode", text: "Zip Code" }
      ],

      searchInput: null,
      cities: [],
      isLoading: false
    };
  },
  watch: {
    searchInput: function(val) {
      const type = this.serachTypes[this.searchType].value;
      const city = val.city;

      this.searchWeather({ type, city });
    }
  },
  computed: {
    placeholder() {
      return this.searchType == 0
        ? "Search by city name"
        : "Search by city zip code";
    }
  },
  methods: {
    isCityMode() {
      return this.searchType === 0;
    },
    searchWeather({ type, city }) {
      this.$store.dispatch(FETCH_WEATHER_FORECAST_ASYNC, {
        city,
        type
      });
    },
    toggleSearchType() {
      this.searchType = (this.searchType + 1) % 2;
    },
    debouncedAsyncSearch: debounce(function(q) {
      this.asyncSearch(q);
    }, 300),
    asyncSearch(query) {
      this.isLoading = true;

      let city = null;
      let zipCode = null;
      if (this.isCityMode()) {
        city = query;
      } else {
        zipCode = query;
      }

      OpenStreetmapApi.search({ city, zipCode }).then(response => {
        this.cities = response.data
          .filter(r => r.address.city)
          .map(r => ({
            displayName: r.display_name,
            city: r.address.city
          }));
        this.isLoading = false;
      });
    }
  }
};
</script>

<style>
.SearchWeatherInput {
  /* display: flex; */
}
</style>


