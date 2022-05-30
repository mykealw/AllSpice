<template class="">
  <main class="m-2 bg">
    <router-view />
  </main>
  <footer></footer>
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
    margin-top: -18vh;
    margin-left: 127px;
  }
  .rc1 {
    margin-top: -26vh;
    margin-left: 310px;
  }
  .os1 {
    margin-top: -14vh;
    margin-left: 100px;
  }
  .nb1 {
    margin-top: -2vh;
    margin-left: -2px;
  }
  .rd1 {
    margin-top: -8vh;
  }
}
// regular size screen
@media only screen and (min-width: 767.98px) {
  .as2 {
    margin-top: -26vh;
    margin-left: 540px;
  }
  .rc2 {
    margin-top: -26vh;
    margin-left: 245px;
  }
  .os2 {
    margin-top: -19vh;
    margin-left: 515px;
  }
  .nb2 {
    margin-top: -4vh;
    margin-left: 415px;
  }
  .rd2 {
    margin-top: -11vh;
  }
}
</style>
