<template>
  <b-img :src="src" :alt="alt" fluid/>
</template>

<script>
export default {
  props: {
    alt: String,
    temperature: Number,
    humidity: Number,
    windSpeed: Number
  },
  computed: {
    src: function() {
      if (this.temperature > 25) return require("@/assets/sunny.png");
      if (this.windSpeed > 2) return require("@/assets/windy.png");

      return require("@/assets/rainy.png");
    }
  }
};
</script>

