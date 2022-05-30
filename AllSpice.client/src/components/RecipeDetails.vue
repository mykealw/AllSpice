<template>
  <div class="row bg-light">
    <div class="col-md-4">
      <img
        class="img-fluid rounded shadow"
        :src="activeRecipe.picture"
        alt=""
      />
    </div>
    <div class="col-md-8">
      <div class="row">
        <div class="col-md-12">
          <h5>{{ activeRecipe.title }}</h5>
          <p>{{ activeRecipe.subtitle }}</p>
        </div>
        <div class="col-md-6 text-dark">
          <div class="bgcolor text-light rounded-top">
            <h6 class="text-center m-0">Recipe Steps</h6>
          </div>
          <div class="bggrey">
            <h6
              v-for="s in steps"
              :key="s.id"
              class="selectable"
              @click="removeStep(s.id)"
            >
              {{ s.position }} {{ s.body }}
            </h6>
          </div>
          <div>
            <form @submit.prevent="addStep(activeRecipe.id)">
              <label for="" class="form-label"></label>
              <input
                type="text"
                v-model="editable.body"
                class="form-control"
                aria-describedby="helpId"
                placeholder="Add step..."
              />
              <button type="submit" class="btn greenbtn">+</button>
            </form>
          </div>
        </div>
        <div class="col-md-6 text-dark">
          <div class="bgcolor text-light rounded-top">
            <h6 class="text-center m-0">Ingredients</h6>
          </div>
          <div class="bggrey">
            <h6
              v-for="i in ingredients"
              :key="i.id"
              class="selectable"
              @click="removeIngredient(i.id)"
            >
              {{ i.name }} {{ i.quantity }}
            </h6>
          </div>
          <div>
            <form @submit.prevent="addIngredients(activeRecipe.id)">
              <label for="" class="form-label"></label>
              <input
                type="text"
                v-model="editable.name"
                class="form-control"
                aria-describedby="helpId"
                placeholder="Name of Ingredient..."
              />
              <label for="" class="form-label"></label>
              <input
                type="text"
                v-model="editable.quantity"
                class="form-control"
                aria-describedby="helpId"
                placeholder="Add Quantity..."
              />
              <button type="submit" class="btn greenb">+</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed, ref } from '@vue/reactivity'
import { AppState } from '../AppState.js'
import { onMounted, watchEffect } from '@vue/runtime-core'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'

export default {

  setup(props) {
    return {}
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 40vh;
  width: 100%;
  object-fit: cover;
}
</style>