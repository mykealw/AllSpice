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
          <h5 class="text-dark textfont">
            {{ activeRecipe.title }}
            <i
              v-if="activeRecipe.creatorId == account.id"
              class="mdi mdi-delete action"
              @click.stop="deleteReciepe(activeRecipe.id)"
            ></i>
          </h5>
          <p class="text-dark textfont">{{ activeRecipe.subtitle }}</p>
        </div>
        <div class="col-md-6 text-dark">
          <div class="bgcolor text-light rounded-top">
            <h6 class="text-center m-0 text-dark textfont">Recipe Steps</h6>
          </div>
          <div>
            <h6
              v-for="s in steps"
              :key="s.id"
              class="action"
              @click.stop="removeStep(s.id)"
            >
              {{ s.position }} {{ s.body }}
            </h6>
          </div>
          <div v-if="activeRecipe.creatorId == account.id">
            <form @submit.prevent="addStep(activeRecipe.id)">
              <label for="step body" class="form-label"></label>
              <input
                type="text"
                required
                v-model="editable.body"
                class="form-control"
                aria-describedby="add step body"
                placeholder="Add step..."
              />
              <label for="step position"></label>
              <input
                type="number"
                required
                placeholder="step position #"
                v-model="editable.position"
                class="form-control"
                aria-describedby="add step positn"
              />
              <button type="submit" class="btn greenb my-1">+</button>
            </form>
          </div>
        </div>
        <div class="col-md-6 text-dark">
          <div class="bgcolor text-light rounded-top">
            <h6 class="text-center m-0 text-dark textfont">Ingredients</h6>
          </div>
          <div>
            <h6
              v-for="i in ingredients"
              :key="i.id"
              class="action"
              @click.stop="removeIngredient(i.id)"
            >
              {{ i.name }} {{ i.quantity }}
            </h6>
          </div>
          <div v-if="activeRecipe.creatorId == account.id">
            <form @submit.prevent="addIngredients(activeRecipe.id)">
              <label for=" ingredient add name" class="form-label"></label>
              <input
                type="text"
                v-model="editable.name"
                required
                class="form-control"
                aria-describedby="ingredient name add"
                placeholder="Name of Ingredient..."
              />
              <label for=" ingredient quantity" class="form-label"></label>
              <input
                type="text"
                required
                v-model="editable.quantity"
                class="form-control"
                aria-describedby="add quantity input"
                placeholder="Add Quantity..."
              />
              <button type="submit" class="btn greenb my-1">+</button>
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
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
import { stepsService } from '../services/StepsService.js'
import { recipesService } from '../services/RecipesService.js'

export default {
  props: {
    id: {
      type: Number,
      required: true
    }
  },
  setup(props) {
    const editable = ref({ recipeId: props.id })
    return {
      editable,
      async addStep() {
        try {
          await stepsService.addSteps(editable.value)
        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      },
      async addIngredients() {
        try {
          await stepsService.addIngredients(editable.value)
        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      },
      async removeStep(id) {
        try {
          if (await Pop.confirm()) {
            await stepsService.removeSteps(id)
          }
        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      },
      async removeIngredient(id) {
        try {
          if (await Pop.confirm()) {
            await stepsService.removeIngredients(id)
          }
        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      },
      async deleteReciepe(id) {
        try {
          if (await Pop.confirm()) {
            await recipesService.deleteRecipe(id)
            Modal.getOrCreateInstance(document.getElementById('form-modal')).hide()
          }
        }
        catch (error) {
          logger.log(error);
          Pop.toast(error.message, "error");
        }
      },
      account: computed(() => AppState.account),
      activeRecipe: computed(() => AppState.recipes.find(r => r.id == props.id)),
      steps: computed(() => AppState.steps),
      ingredients: computed(() => AppState.ingredients)
    }
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