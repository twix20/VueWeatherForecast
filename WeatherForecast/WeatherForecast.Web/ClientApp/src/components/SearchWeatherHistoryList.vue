<template>
  <b-card no-body header="Search history">
    <div v-if="history.length === 0">Start searching!</div>
    <b-list-group v-else flush>
      <b-list-group-item
        v-for="search in history"
        :key="search.date.toString()"
        class="SearchHistoryItem flex-column align-items-start pt-4"
      >
        <div class="d-flex w-100 justify-content-between">
          <small class="SearchHistoryItem__Date">{{search.date | moment}}</small>
          <!-- <h5 class="mb-1">List group item heading</h5> -->
          <p class="mb-1 text-nowrap">
            You searched for
            <b>{{search.value}}</b>.
          </p>
        </div>
      </b-list-group-item>
    </b-list-group>
  </b-card>
</template>

<script>
import moment from "moment";

export default {
  props: {
    history: Array
  },
  filters: {
    moment: function(date) {
      const now = moment().add(1, "seconds");
      const duration = moment.duration(moment(date).diff(now));

      return duration.humanize(true);
    }
  }
};
</script>

<style>
.SearchHistoryItem {
  position: relative;
}

.SearchHistoryItem__Date {
  position: absolute;
  top: 0.3rem;
  right: 1rem;
}
</style>