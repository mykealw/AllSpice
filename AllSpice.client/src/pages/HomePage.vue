<template>
  <Navbar />
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12 text-light position-relative">
        <img class="spicy mt-2" src="https://images.unsplash.com/photo-1606914469633-bd39206ea739?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80" alt="" />
        <h1 class="ts position-absolute as1 text-light as2 textfont">
          ALL-SPICE
        </h1>
        <h3 class="ts position-absolute os1 text-light os2 textfont">
          Cherish Your Family <br />
          And Their Cooking
        </h3>
        <div class="position-absolute nb2 nb1">
          <div class="d-flex bd bg">
            <h3
              class="mx-3 action my-auto text-dark textfont"
              @click="getAll()"
            >
              Home
            </h3>
            <h3
              class="mx-3 action my-auto text-dark textfont"
              @click="getMyRecipes()"
            >
              My Recipes
            </h3>
            <h3
              class="mx-3 action my-auto text-dark textfont"
              @click="getMyFavs()"
            >
              Favorites
            </h3>
          </div>
        </div>
      </div>
    </div>
    <div class="row mt-5">
      <div class="col-md-3" :title="r.title" v-for="r in recipes" :key="r.id">
        <Recipe :recipe="r"  />
      </div>
    </div>
    <div class="row">
      <div class="col-md-12 d-flex justify-content-end p-3">
        <button class="btn greenb rounded-pill bbt" @click="makeRecipeModal()">
          +
        </button>
      </div>
    </div>
    <div>
      <!-- <Modal id="create-recipe">
        <template #title>
          <span class="text-dark textfont">Create Recipe</span>
        </template>
        <template #body><RecipeForm /></template>
      </Modal> -->
    </div>
  </div>
  <div>

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
import { Modal } from 'bootstrap'

export default {
  name: 'Home',
  setup() {
    watchEffect(async () => {
      try {
        await recipesService.getAll()
      }
      catch (error) {
        logger.log(error)
        Pop.toast(error.message, "error");
      }
    })
    return {
      recipes: computed(() => AppState.recipes),
    
      async makeRecipeModal() {
        try {
          Modal.getOrCreateInstance(document.getElementById('create-recipe')).show()
        } catch (error) {
          logger.log(error)
          Pop.toast(error.message, "error")
        }
      },
      async getMyRecipes() {
        try {
          await recipesService.getMyRecipes()
        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      },
      async getAll() {
        try {
          await recipesService.getAll()

        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      },
      async getMyFavs() {
        try {
          await recipesService.getMyFavs()

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

<style scoped lang="scss">
.spicy {
  height: 30vh;
  width: 100%;
  object-fit: cover;
  border: 5px solid black;
}
</style>
