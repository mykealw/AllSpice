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
      <button
        class="btn btn-dark text-light textfont rd1 rd2"
        data-bs-toggle="modal"
        :data-bs-target="'#see-more' + recipe.id"
        @click="getSteps(recipe.id)"
      >
        Details
      </button>
    </div>
  </div>
  <Modal :id="'see-more' + recipe.id">
    <template #title>
      <span class="text-center text-dark textfont"> Recipe Details</span>
    </template>
    <template #body><RecipeDetails :id="recipe.id" /></template>
  </Modal>
</template>


<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
import { recipesService } from '../services/RecipesService.js'
import { stepsService } from "../services/StepsService.js";
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
      stonks: computed(() => AppState.myFavorites.find(s => s.id == props.recipe.id)),
      activeRecipe: computed(() => AppState.activeRecipe),
      async deleteFavorite(id) {
        try {
          await recipesService.deleteFavorite(id)
        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      },
      async createFavorite(id) {
        try {
          let favorite = {
            accountId: AppState.user.id,
            recipeId: id
          }
          await recipesService.createFavorite(favorite)
        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      },
      async getSteps(id) {
        try {
          await stepsService.getSteps(id)
          await stepsService.getIngredients(id)
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