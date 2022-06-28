<template class="">
  <main class="bg">
    <router-view />
  </main>

  <footer></footer>
  <RecipeForm />
  <RecipeDetails />
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
@import url("https://fonts.googleapis.com/css2?family=Sahitya&display=swap");
.textfont {
  font-family: "Sahitya", serif;
}
.jcc {
  justify-content: center;
}
.bt {
  font-weight: bold;
}
.bbt {
  font-weight: bolder;
}
.ts {
  text-shadow: 2px 2px 0 #141414, -1px -1px 0 #141414, 1px -1px 0 #141414,
    -1px 1px 0 #141414, 1px 1px 0 #141414;
}
.bg {
  background-color: beige;
}
.zz {
  z-index: 1111;
}
.bd {
  border: 5px solid black;
}
.greenb {
  background-color: green;
}
// mobile
@media only screen and (max-width: 767px) {
  .as1 {
    margin-top: -23vh;
    margin-left: 33vw;
  }
  .rc1 {
    margin-top: -26vh;
    margin-left: 83vw;
  }
  .os1 {
    margin-top: -14vh;
    margin-left: 25vw;
  }
  .nb1 {
    margin-top: 2vh;
    margin-left: 1vw;
  }
  .rd1 {
    margin-top: -14vh;
  }
}
// regular size screen
@media only screen and (min-width: 767.98px) {
  .as2 {
    margin-top: -26vh;
    margin-left: 42vw;
  }
  .rc2 {
    margin-top: -26vh;
    margin-left: 19.5vw;
  }
  .os2 {
    margin-top: -19vh;
    margin-left: 40vw;
  }
  .nb2 {
    margin-top: -4vh;
    margin-left: 33vw;
  }
  .rd2 {
    margin-top: -11vh;
  }
}
</style>
