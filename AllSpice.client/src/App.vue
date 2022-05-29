<template>
  <main class="m-2">
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
.jcc {
  justify-content: center;
}
.ts {
  text-shadow: 1px 1px 0 #141414, -1px -1px 0 #141414, 1px -1px 0 #141414,
    -1px 1px 0 #141414, 1px 1px 0 #141414;
}
// mobile
@media only screen and (max-width: 767px) {
  .as1 {
    margin-top: -18vh;
    margin-left: 127px;
  }
  .os1 {
    margin-top: -14vh;
    margin-left: 100px;
  }
}
// regular size screen
@media only screen and (min-width: 767.98px) {
  .as2 {
    margin-top: -22vh;
    margin-left: 540px;
  }
  .os2 {
    margin-top: -15vh;
    margin-left: 515px;
  }
}
</style>
