<template>
  <div id="app">
    <Toasts></Toasts>

    <HomePage/>
  </div>
</template>

<script>
import HomePage from "./pages/HomePage.vue";

export default {
  name: "app",
  components: {
    HomePage
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
