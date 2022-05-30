<template>
  <div class="Recipe selectable my-2 position-relative">
    <img class="rp" :src="recipe.picture" alt="" />
    <div class="div">
      <i
        @click="deleteFavorite(recipe.id)"
        v-if="stonks"
        class="mdi mdi-heart mdi-36px position-absolute rc1 rc2 text-danger"
      ></i>
      <i
        @click="createFavorite(recipe.id)"
        v-if="!stonks"
        class="mdi mdi-heart-outline mdi-36px position-absolute rc1 rc2"
      ></i>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
import { recipesService } from '../services/RecipesService.js'
export default {
  props: {
    recipe: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      props,
      stonks: computed(() => AppState.myFavorites.find(s => s.id === props.recipe.id)),
      async deleteFavorite(id) {
        try {
          //  logger.log(id, "Id")
          await recipesService.deleteFavorite(id)
        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      },
      async createFavorite(id) {
        try {
          await recipesService.createFavorite(id)
        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.rp {
  height: 25vh;
  width: 100%;
  object-fit: cover;
  border: 3px solid black;
}

.rp2 {
}
</style>