<template>
  <form class="" @submit.prevent="createRecipe">
    <div class="col-md-12">
      <label for="" class="form-label text-dark textfont"> Title </label>
      <input
        type="text"
        v-model="editable.title"
        class="form-control"
        aria-describedby="title here"
        required
        placeholder="Recipes Title here..."
      />
    </div>
    <div class="col-md-12">
      <label for="" class="form-label text-dark textfont"> Category </label>
      <input
        type="text"
        v-model="editable.category"
        class="form-control"
        aria-describedby="category here"
        placeholder="Recipes Category here..."
        required
      />
    </div>
    <div class="col-md-12">
      <label for="" class="form-label text-dark textfont"> Subtitle </label>
      <input
        type="text"
        v-model="editable.subtitle"
        class="form-control"
        aria-describedby="subtitle here"
        placeholder="Recipes Subtitle here..."
        required
      />
    </div>
    <div class="col-md-12">
      <label for="" class="form-label text-dark textfont"> Add Picture </label>
      <input
        type="text"
        v-model="editable.picture"
        class="form-control"
        aria-describedby="image link"
        placeholder="Put Image link here..."
        required
      />
    </div>
    <button class="btn greenb rounded text-dark mt-3" type="submit">
      Create Recipe
    </button>
  </form>
</template>


<script>
import { ref } from '@vue/reactivity'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
import { recipesService } from '../services/RecipesService.js'
export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createRecipe() {
        try {

          await recipesService.createRecipe(editable.value)
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
</style>