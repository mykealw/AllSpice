<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12 text-light position-relative">
        <img class="spicy mt-2" src="src\assets\img\allSpice.jpg" alt="" />
        <h1 class="ts position-absolute as1 as2 textfont">ALL-SPICE</h1>
        <h3 class="ts position-absolute os1 os2 textfont">
          Cherish Your Family <br />
          And Their Cooking
        </h3>
      </div>
    </div>
    <div class="row mt-5">
      <div class="col-md-3 " :title="r.title" v-for="r in recipes" :key= "r.id">
        <Recipe :recipe="r"/>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { onMounted, watchEffect } from '@vue/runtime-core'
import { logger } from '../utils/Logger.js'
import { recipesService } from '../services/RecipesService.js'
import { accountService } from '../services/AccountService.js'
import { AppState } from '../AppState.js'
import Pop from '../utils/Pop.js'
export default {
  name: 'Home',
  setup() {
    watchEffect(async () => {
      try {
        await recipesService.getAll()
        // await recipesService.getMyRecipes()
      }
      catch (error) {
        logger.log(error)
        Pop.toast(error.message, "error");
      }
    })
    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss">
.spicy {
  height: 30vh;
  width: 100%;
  object-fit: cover;
  border: 5px solid black;
}
</style>
